using API_ARLRequest.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using API_ARLRequest.Infraestructure.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Desarrollo")));

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ArlUserService>();
builder.Services.AddTransient<AmazonS3>();

// Configurar JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Configurar politicas de Autorizacion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy
    .RequireClaim(ClaimTypes.Role, "Admin")
    );
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var mediator = services.GetRequiredService<IMediator>();
}*/

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
