﻿namespace API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Models
{
    public class SendEmail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
