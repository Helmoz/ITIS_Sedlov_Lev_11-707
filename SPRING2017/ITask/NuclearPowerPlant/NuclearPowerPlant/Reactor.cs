using System;
using System.Threading;

namespace NuclearPowerPlant
{
    public class Reactor
    {
        public int CurrentTemperature { get; set; }

        public int CriticalTemperature { get; set; }

        public int Number { get; set; }

        public Reactor(int number, int currentTemperature, int criticalTemperature)
        {
            CurrentTemperature = currentTemperature;
            CriticalTemperature = criticalTemperature;
            Number = number;
        }

        public event EventHandler Explosion;

        protected virtual void OnExplosion(EventArgs args) => Explosion?.Invoke(this, args);

        public void Work(Random rand)
        {
            while (true)
            {
                CurrentTemperature += rand.Next(100, 200);
                Console.WriteLine($"Температура {Number} реактора {CurrentTemperature}");
                Thread.Sleep(300);
                if (CurrentTemperature >= CriticalTemperature)
                {
                    OnExplosion(new EventArgs());
                    break;
                }
                CurrentTemperature -= rand.Next(50, 100);
                Console.WriteLine($"Температура {Number} реактора {CurrentTemperature}");
                Thread.Sleep(300);
            }
        }
    }
}