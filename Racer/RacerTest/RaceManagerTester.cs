using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using System.IO;
using Racer;

namespace RacerTest
{
    [TestFixture]
    public class RaceManagerTester
    {
        RaceManager manager;

        const string testRacerString = "Test First Name 1.0,Test Last Name 1.0,1,1\nTest First Name 1.1,Test Last Name 1.1,2,1\nTest First Name 1.2,Test Last Name 1.2,3,1";
        const string testGroupString = "1,Mens Cat 1-2,0,1,99\n2,Womens Cat 1-3,300000,100,199\n3,Womens Cat 4,600000,200,299";
        const string testSensorString = "0,5\n1,10\n2,15";

        const string testBadRacerString = "Test First Name 1.0,Test Last Name 1.0,1,1\nTest First Name 1.1,Test Last Name 1.1,Two,1\nTest First Name 1.2,Test Last Name 1.2,3,1";
        const string testBadGroupString = "1,Mens Cat 1-2,0,One,99\n2,Womens Cat 1-3,300000,100,199\n3,Womens Cat 4,600000,200,299";
        const string testBadSensorString = "Zero,5\n1,10\n2,15";

        [TestFixtureSetUp]
        public void SetUp()
        {

            File.WriteAllText("testRacer.csv", testRacerString);
            File.WriteAllText("testGroup.csv", testGroupString);
            File.WriteAllText("testSensor.csv", testSensorString);

            File.WriteAllText("testBadRacer.csv", testBadRacerString);
            File.WriteAllText("testBadGroup.csv", testBadGroupString);
            File.WriteAllText("testBadSensor.csv", testBadSensorString);

            manager = new RaceManager("testGroup.csv", "testRacer.csv", "testSensor.csv");
        }

        [TestCase]
        public void TestReadGroups()
        {
            Dictionary<int, RaceGroup> expected = new Dictionary<int, RaceGroup>();
            expected.Add(1, new RaceGroup(1, "Mens Cat 1-2", 1, 99, new DateTime(0)));
            expected.Add(2, new RaceGroup(2, "Womens Cat 1-3", 100, 199, new DateTime(300000)));
            expected.Add(3, new RaceGroup(3, "Womens Cat 4", 200, 299, new DateTime(600000)));

            Assert.That(expected.Count, Is.EqualTo(manager.Groups.Count));
            foreach (var group in manager.Groups.Values)
            {
                Assert.That(expected[group.ID].ID, Is.EqualTo(group.ID));
                Assert.That(expected[group.ID].Label, Is.EqualTo(group.Label));
                Assert.That(expected[group.ID].BlockMax, Is.EqualTo(group.BlockMax));
                Assert.That(expected[group.ID].BlockMin, Is.EqualTo(group.BlockMin));
                Assert.That(expected[group.ID].StartTime, Is.EqualTo(group.StartTime));
            }
        }

        [TestCase]
        public void TestReadSensors()
        {
            Dictionary<int, Sensor> expected = new Dictionary<int, Sensor>();
            expected.Add(0, new Sensor(0, 5));
            expected.Add(1, new Sensor(1, 10));
            expected.Add(2, new Sensor(2, 15));

            Assert.That(expected.Count, Is.EqualTo(manager.Sensors.Count));
            foreach (var sensor in manager.Sensors.Values)
            {
                Assert.That(expected[sensor.ID].ID, Is.EqualTo(sensor.ID));
                Assert.That(expected[sensor.ID].Location, Is.EqualTo(sensor.Location));
            }
        }

        [TestCase]
        public void TestReadRacers()
        {
            Dictionary<int, Racer.Racer> expected = new Dictionary<int, Racer.Racer>();
            expected.Add(1, new Racer.Racer("Test First Name 1.0", "Test Last Name 1.0", 1, 1));
            expected.Add(2, new Racer.Racer("Test First Name 1.1", "Test Last Name 1.1", 2, 1));
            expected.Add(3, new Racer.Racer("Test First Name 1.2", "Test Last Name 1.2", 3, 1));

            Assert.That(expected.Count, Is.EqualTo(manager.Racers.Count));
            foreach (var racer in manager.Racers.Values)
            {
                Assert.That(expected[racer.Bib].Bib, Is.EqualTo(racer.Bib));
                Assert.That(expected[racer.Bib].FirstName, Is.EqualTo(racer.FirstName));
                Assert.That(expected[racer.Bib].LastName, Is.EqualTo(racer.LastName));
                Assert.That(expected[racer.Bib].GroupID, Is.EqualTo(racer.GroupID));
            }
        }

        [TestCase]
        public void TestBadReadGroups()
        {
            Assert.Throws<FormatException>(() => new RaceManager("testBadGroup.csv", "testRacer.csv", "testSensor.csv"));
        }

        [TestCase]
        public void TestBadReadRacers()
        {
            Assert.Throws<FormatException>(() => new RaceManager("testGroup.csv", "testBadRacer.csv", "testSensor.csv"));
        }

        [TestCase]
        public void TestBadReadSensors()
        {
            Assert.Throws<FormatException>(() => new RaceManager("testGroup.csv", "testRacer.csv", "testBadSensor.csv"));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            File.Delete("testRacer.csv");
            File.Delete("testGroup.csv");
            File.Delete("testSensor.csv");

            File.Delete("testBadRacer.csv");
            File.Delete("testBadGroup.csv");
            File.Delete("testBadSensor.csv");
        }
    }
}
