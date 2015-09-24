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
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DOB { get; private set; }
        public int Bib { get; set; }
        public int GroupID { get; set; }
        public double Location { get; set; }
        public DateTime LastSeen { get; set; }
        
        public Racer(string firstName, string lastName, int bib, int groupId)
        {
            FirstName = firstName;
            LastName = lastName;
            GroupID = groupId;
            Location = 0;
            Bib = bib;
            //DOB = dob;
        }

        public override string ToString()
        {
            return string.Format("#{0}, Group {1}: {2} {3} at {4} miles at {5}", Bib, GroupID, FirstName, LastName, Location, LastSeen.ToLongTimeString());
        }
    }
}
