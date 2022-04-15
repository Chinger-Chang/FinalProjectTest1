using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Services
{
    public class MailHelper
    {
        private MailMessage mail;
        private readonly SmtpClient client;
        public MailHelper()
        {
            client = new SmtpClient("smtp.gmail.com", 587);
        }
       
        public MailHelper(MailMessage mail)
        {
            client = new SmtpClient("smtp.gmail.com", 587);
            this.mail = mail;
        
        }
        public bool Send()
        {
            client.Credentials = new System.Net.NetworkCredential("t108458055@gmail.com","26410357592");
            client.EnableSsl = true;
            client.Send(mail);
            return true;
        }
        public void CreateMail(string[] to,string subject,string body)
        {
            var mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("t108458055@gmail.com");
            foreach (var item in to)
            {
                mail.To.Add(item);
            }
            mail.Subject = subject;
            mail.Body = body;
            this.mail = mail;
        }
    }
}
