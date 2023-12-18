using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_ARLRequest.Domain
{
    public class Regional
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegional { get; set; }
        public string Municipio { get; set; }

    }
}