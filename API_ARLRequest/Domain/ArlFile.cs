using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_ARLRequest.Domain
{
    public class ArlFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDocumentoARL { get; set; }
        public string NombreArchivo { get; set; }
        public string ReferenciaArchivo { get; set; }

        // Clave externa (FK) para relacionar archivos con estudiantes
        [JsonIgnore]
        public int IdSolicitudArl { get; set; }
        [JsonIgnore]
        public ArlRequest arlRequest { get; set; }
    }
}
