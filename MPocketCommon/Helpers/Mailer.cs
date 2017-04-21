using MPocketCommon.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPocketCommon.Helpers
{
    public class Mailer
    {
        private ISend _send;
        public Mail Mail { get; set; }

        public Mailer(ISend sender, Mail mail)
        {
            _send = sender;
            Mail = mail;
            
        }

        public void Send()
        {
            _send.Send(Mail);
        }
    }
}
