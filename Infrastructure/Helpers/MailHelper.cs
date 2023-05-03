using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class MailHelper
    {
        public static void SendMail(string to, string title, string message)
        {
            MailMessage msg = new MailMessage("kendiMailAdresin", to);
            msg.Subject = title;
            msg.Body = message;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("kendiMailAdresin", "mailsifresi");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
        }
    }
}
