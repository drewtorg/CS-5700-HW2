using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public enum LicenseType { Annual, OneDay };

    public class Racer : Subject
    {

        public string Name { get; private set; }
        public DateTime DOB { get; private set; }
        public int Bib { get; private set; }

        
        public Racer(string name, DateTime dob, int bib)
        {
            Name = name;
            DOB = dob;
            Bib = bib;
        }
    }
}
