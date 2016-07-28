using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    public class MapLoader
    {
        private Dictionary<char, Texture> TextureCollection;
        private string Path;
        public List<List<Texture>> Map { get; private set; }


        public void Load(string pathInFile)
        {
            TextureCollection = new Dictionary<char, Texture>();

            Path = pathInFile;
            StreamReader();
        }
        private void StreamReader()
        {
            TextureCollection.Add('0', new Pathway());
            TextureCollection.Add('1', new Wood());
            TextureCollection.Add('K', new Trap());
            TextureCollection.Add('L', new Life());
            string str;
            StreamReader sr = new StreamReader(Path);
            Map = new List<List<Texture>>();
            for (int i = 0; !sr.EndOfStream; i++)
            {
                Map.Add(new List<Texture>());
                str = sr.ReadLine();
                for (int j = 0; j < str.Length; j++)
                {
                    if (!TextureCollection.ContainsKey(str[j]))
                    {
                        Map[i].Add(new Wood());
                        continue;
                    }
                    Map[i].Add(TextureCollection[str[j]]);
                }
            }
            if (Map.Count == 0)
                throw new Exception("Карта пустая");
        }
    }
}
