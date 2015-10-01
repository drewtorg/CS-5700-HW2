using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public interface IObserver
    {
        void Update(ISubject subject);
        void Remove(ISubject subject);
    }
}
