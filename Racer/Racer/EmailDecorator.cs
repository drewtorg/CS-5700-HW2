using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class EmailDecorator : EmailSender
    {
        protected EmailSender next;

        public EmailDecorator(EmailSender next)
        {
            this.next = next;
        }
    }
}
