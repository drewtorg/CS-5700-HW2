using System;
using Racer;
using NUnit.Framework;

namespace RacerTest
{
    [TestFixture]
    public class RacerObserverTester
    {
        [TestCase]
        public void TestUpdate()
        {
            Racer.Racer r = new Racer.Racer("Drew", "Torgeson", 1, 1);
            RacerObserver observer = new RacerObserver();

            observer.Update(r);
            Assert.That(observer.Racers[r.Bib], Is.EqualTo(r));
            
            Assert.DoesNotThrow(() => observer.Update(null));

            r.GroupID = 2;
            observer.Update(r);
            Assert.That(observer.Racers[r.Bib].GroupID, Is.EqualTo(r.GroupID));
        }

        [TestCase]
        public void TestRemove()
        {
            Racer.Racer r1 = new Racer.Racer("Drew", "Torgeson", 1, 1);
            Racer.Racer r2 = new Racer.Racer("Drew", "Torgeson", 2, 1);
            Racer.Racer r3 = new Racer.Racer("Drew", "Torgeson", 3, 1);
            Racer.Racer r4 = new Racer.Racer("Drew", "Torgeson", 4, 1);
            RacerObserver observer = new RacerObserver();

            observer.Racers.Add(r1.Bib, r1);
            observer.Racers.Add(r2.Bib, r2);
            observer.Racers.Add(r3.Bib, r3);

            observer.Remove(r4);
            Assert.That(observer.Racers.Count, Is.EqualTo(3));
            Assert.That(observer.Racers.ContainsValue(r4), Is.EqualTo(false));

            observer.Remove(r3);
            Assert.That(observer.Racers.Count, Is.EqualTo(2));
            Assert.That(observer.Racers.ContainsValue(r3), Is.EqualTo(false));
            
            Assert.DoesNotThrow(() => observer.Remove(null));
        }
    }
}
