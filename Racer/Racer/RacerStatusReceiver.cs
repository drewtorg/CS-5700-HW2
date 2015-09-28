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
        private bool done;

        public RacerStatusReceiver(int port, RaceManager manager)
        {
            client = new UdpClient(port);
            this.manager = manager;
        }

        public void StopReceiving()
        {
            done = true;
            client.Close();
        }

        public void ReceiveData()
        {
            client.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }

        public void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

                byte[] messageByes = client.EndReceive(result, ref ep);

                if (messageByes != null)
                {
                    RacerStatus statusMessage = RacerStatus.Decode(messageByes);
                    if (statusMessage != null)
                    {
                        manager.UpdateStatus(statusMessage);
                    }
                }

                if (!done)
                    ReceiveData();
            }
            catch (Exception e)
            { }

        }
    }
}
