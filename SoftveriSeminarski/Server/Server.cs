using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Server
{
    public class Server
    {
        Socket soket;
        Socket klijent;
        NetworkStream tok;
        public bool pokreniServer()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                EndPoint ep = new IPEndPoint(IPAddress.Any, 10000);
                soket.Bind(ep);
                

                ThreadStart ts = osluskuj;
                Thread nit = new Thread(ts);
                nit.Start();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool zaustaviServer()
        {
            try
            {
                soket.Close();
                if(klijent!=null)
                {
                    klijent.Disconnect(false);
                    tok.Dispose();
                }
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void osluskuj()
        {
            try
            {
                soket.Listen(7);
                while(true)
                {
                    klijent=soket.Accept();
                    tok = new NetworkStream(klijent);
                    new Obrada(tok);

                }
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Server zaustavljen.");
            }
        }
    }
}
