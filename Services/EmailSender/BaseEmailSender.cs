using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Opuestos_por_el_Vertice.Models.Services.EmailSender;

namespace Opuestos_por_el_Vertice.Services.EmailSender
{
    public static class EmailSender
    {
        private static string _Host = "smtp.gmail.com";
        private static int _Port = 587;
        private static string _Remitter = "LucaRoezDev";
        private static string _Email = "luca.ezequiel.rodriguez@gmail.com";
        private static string _EmailKey = "";

        public static bool Send(EmailBase emailModel)
        {
            try
            {
                MimeMessage email = new();
                email.From.Add(new MailboxAddress(_Remitter, _Email));
                email.To.Add(MailboxAddress.Parse(emailModel.To));
                email.Subject = emailModel.Subject;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = emailModel.Body
                };

                SmtpClient smtp = new();
                smtp.Connect(_Host, _Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_Email, _EmailKey);
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
