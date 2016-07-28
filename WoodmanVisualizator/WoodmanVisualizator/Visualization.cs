using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Visualization
    {
        private static Dictionary<string, string> texturesOnMap;
        private static Dictionary<string, string> decodeTextures;
        public static void Draw(List<List<Texture>> map)
        {
            Console.Clear();
            XaXa(map);
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] is Inhabitant)
                    {
                        Console.Write(map[i][j].GetName()[0]);
                        decodeTextures.Add(map[i][j].GetName()[0].ToString(),
                            string.Format("{0} - Лесной житель {1} ",map[i][j].GetName()[0],map[i][j].GetName()));
                    }
                    else
                        Console.Write(texturesOnMap[map[i][j].GetName()]);
                }
                Console.WriteLine();
            }
            foreach (var decodeTexture in decodeTextures)
            {
                Console.WriteLine(decodeTexture.Value);
            }
        }

        private static void XaXa(List<List<Texture>> map)
        {
            texturesOnMap = new Dictionary<string, string>();
            decodeTextures = new Dictionary<string, string>();
            texturesOnMap.Add(new Pathway().GetName(), " ");
            decodeTextures.Add(texturesOnMap[new Pathway().GetName()],
                string.Format("{0} - Тропинка", texturesOnMap[new Pathway().GetName()]));
            texturesOnMap.Add(new Trap().GetName(), char.ConvertFromUtf32(9650));
            decodeTextures.Add(texturesOnMap[new Trap().GetName()],
                string.Format("{0} - Ловушка", texturesOnMap[new Trap().GetName()]));
            texturesOnMap.Add(new Life().GetName(), char.ConvertFromUtf32(9829));
            decodeTextures.Add(texturesOnMap[new Life().GetName()],
                string.Format("{0} - Жизнь", texturesOnMap[new Life().GetName()]));
            texturesOnMap.Add(new Wood().GetName(), char.ConvertFromUtf32(9632));
            decodeTextures.Add(texturesOnMap[new Wood().GetName()],
                string.Format("{0} - Заросли", texturesOnMap[new Wood().GetName()]));
        }
    }
}
