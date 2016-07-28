using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace WoodmanClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Ai ai=new Ai("Thronduil");
            ai.FindWay();
        }
    }
}
