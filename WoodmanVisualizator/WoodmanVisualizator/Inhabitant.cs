using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WoodmanServer;

namespace ConsoleApplication1
{
    public class Inhabitant:Texture
    {
        public Vector Location { get;private set; }
        public int Lifes { get; private set; }
        public string Name { get; private set; }
        public Inhabitant(string name, int life)
        {
           this.Name = name;
            Lifes = life;
        
        }
        public Texture LastTexture { get; private set; }
        public bool Last(Texture texture)
        {
            LastTexture = texture.ReturnTexture();
            return true;
        }
        public void Change(Vector vector, int life)
        {
            Location = vector;
            Lifes += life;
        }
        public void Print()
        {
            Console.WriteLine(Location.ToString() + " Life = " + Lifes.ToString());
        }

        public override Texture ReturnTexture()
        {
            return this;
        }

        public override bool Go()
        {
            return false;
        }        
        public override string GetName()
        {
            //if (Forest.Inhabitants.Contains(this))
                return Name;
            //return LastTexture.GetName();
        }

        public Texture GetLastTexture()
        {
            return LastTexture;
        }

        public override string name
        {
            get { return Name; }
        }

        public override bool CanCreate()
        {
            return false;
        }       
    }

    
}
