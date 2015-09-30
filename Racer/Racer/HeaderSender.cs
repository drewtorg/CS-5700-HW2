using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class HeaderSender : EmailDecorator
    {
        private string header;

        public HeaderSender(string header, EmailSender next = null) : base(next)
        {
            this.header = header;
        }

        public override string AppendMessage(string message)
        {
            if(Next != null)
                return header + "\n\n" + Next.AppendMessage(message);
            return header + "\n\n" + message;
        }
    }
}
