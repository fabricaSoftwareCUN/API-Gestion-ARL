namespace API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.DTOs
{
    public class SendEmailDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
