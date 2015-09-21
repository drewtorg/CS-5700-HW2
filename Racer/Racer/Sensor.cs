using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class Sensor
    {
        public int ID { get; private set; }
        public double Location { get; private set; }

        public Sensor(int id, double location)
        {
            ID = id;
            Location = location;
        }
    }
}
