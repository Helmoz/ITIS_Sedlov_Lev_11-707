using System;
using System.Threading;

namespace NuclearPowerPlant
{
    public class NuclearPp
    {
        private Reactor Reactor1 { get; set; }
        private Reactor Reactor2 { get; set; }
        
        public event EventHandler Explosion;

        protected virtual void OnExplosion(object sender, EventArgs args) => Explosion?.Invoke(sender, new EventArgs());

        public NuclearPp()
        {
            Reactor1 = new Reactor(1, 1000, 1600);
            Reactor2 = new Reactor(2, 900, 1600);
            Reactor1.Explosion += OnExplosion;
            Reactor2.Explosion += OnExplosion;
        }

        public void Work()
        {
            var rand = new Random();
            var t1 = new Thread(() => Reactor1.Work(rand));
            var t2 = new Thread(() => Reactor2.Work(rand));

            t1.Priority = ThreadPriority.Highest;
            t1.Start();
            t2.Start();
        }
    }
}