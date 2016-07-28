using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pathway : Texture
    {
        public override string name
        {
            get { return GetName(); }
        }

        public override Texture ReturnTexture()
        {
            return new Pathway();
        }

        public override bool Go()
        {
            return true;
        }
        public override string GetName()
        {
            return "Pathway";
        }
    }
}
