using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Wood : Texture
    {
        
        public override Texture ReturnTexture()
        {
            return new Wood();
        }
        public override bool Go()
        {
            return false;
        }
        public override string GetName()
        {
            return "Wood";
        }


        public override string name
        {
            get { return GetName(); }
        }

        public override bool CanCreate()
        {
            return false;
        }
    }
}
