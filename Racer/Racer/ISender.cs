using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public interface ISender
    {
        void Send(string to, string subject, string message);
    }
}
