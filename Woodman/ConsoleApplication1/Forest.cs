using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

//using Newtonsoft.Json;

namespace ConsoleApplication1
{
    //[DataContract]
    public class Forest
    {
        public Vector Target { get; set; }
        public List<List<Texture>> map = new List<List<Texture>>();
        public List<Inhabitant> Inhabitants { get;  set; }
        public List<Texture> objectList { get;  set; }
        public string Path { get;  set; }
        [JsonConstructor]
        public Forest(string path, Vector target)
        {
            Path = path;
            MapLoader mapLoader = new MapLoader();
            mapLoader.Load(Path);
            map = mapLoader.Map;
            Inhabitants = new List<Inhabitant>();
            objectList = new List<Texture>() { new Pathway(), new Wood(), new Trap(), new Life() };
            Target = target;
            if (OnEvent != null) OnEvent(objectList,Inhabitants,this);
            if (SendVisualizate != null) SendVisualizate(map);
            if (ClientAi != null) ClientAi();
        }
        public Forest() { }
        public Forest(string path)
        {
            Path = path;
            MapLoader mapLoader = new MapLoader();
            mapLoader.Load(Path);
            map = mapLoader.Map;
            Inhabitants = new List<Inhabitant>();
            objectList = new List<Texture>() { new Pathway(), new Wood(), new Trap(), new Life() };
            if (OnEvent != null) OnEvent(objectList,Inhabitants,this);
            if (SendVisualizate != null) SendVisualizate(map);
            if (ClientAi != null) ClientAi();
        }
        private static int count = 48;


        public void CreateInhabitant(Inhabitant inh, Vector location)
        {
            if (!map[location.X][location.Y].CanCreate() || !CheckBolders(location))
                throw new Exception("нельзя создать человека в этом месте");
            Inhabitants.Add(inh);
            count++;
            inh.Last(map[location.X][location.Y]);
            inh.Change(location, 0);
            map[location.X][location.Y] = inh;
            objectList.Add(inh);
            if (OnEvent != null)
            {
                OnEvent(objectList,Inhabitants,this);
            }
            if (SendVisualizate != null) SendVisualizate(map);
            if (ClientAi != null) ClientAi();
        }
        public bool MoveInhabitant(Inhabitant inh, CommandMove move)
        {
            Vector vector = inh.Location.Add(move.Direction());
            if (!Inhabitants.Contains(inh) || !CheckBolders(vector)
                || !map[vector.X][vector.Y].Go())
                return false;
            MoveIsTrue(inh, vector);
            if (OnEvent != null) OnEvent(objectList,Inhabitants,this);
            if (SendVisualizate != null) SendVisualizate(map);
            Console.ReadKey();
            //if (ClientAi != null) ClientAi();
            return true;
        }
        private void MoveIsTrue(Inhabitant inh, Vector vector)
        {
            Texture texture = map[vector.X][vector.Y];
            Vector location = inh.Location;
            map[location.X][location.Y] = inh.GetLastTexture();
            inh.Change(vector, map[vector.X][vector.Y].Metric());
            if (inh.Lifes == 0)
            {
                Inhabitants.Remove(inh);
                objectList.Remove(inh);
                return;
            }
            map[vector.X][vector.Y] = inh;
            map[location.X][location.Y] = inh.LastTexture;
            inh.Last(texture);
        }

        private bool CheckBolders(Vector v)
        {
            return v.X >= 0 && v.Y >= 0 && v.X < map.Count && v.Y < map[v.X].Count;
        }


        public delegate void MethodContainer(List<Texture> textures,List<Inhabitant> inh ,Forest forest);
        public event MethodContainer OnEvent;

        public delegate void MethodVisualization(List<List<Texture>> map);

        public event MethodVisualization SendVisualizate;

        public delegate void MethodAi();

        public event MethodAi ClientAi;
    }

}
