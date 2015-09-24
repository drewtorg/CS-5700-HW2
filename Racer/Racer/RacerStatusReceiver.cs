using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Messages;

namespace Racer
{
    public class RacerStatusReceiver
    {
        private UdpClient client;
        private RaceManager manager;

        public RacerStatusReceiver(int port, RaceManager manager)
        {
            client = new UdpClient(port);
            this.manager = manager;
        }

        public void ReceiveData()
        {
            while (true)                            // This is not a good loop termination condition, but this is Dummy Server!
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                byte[] messageByes = client.Receive(ref ep);
                if (messageByes != null)
                {
                    RacerStatus statusMessage = RacerStatus.Decode(messageByes);
                    if (statusMessage != null)
                    {
                        manager.UpdateStatus(statusMessage);
                    }
                }
            }
        }

        public void ReceiveCallback(IAsyncResult result)
        {

        }
    }
}
