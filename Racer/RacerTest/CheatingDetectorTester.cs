using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Racer;

namespace RacerTest
{
    [TestFixture]
    public class CheatingDetectorTester
    {
        [TestCase]
        public void TestCheaters()
        {
            CheatingDetector detector = new CheatingDetector("Test");

            Racer.Racer prevRacer = new Racer.Racer("Test", "Test", 1, 1);
            prevRacer.Location = 10;
            prevRacer.LastSeen = DateTime.Now;

            Racer.Racer prevRacer2 = new Racer.Racer("Test", "Test", 1, 2);
            prevRacer2.Location = 10;
            prevRacer2.LastSeen = DateTime.Now;

            Racer.Racer r = new Racer.Racer("Test", "Test", 1, 1);
            Racer.Racer r2 = new Racer.Racer("Test", "Test", 1, 2);


            r.Location = 15;
            r2.Location = 15;
            r.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(2);
            r2.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(3);

            Assert.That(detector.AreCheating(r, r2, prevRacer, prevRacer2), Is.True);
        }

        [TestCase]
        public void TestNotCheatersLocation()
        {
            CheatingDetector detector = new CheatingDetector("Test");

            Racer.Racer prevRacer = new Racer.Racer("Test", "Test", 1, 1);
            prevRacer.Location = 10;
            prevRacer.LastSeen = DateTime.Now;

            Racer.Racer prevRacer2 = new Racer.Racer("Test", "Test", 1, 2);
            prevRacer2.Location = 10;
            prevRacer2.LastSeen = DateTime.Now;

            Racer.Racer r = new Racer.Racer("Test", "Test", 1, 1);
            Racer.Racer r2 = new Racer.Racer("Test", "Test", 1, 2);


            r.Location = 15;
            r2.Location = 16;
            r.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(2);
            r2.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(3);

            Assert.That(detector.AreCheating(r, r2, prevRacer, prevRacer2), Is.False);
        }

        [TestCase]
        public void TestNotCheatersGroup()
        {
            CheatingDetector detector = new CheatingDetector("Test");

            Racer.Racer prevRacer = new Racer.Racer("Test", "Test", 1, 1);
            prevRacer.Location = 10;
            prevRacer.LastSeen = DateTime.Now;

            Racer.Racer prevRacer2 = new Racer.Racer("Test", "Test", 1, 1);
            prevRacer2.Location = 10;
            prevRacer2.LastSeen = DateTime.Now;

            Racer.Racer r = new Racer.Racer("Test", "Test", 1, 1);
            Racer.Racer r2 = new Racer.Racer("Test", "Test", 1, 1);


            r.Location = 15;
            r2.Location = 15;
            r.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(2);
            r2.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(3);

            Assert.That(detector.AreCheating(r, r2, prevRacer, prevRacer2), Is.False);
        }

        [TestCase]
        public void TestNotCheatersTime()
        {
            CheatingDetector detector = new CheatingDetector("Test");

            Racer.Racer prevRacer = new Racer.Racer("Test", "Test", 1, 1);
            prevRacer.Location = 10;
            prevRacer.LastSeen = DateTime.Now;

            Racer.Racer prevRacer2 = new Racer.Racer("Test", "Test", 1, 2);
            prevRacer2.Location = 10;
            prevRacer2.LastSeen = DateTime.Now;

            Racer.Racer r = new Racer.Racer("Test", "Test", 1, 1);
            Racer.Racer r2 = new Racer.Racer("Test", "Test", 1, 2);


            r.Location = 15;
            r2.Location = 15;
            r.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(2);
            r2.LastSeen = prevRacer.LastSeen + TimeSpan.FromSeconds(6);

            Assert.That(detector.AreCheating(r, r2, prevRacer, prevRacer2), Is.False);
        }
    }
}
