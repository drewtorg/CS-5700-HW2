using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public abstract class RacerObserver : IObserver<Racer>
    {
        private IDisposable unsubscriber;
        public string Title { get; set; }

        public RacerObserver(string title = "")
        {
            Title = title;
        }

        public abstract void Update(Racer racer);
        
        public void Subscribe(IObservable<Racer> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public void Subscribe(RaceGroup group)
        {
            foreach(var racer in group.Racers.Values)
                if (racer != null)
                    unsubscriber = racer.Subscribe(this);
        }

        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Racer value)
        {
            Update(value);
        }
    }
}
