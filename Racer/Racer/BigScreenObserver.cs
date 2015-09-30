using System;
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
            this.form.Observer = this;
            form.Show();
        }

        public override void Update(ISubject subject)
        {
            base.Update(subject);
            Racer racer = subject as Racer;
            form.Update(racer);
        }
    }
}
