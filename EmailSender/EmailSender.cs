using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using System;

namespace DynamicsEmailSender
{
    public class EmailSender
    {
        public void MailSender(string email,string name, string url, string pris)
        {
            Console.WriteLine("fuck");
            using var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("steammarketagent@gmail.com",
                    "xcuyydbwfweztxti"),
                EnableSsl = true
            };

            SendEmail(client, email, name, url, pris);
            Console.WriteLine("E-mail has been sent");
        }
        public void SendEmail(SmtpClient client, string email, string name, string url, string pris)
        {
            using (var mail = new MailMessage())
            {
                mail.To.Add(new MailAddress(email));
                mail.From = new MailAddress("steammarketagent@gmail.com", "the cowboys");
                mail.Subject = "betaling af kursus";
                mail.Body = "Hej mr/ms:" + " " + name +
                            "<br />"+
                            "<br /> tak fordi du har tilmeldt dig et kursus ved os." + " " +
                            "<br />" +
                            " Prisen på det givede kursus du har tilmeldt dig er  " + pris +
                            "<br /> der ved være vedhæftet et betaling linket til at afslutte din ordre" +
                            "<br />" +
                            "<br /> " + " " + url +
                            "<br />" +
                            "<br />" +
                            "<br /> - MVH The Cowboys";
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
        }


    }
}
