﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class FooterSender : EmailDecorator
    {
        private string footer;

        public FooterSender(string footer, EmailSender next = null) : base(next)
        {
            this.footer = footer;
        }

        public override string AppendMessage(string message)
        {
            if(Next != null)
                return Next.AppendMessage(message) + "\n\n" + footer;
            return message + "\n\n" + footer;
        }
    }
}
