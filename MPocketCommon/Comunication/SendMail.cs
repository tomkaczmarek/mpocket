using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MPocketCommon.Comunication
{
    public class SendMail : ISend
    {
        public void Send(Mail mail)
        {
           
            var fromAddress = new MailAddress("regeekgames@wp.pl", "from");
            var toAddress = new MailAddress(mail.To, "to");


            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.wp.pl",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Port = 465,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("regeekgames", "parasite1234"),
                Timeout = 40000               
            };

            using (var message = new MailMessage(fromAddress, toAddress) {Subject = mail.Subject, Body = mail.Body })
            {
                client.Send(message);
            }           

        }
    }
}
