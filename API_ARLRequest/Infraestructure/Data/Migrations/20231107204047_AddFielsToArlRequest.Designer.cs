﻿// <auto-generated />
using API_ARLRequest.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_ARLRequest.Infraestructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231107204047_AddFielsToArlRequest")]
    partial class AddFielsToArlRequest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_ARLRequest.Domain.ArlFile", b =>
                {
                    b.Property<int>("IdDocumentoARL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDocumentoARL"));

                    b.Property<int>("IdSolicitudArl")
                        .HasColumnType("int");

                    b.Property<string>("NombreArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocumentoARL");

                    b.HasIndex("IdSolicitudArl");

                    b.ToTable("ArlFiles");
                });

            modelBuilder.Entity("API_ARLRequest.Domain.ArlRequest", b =>
                {
                    b.Property<int>("IdSolicitudArl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSolicitudArl"));

                    b.Property<string>("Aprobo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapaOcho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoInstitucional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailPersonaACargoPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpsEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicioPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaRespuestaSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaTerminacionPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JornadaEstablecida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModalidadPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModoPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoAprobacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NitEmprendimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NitEmpresaPracticas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAprobador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmprendimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresaPracticas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePersonaACargoPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodoAcademico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramaAcademico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiesgoEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seleccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoPersonasACargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPractica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZonaResidencial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSolicitudArl");

                    b.ToTable("ArlRequests");
                });

            modelBuilder.Entity("API_ARLRequest.Domain.Regional", b =>
                {
                    b.Property<int>("IdRegional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegional"));

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRegional");

                    b.ToTable("Regionales");
                });

            modelBuilder.Entity("API_ARLRequest.Infraestructure.Security.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API_ARLRequest.Domain.ArlFile", b =>
                {
                    b.HasOne("API_ARLRequest.Domain.ArlRequest", "arlRequest")
                        .WithMany("Archivos")
                        .HasForeignKey("IdSolicitudArl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("arlRequest");
                });

            modelBuilder.Entity("API_ARLRequest.Domain.ArlRequest", b =>
                {
                    b.Navigation("Archivos");
                });
#pragma warning restore 612, 618
        }
    }
}