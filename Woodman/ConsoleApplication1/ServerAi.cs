using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class ServerAi
    {
        private Socket server;
        private Socket handler;
        private Forest forest;
        private Inhabitant inh;
        public ServerAi(Forest forest)
        {
            this.forest = forest;
            try
            {
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(localAddress, 10100);
                server.Bind(ipEndPoint);
                server.Listen(1);
                handler = server.Accept();
                ChangeFirstMessages();
            }
            catch (SocketException ex)
            {
                
            }
        }

        private void ChangeFirstMessages()
        {
            try
            {
                var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                byte[] bytes = new byte[10000];
                handler.Receive(bytes);
                string encode = Encoding.UTF8.GetString(bytes);
                string msg = (string)JsonConvert.DeserializeObject(encode, jset);
                foreach (var inhabitant in forest.Inhabitants)
                {
                    if (inhabitant.Name == msg)
                    {
                        inh = inhabitant;
                        break;
                    }
                }
                if (inh == null)
                {
                    Console.WriteLine("ЧЕЛОВЕКА С ТАКИМ ИМЕНЕМ НЕ СУЩЕСТВУЕТ");
                    handler.Disconnect(true);
                    return;
                }
                List<Vector> coordinates=new List<Vector>(){inh.Location,forest.Target};
                string json = JsonConvert.SerializeObject(coordinates, jset);
                bytes = Encoding.UTF8.GetBytes(json);
                handler.Send(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                handler.Send(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ReceiveMessage()
        {
            string msg = "";
            try
            {
                byte[] bytes = new byte[200];
                handler.Receive(bytes);
                msg = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return msg;
        }
        public void ChangeMessage()
        {
            try
            {
                while (handler.Connected)
                {


                    var jset = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All};
                    string msg = ReceiveMessage();
                    msg = msg.Replace(" WoodmanClient", " ConsoleApplication1");
                    CommandMove command = (CommandMove) JsonConvert.DeserializeObject(msg, jset);
                    bool move = forest.MoveInhabitant(inh, command);
                    if (inh.Lifes == 0)
                    {
                        handler.Disconnect(true);
                        return;
                    }
                    string sendMessage = JsonConvert.SerializeObject(move, jset);
                    SendMessage(sendMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
