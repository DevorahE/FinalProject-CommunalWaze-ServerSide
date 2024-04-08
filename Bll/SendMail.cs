using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Bll
{
    public static class SendMail
    {
        public static bool BasicEmail(string eMail, string subject, string text)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Communal Waze", "MY_EMAIL"));
            email.To.Add(new MailboxAddress(eMail, eMail));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = text
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 465, true);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("MY_EMAIL", "MY_PASSWORD");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
            return true;
        }


    }
}
