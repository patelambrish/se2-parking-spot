using System;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebAPI.Repositories {
    public class SendGridEmailRepository: IEmailRepository {
        public bool SendEmail(string to, string from, string body, string subject) {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var fromEmail = new EmailAddress(from);
            var toEmail = new EmailAddress(to);            
            var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, null, body);
            var response = client.SendEmailAsync(msg);            
            return true;
        }
    }
}