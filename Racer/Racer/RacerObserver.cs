using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public abstract class RacerObserver : IObserver<Racer>
    {
        public abstract void Update(Racer racer);
        private IDisposable unsubscriber;

        public void Subscribe(IObservable<Racer> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
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
