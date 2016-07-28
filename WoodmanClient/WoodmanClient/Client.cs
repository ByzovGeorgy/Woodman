using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Newtonsoft.Json;

namespace WoodmanClient
{
    public class Client
    {
        public static Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public List<Vector> CreateConnect(string name)
        {
            ClientSocket.Connect(IPAddress.Loopback, 10100);
            string json = JsonConvert.SerializeObject(name);
            string msg = ChangeMessages(json);
            coordinates = (List<Vector>)JsonConvert.DeserializeObject(msg, jset);
            return coordinates;
        }
        private JsonSerializerSettings jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
        private string ChangeMessages(string json)
        {            
            byte[] bytes=new byte[10000];
            bytes = Encoding.UTF8.GetBytes(json);
            ClientSocket.Send(bytes);
            byte[] bytes1 = new byte[10000];
            ClientSocket.Receive(bytes1);
            string currentTime = Encoding.UTF8.GetString(bytes1);
            var kk = currentTime.Replace(" ConsoleApplication1", " WoodmanClient");
            return kk;
        }
        public List<Vector> coordinates;
        public bool ReceiveMessage(CommandMove move)
        {
            string currentTime = "";
            bool isMove=false;
            try
            {
                JsonSerializerSettings js = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All};
                string json = JsonConvert.SerializeObject(move, js);
                string msg = ChangeMessages(json);
                isMove = (bool) JsonConvert.DeserializeObject(msg, jset);
                //move = (bool) JsonConvert.DeserializeObject(msg, jset);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ходьба завершилась");
            }
            return isMove;
        }
    }
}
