using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public interface Sender
    {
        void Send(string to, string message);
    }
}
