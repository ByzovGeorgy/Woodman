using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Inhabitant : Texture,Inhhh
    {
        public Vector Location { get; private set; }
        private int lifes;
        public string Name { get; private set; }
        public Inhabitant(string name, int life)
        {
            this.Name = name;
            lifes = life;

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

        public int Lifes
        {
            get { return lifes; }
        }
    }
    public interface Inhhh
    {
        int Lifes { get; }

    }
}
