using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Newtonsoft.Json;
using WoodmanServer;

namespace WoodmanVisualizator
{
    class Program
    {
        public static Socket ClientSocket=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            
            Client client=new Client();
            client.ReceiveMessage();
            Console.ReadKey();
        }
    }
}
