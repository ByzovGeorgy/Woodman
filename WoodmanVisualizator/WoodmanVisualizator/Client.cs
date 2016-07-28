using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Newtonsoft.Json;

namespace WoodmanServer
{
    public class Client
    {
        public static Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void ReceiveMessage()
        {
            string currentTime = "";
            try
            {
                byte[] bytes = new byte[10000];
                ClientSocket.Connect(IPAddress.Loopback, 10000);
                while (true)
                {
                    ClientSocket.Receive(bytes);
                    currentTime = Encoding.UTF8.GetString(bytes);
                    var jset = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All};
                    var kk = currentTime.Replace(" ConsoleApplication1", " WoodmanVisualizator");
                    List<List<Texture>> list = (List<List<Texture>>) JsonConvert.DeserializeObject(kk, jset);
                    Visualization.Draw(list);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("finish or dead");
            }
        }
    }
}
