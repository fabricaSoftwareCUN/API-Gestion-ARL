using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.DTOs;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Models;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(SendEmailDTO sendEmailDTO)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(sendEmailDTO.To));
            email.Subject = sendEmailDTO.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = sendEmailDTO.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );

            smtp.Authenticate(
                _configuration.GetSection("Email:UserName").Value,
                _configuration.GetSection("Email:Password").Value
                );

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
