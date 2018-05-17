using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearPowerPlant
{
    class Ambulance
    {
        public void Message(object sender, EventArgs args)
        {
            Console.WriteLine();
            var reactor = sender as Reactor;
            Console.WriteLine($"Скорая помощь выехала к реактору {reactor.Number}");
        }
    }

    class Police
    {
        public void Message(object sender, EventArgs args)
        {
            var reactor = sender as Reactor;
            Console.WriteLine($"Полиция выехала к реактору {reactor.Number}");
        }
    }

    class Firefighters
    {
        public void Message(object sender, EventArgs args)
        {
            var reactor = sender as Reactor;
            Console.WriteLine($"Пожарные выехали к реактору {reactor.Number}");
            Console.WriteLine();
        }
    }
}
