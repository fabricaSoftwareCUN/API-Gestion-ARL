using API_ARLRequest.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_ARLRequest.Infraestructure.Security.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }

        // Clave externa (FK) para relacionar Usuarios con Roles
        //public int IdRole { get; set; }
        //public ArlRequest roles { get; set; }
    }
}
