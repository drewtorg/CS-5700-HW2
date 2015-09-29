﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class BigScreenObserver : RacerObserver
    {
        private BigScreenForm form;

        public BigScreenObserver(BigScreenForm form)
        {
            this.form = form;
            form.Show();
        }

        public override void Update(Racer racer)
        {
            form.Update(racer);
        }
    }
}
