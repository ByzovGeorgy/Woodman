using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Inhabitant : Texture
    {
        public Vector Location { get;  set; }
        private int lifes;
        public string Name { get; set; }
        public Inhabitant(string name, int life)
        {
            this.Name = name;
            lifes = life;
        }
        public Inhabitant()
        { }
        public Texture LastTexture { get; set; }
        public bool Last(Texture texture)
        {
            LastTexture = texture.ReturnTexture();
            return true;
        }
        public void Change(Vector vector, int life)
        {
            Location = vector;
            lifes += life;
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
            return Name;
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

        public int Lifes
        {
            get { return lifes; }
            set { lifes = value; }
        }
    }
}
