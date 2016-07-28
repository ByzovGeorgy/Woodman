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
        private static int count = 48;
        private static Dictionary<string, string> texturesOnMap;
        private static Dictionary<string, string> decodeTextures;
        public static void Draw(List<Texture> textures,List<Inhabitant> inh,Forest forest)
        {
            XaXa(textures,inh);
            for (int i = 0; i < forest.map.Count; i++)
            {
                for (int j = 0; j < forest.map[i].Count; j++)
                {
                    Console.Write(texturesOnMap[forest.map[i][j].GetName()]);
                }
                Console.WriteLine();
            }
            foreach (var decodeTexture in decodeTextures)
            {
                Console.WriteLine(decodeTexture.Value);
            }
            Console.ReadKey();
            Thread.Sleep(100);
            Console.Clear();
        }

        private static void XaXa(List<Texture> textures,List<Inhabitant> inh)
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
            for (int i = 4; i < textures.Count; i++)
            {
                texturesOnMap.Add(inh[i - 4].GetName(), char.ConvertFromUtf32(count));
                decodeTextures.Add(texturesOnMap[textures[i].GetName()],
                    string.Format("{0} - Лесной житель {1} ({2} жизни)", texturesOnMap[textures[i].GetName()], textures[i].GetName(), inh[i - 4].Lifes));
                count++;
            }
            count = 48;
        }
    }
}
