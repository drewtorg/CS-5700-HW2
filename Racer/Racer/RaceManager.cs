using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Messages;

namespace Racer
{
    public class RaceManager
    {
        public Dictionary<int, RaceGroup> Groups { get; private set; }
        public Dictionary<int, Racer> Racers { get; private set; }
        public Dictionary<int, Sensor> Sensors { get; private set; }
        public List<RacerObserver> Observers { get; set; }

        private RacerStatusReceiver receiver;
        private const string groupFile = @"../../../SensorSimulator/bin/Debug/Group.csv";
        private const string racerFile = @"../../../SensorSimulator/bin/Debug/Racers.csv";
        private const string sensorFile = @"../../../SensorSimulator/bin/Debug/Sensor.csv";

        public RaceManager()
        {
            Groups = ReadGroups(groupFile);
            Racers = ReadRacers(racerFile);
            Sensors = ReadSensors(sensorFile);
            receiver = new RacerStatusReceiver(14000, this);
            Observers = new List<RacerObserver>();
        }

        public void Start()
        {
            receiver.ReceiveData();
        }

        public void Stop()
        {
            receiver.StopReceiving();
        }

        public void UpdateStatus(RacerStatus status)
        {
            Sensor sensor = Sensors[status.SensorId];
            Racer racer = Racers[status.RacerBibNumber];
            DateTime timestamp = new DateTime(status.Timestamp);

            racer.UpdateLocation(sensor.Location, timestamp);
        }

        public void AddObserver(RacerObserver observer)
        {
            if(!Observers.Contains(observer))
                Observers.Add(observer);
        }

        public void RemoveObserver(RacerObserver observer)
        {
            if (Observers.Contains(observer))
                Observers.Remove(observer);
        }

        private Dictionary<int, RaceGroup> ReadGroups(string filename)
        {
            Dictionary<int, RaceGroup> groups = new Dictionary<int, RaceGroup>();
            using (StreamReader reader = File.OpenText(filename))
            {
                string all = reader.ReadToEnd();
                foreach (var line in all.Split('\n'))
                {
                    if (line != "")
                    {
                        string[] pieces = line.Split(',');
                        int id, blockMin, blockMax, timestamp;

                        if (!Int32.TryParse(pieces[0], out id))
                            throw new FormatException("Expected integer id but found non-integer value");
                        if (!Int32.TryParse(pieces[3], out blockMin))
                            throw new FormatException("Expected integer block min but found non-integer value");
                        if (!Int32.TryParse(pieces[4], out blockMax))
                            throw new FormatException("Expected integer block max but found non-integer value");
                        if (!Int32.TryParse(pieces[2], out timestamp))
                            throw new FormatException("Expected integer timestamp but found non-integer value");

                        string label = pieces[1];
                        DateTime startTime = new DateTime(timestamp);

                        groups.Add(id, new RaceGroup(id, label, blockMin, blockMax, startTime));
                    }
                }
            }
            return groups;
        }

        private Dictionary<int, Racer> ReadRacers(string filename)
        {
            Dictionary<int, Racer> racers = new Dictionary<int, Racer>();
            using (StreamReader reader = File.OpenText(filename))
            {
                string all = reader.ReadToEnd();
                foreach (var line in all.Split('\n'))
                {
                    if (line != "")
                    {
                        string[] pieces = line.Split(',');
                        int groupId, bib;

                        if (!Int32.TryParse(pieces[2], out bib))
                            throw new FormatException("Expected integer bib number but found non-integer value");
                        if (!Int32.TryParse(pieces[3], out groupId))
                            throw new FormatException("Expected integer group id but found non-integer value");

                        string first = pieces[0];
                        string last = pieces[1];
                        
                        Racer racer = new Racer(first, last, bib, groupId);
                        if (!racers.ContainsKey(bib))
                        {
                            racers.Add(bib, racer);
                            Groups[groupId].AddRacer(racer);
                        }
                    }
                }
            }
            return racers;
        }

        private Dictionary<int, Sensor> ReadSensors(string filename)
        {
            Dictionary<int, Sensor> sensors = new Dictionary<int, Sensor>();
            using (StreamReader reader = File.OpenText(filename))
            {
                string all = reader.ReadToEnd();
                foreach (var line in all.Split('\n'))
                {
                    if (line != "")
                    {
                        string[] pieces = line.Split(',');
                        int id, location;

                        if (!Int32.TryParse(pieces[0], out id))
                            throw new FormatException("Expected integer id number but found non-integer value");
                        if (!Int32.TryParse(pieces[1], out location))
                            throw new FormatException("Expected integer location but found non-integer value");

                        sensors.Add(id, new Sensor(id, location));
                    }
                }
            }
            return sensors;
        }
    }
}
