using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class RacerObserver : IObserver
    {
        public string Title { get; set; }
        public Dictionary<int, Racer> Racers{ get; set; }
        public object Lock { get; private set; }

        public RacerObserver(string title = "")
        {
            Title = title;
            Lock = new object();
            Racers = new Dictionary<int, Racer>();
        }

        public virtual void Remove(ISubject subject)
        {
            if (subject != null && subject is Racer)
            {
                lock (Lock)
                {
                    Racer r = subject as Racer;
                    if (Racers.ContainsKey(r.Bib))
                        Racers.Remove(r.Bib);
                }
            }
        }

        public virtual void Update(ISubject subject)
        {
            if (subject != null && subject is Racer)
            {
                lock (Lock)
                {
                    Racer r = subject as Racer;
                    if (!Racers.ContainsKey(r.Bib))
                        Racers.Add(r.Bib, r);
                    else
                        Racers[r.Bib] = r;
                }
            }
        }
    }
}
