using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class FooterSender
    {
        private string footer;

        public FooterSender(string footer, EmailSender next) : base(next)
        {
            this.footer = footer;
        }
    }
}
