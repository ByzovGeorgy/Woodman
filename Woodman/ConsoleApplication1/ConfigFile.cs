using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class ConfigFile
    {
        private JsonSerializerSettings js = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

        public void SaveForest(string path,Forest forest)
        {
            StreamWriter writer=new StreamWriter(path);
            var json =  JsonConvert.SerializeObject(forest, js);
            writer.Write(json);
            writer.Close();
        }

        public Forest LoadForest(string path)
        {
            StreamReader reader=new StreamReader(path);
            var json = reader.ReadToEnd();
            var forest = (Forest) JsonConvert.DeserializeObject(json, js);
            return forest;
        }
    }
}
