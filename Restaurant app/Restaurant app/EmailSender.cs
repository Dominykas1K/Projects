using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_app
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient("smtp.office365.com", 587))
            {
                client.Credentials = new NetworkCredential("dominykas.kazlauskas@codeacademylt.onmicrosoft.com", "password");
                client.EnableSsl = true;

                var mailMessage = new MailMessage("dominykas.kazlauskas@codeacademylt.onmicrosoft.com", to, subject, body);
                client.Send(mailMessage);
            }
        }
    }
}
