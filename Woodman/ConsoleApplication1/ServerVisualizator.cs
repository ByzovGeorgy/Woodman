using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class ServerVisualizator
    {
        private Socket server;
        private List<Socket> handler=new List<Socket>();
        public ServerVisualizator()
        {
            try
            {
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(localAddress, 10000);
                server.Bind(ipEndPoint);
                server.Listen(10);
                handler.Add(server.Accept());
                var vis= new Thread(new ThreadStart(ListenConnect));
                vis.Start();
            }
            catch (SocketException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void ListenConnect()
        {
            while (true)
            {
                handler.Add(server.Accept());
            }
        }
        public void SendMessage(List<List<Texture>> map)
        {
            string msg = EncodingMap(map);
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            foreach (var socket in handler)
            {
                socket.Send(msgBytes);
            }
        }

        public string EncodingMap(List<List<Texture>> map)
        {
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            StreamWriter streamWriter = new StreamWriter("2.txt");
            string jj = JsonConvert.SerializeObject(map, jset);
            streamWriter.Write(jj);
            streamWriter.Close();
            string json = JsonConvert.SerializeObject(map, jset);
            List<List<Texture>> tt = (List<List<Texture>>)JsonConvert.DeserializeObject(json, jset);
            return json;
        }
    }
}
