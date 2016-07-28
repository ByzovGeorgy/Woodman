using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Texture
    {
        public abstract string name { get; }
        public virtual int Metric()
        {
            return 0;
        }

        public virtual bool CanCreate()
        {
            return true;
        }
        public abstract Texture ReturnTexture();
        public abstract bool Go();
        public abstract string GetName();
    }
}
