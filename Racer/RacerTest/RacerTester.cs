using System;
using Racer;
using NUnit.Framework;

namespace RacerTest
{
    [TestFixture]
    public class RacerTester
    {
        [TestCase]
        public void TestUpdateLocation()
        {
            Racer.Racer r = new Racer.Racer("Drew", "Torgeson", 1, 1);

            int location = 5;
            DateTime time = DateTime.Now;

            r.UpdateLocation(5, time);

            Assert.That(r.Location, Is.EqualTo(location));
            Assert.That(r.LastSeen, Is.EqualTo(time));
        }

        [TestCase]
        public void TestSubscribe()
        {
            Racer.Racer r = new Racer.Racer("Drew", "Torgeson", 1, 1);

            RacerObserver observer = new RacerObserver();

            r.Subscribe(observer);
            Assert.That(r.Observers.Contains(observer), Is.True);
            
            Assert.DoesNotThrow(() => r.Subscribe(null));
        }

        [TestCase]
        public void TestUnsubscribe()
        {
            Racer.Racer r = new Racer.Racer("Drew", "Torgeson", 1, 1);

            RacerObserver observer1 = new RacerObserver();
            RacerObserver observer2 = new RacerObserver();
            RacerObserver observer3 = new RacerObserver();

            r.Subscribe(observer1);
            r.Subscribe(observer2);

            Assert.DoesNotThrow(() => r.Unsubscribe(null));
            Assert.DoesNotThrow(() => r.Unsubscribe(observer3));

            r.Unsubscribe(observer1);
            Assert.That(r.Observers.Contains(observer1), Is.Not.True);
        }
    }
}
