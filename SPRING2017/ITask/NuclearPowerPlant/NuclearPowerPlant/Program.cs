using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearPowerPlant
{
    class Program
    {
        static void Main(string[] args)
        {
            var npp1 = new NuclearPp();

            var amb = new Ambulance();
            var pol = new Police();
            var fire = new Firefighters();

            npp1.Explosion += amb.Message;
            npp1.Explosion += pol.Message;
            npp1.Explosion += fire.Message;

            npp1.Work();

        }
    }
}
