using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Inhabitant Thronduil = new Inhabitant("Thronduil", 4);
            Forest woodman = new Forest("1.txt", new Vector(1, 1));
            woodman.OnEvent += Visualization.Draw;          
            ServerVisualizator server=new ServerVisualizator();
            woodman.SendVisualizate += server.SendMessage; 
            woodman.CreateInhabitant(Thronduil,new Vector(1,3));
            ConfigFile config=new ConfigFile();
            config.SaveForest("config.txt",woodman);
            XmlLoader.SaveData("conf.txt",woodman);
            //Forest forest = config.LoadForest("config.txt");
            ServerAi ai = new ServerAi(woodman);
            woodman.ClientAi += ai.ChangeMessage;
            ai.ChangeMessage();
            //Ai bot=new Ai(Thronduil,woodman);
            //Console.WriteLine( bot.FindWay());
            Console.ReadKey();
        }
    }
}
