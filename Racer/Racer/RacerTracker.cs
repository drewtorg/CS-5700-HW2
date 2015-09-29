using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class RacerTracker : IObservable<Racer>
    {
        public List<IObserver<Racer>> Observers { get; private set; }
        public Racer Racer { get; private set; }

        public RacerTracker(Racer r)
        {
            Racer = r;
            Observers = new List<IObserver<Racer>>();
        }

        public void UpdateLocation(double loc, DateTime timestamp)
        {
            Racer.Location = loc;
            Racer.LastSeen = timestamp;
            foreach (var observer in Observers)
            {
                observer.OnNext(Racer);
            }
        }

        public IDisposable Subscribe(IObserver<Racer> observer)
        {
            if (!Observers.Contains(observer))
                Observers.Add(observer);
            return new Unsubscriber(Observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Racer>> _observers;
            private IObserver<Racer> _observer;

            public Unsubscriber(List<IObserver<Racer>> observers, IObserver<Racer> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
