using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ARLRequest.Domain
{
    //[Table(name: "ArlRequests", Schema = "dbo")]
    public class ArlRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSolicitudArl { get; set; }
        [Required]
        [StringLength(50)]
        public string NumeroIdentificacion { get; set;}
        [Required]
        [StringLength(50)]
        public string TipoIdentificacion { get; set; }
        [Required]
        [StringLength(150)]
        public string NombreEstudiante { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailEstudiante { get; set; }
        public string? ModalidadPractica { get; set; }
        public string? PeriodoAcademico { get; set; }
        public string? CapaOcho { get; set; }
        public string? DocumentoIdentidadFile { get; set; }
        public string? ProgramaAcademico { get; set; }
        public string? TipoPractica { get; set; }
        public string? RutFile { get; set; }
        public string? NombreEmprendimiento { get; set; }
        public string? NitEmprendimiento { get; set; }
        public string? CamaraComercioFile { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? EpsEstudiante { get; set; }
        public string? DocumentoEpsFile { get; set; }
        public string? NumeroTelEstudiante { get; set; }
        public string? CorreoInstitucional { get; set; }
        public string? NombreEmpresaPracticas { get; set; }
        public string? NitEmpresaPracticas { get; set; }
        public string? RiesgoEstudiante { get; set; }
        public string? NombrePersonaACargoPractica { get; set; }
        public string? TelefonoPersonasACargo { get; set; }
        public string? EmailPersonaACargoPractica { get; set; }
        public string? FechaInicioPractica { get; set; }
        public string? FechaTerminacionPractica { get; set; }
        public string? ActaInicioPractica { get; set; }
        public string? Regional { get; set; }
        public string? Seleccion { get; set; }
        public string? JornadaEstablecida { get; set; }
        public string? ModoPractica { get; set; }
        public string? ZonaResidencial { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? Aprobo { get; set; }
        public string? NombreAprobador { get; set; }
        public string? MotivoAprobacion { get; set; }

        public List<ArlFile> Archivos { get; set; } = new List<ArlFile>();
    }
}