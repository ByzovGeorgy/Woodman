using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace ConsoleApplication1
{
    public abstract class CommandMove
    {
        public abstract Vector Direction();
    }
    public class Down : CommandMove
    {
        public override Vector Direction()
        {
            return new Vector(1, 0);
        }

    }
    public class Up : CommandMove
    {
        public override Vector Direction()
        {
            return new Vector(-1, 0);
        }
    }
    public class Right : CommandMove
    {
        public override Vector Direction()
        {
            return new Vector(0, 1);
        }
    }
    public class Left : CommandMove
    {
        public override Vector Direction()
        {
            return new Vector(0, -1);
        }
    }
}
