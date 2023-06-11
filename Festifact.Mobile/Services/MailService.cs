using Festifact.Mobile.Services.Contracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class MailService : IMailService
    {
        public void Send(string subject, string body, string to = "marcelle34@ethereal.email", string from = null)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("marcelle34@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("marcelle34@ethereal.email", "aCMvqUKCHRPgwbn4BN");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
