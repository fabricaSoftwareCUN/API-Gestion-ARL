namespace API_ARLRequest.Infraestructure.Security.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
    }
}
