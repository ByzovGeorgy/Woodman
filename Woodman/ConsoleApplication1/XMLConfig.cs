using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public static class XmlLoader
    {
        private static readonly XmlSerializer forestFormatter = new XmlSerializer(typeof(Forest), new[] { typeof(Wood), typeof(Trap), typeof(Inhabitant), typeof(Life), typeof(Pathway) });
        public static void SaveData(string path, Forest forest)
        {

                using (var fs = new FileStream(path, FileMode.Create))
                {
                    forestFormatter.Serialize(fs, forest);
                }
        }
        public static Forest DeserializeForest(string path)
        {
            Forest forest;
            using (var fs = new FileStream(path, FileMode.Open))
                forest = (Forest)forestFormatter.Deserialize(fs);
            return forest;
        }
    }
}
