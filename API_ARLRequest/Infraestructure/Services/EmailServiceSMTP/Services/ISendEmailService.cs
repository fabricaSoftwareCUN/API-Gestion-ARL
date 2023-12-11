using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.DTOs;

namespace API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Services
{
    public interface ISendEmailService
    {
        void SendEmail(SendEmailDTO sendEmailDTO);
    }
}
