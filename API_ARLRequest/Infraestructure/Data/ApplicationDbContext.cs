using API_ARLRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //

        }

        // DbSet para cada entidad
        public DbSet<ArlRequest> ArlRequests { get; set; }
        public DbSet<ArlFile> ArlFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación uno a muchos entre Estudiantes y Documentos
            modelBuilder.Entity<ArlRequest>()
                .HasMany(e => e.Archivos)
                .WithOne(d => d.arlRequest)
                .HasForeignKey(d => d.IdSolicitudArl);
        }



    }
}
