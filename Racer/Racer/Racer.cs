using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public enum LicenseType { Annual, OneDay };

    public class Racer
    {
        public string Name { get; private set; }
        public DateTime DOB { get; private set; }
        public int Bib { get; set; }
        public double Location { get; set; }
        
        public Racer(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
            Bib = -1;
        }
    }
}
