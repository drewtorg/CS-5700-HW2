using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public enum LicenseType { Annual, OneDay };

    public class Racer : ISubject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Bib { get; set; }
        public int GroupID { get; set; }
        public double Location { get; set; }
        public DateTime LastSeen { get; set; }
        public DateTime EndTime { get; set; }
        public List<IObserver> Observers { get; private set; }

        public Racer(string firstName, string lastName, int bib, int groupId)
        {
            Observers = new List<IObserver>();
            FirstName = firstName;
            LastName = lastName;
            GroupID = groupId;
            Location = 0;
            Bib = bib;
        }

        public void UpdateLocation(double loc, DateTime timestamp)
        {
            Location = loc;
            LastSeen = timestamp;
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }

        public void Subscribe(IObserver observer)
        {
            if (observer != null && !Observers.Contains(observer))
                Observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observer != null && Observers.Contains(observer))
            {
                Observers.Remove(observer);
                ((RacerObserver)observer).Remove(this);
            }
        }

        public void Notify()
        {
            UpdateLocation(Location, LastSeen);
        }

        public override string ToString()
        {
            return string.Format("#{0}, Group {1}: {2} {3} at {4} miles at {5}", Bib, GroupID, FirstName, LastName, Location, LastSeen.ToLongTimeString());
        }
    }
}
