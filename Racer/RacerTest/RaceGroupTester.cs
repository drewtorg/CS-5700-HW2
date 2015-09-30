using Racer;
using NUnit.Framework;
using System;

namespace RacerTest
{
    [TestFixture]
    public class RaceGroupTester
    {
        [TestCase]
        public void TestAddRacer()
        {
            RaceGroup group = new RaceGroup(1, "TestGroup", 0, 100, DateTime.Now);

            Assert.DoesNotThrow(() => group.AddRacer(null));

            Racer.Racer r = new Racer.Racer("Drew", "Torgeson", 0, group.ID);
            group.AddRacer(r);
            Assert.That(group.Racers[0], Is.EqualTo(r));

            Racer.Racer r1 = new Racer.Racer("Drew", "Torgeson", 0, group.ID);
            group.AddRacer(r1);
            Assert.That(group.Racers[0], Is.EqualTo(r));

            for (int i = 1; i < 99; i++)
                group.AddRacer(new Racer.Racer("Drew", "Torgeson", i, group.ID));

            Racer.Racer r2 = new Racer.Racer("Drew", "Torgeson", 1000, group.ID);
            group.AddRacer(r2);

            Assert.That(group.Racers.TryGetValue(1000, out r2), Is.False);

            Racer.Racer r3 = new Racer.Racer("Drew", "Torgeson", 1000, group.ID);
            group.AddRacer(r3);

            Assert.That(group.Racers.TryGetValue(-1000, out r3), Is.False);

            Racer.Racer r4 = new Racer.Racer("Drew", "Torgeson", 99, group.ID - 1);
            group.AddRacer(r4);

            Assert.That(group.Racers.TryGetValue(99, out r4), Is.False);

            group.AddRacer(new Racer.Racer("Drew", "Torgeson", 99, group.ID));
            group.AddRacer(new Racer.Racer("Drew", "Torgeson", 100, group.ID));
            group.AddRacer(new Racer.Racer("Drew", "Torgeson", 101, group.ID));

            Assert.That(group.Racers.TryGetValue(100, out r4), Is.False);
            Assert.That(group.Racers.TryGetValue(101, out r4), Is.False);
        }
    }
}
