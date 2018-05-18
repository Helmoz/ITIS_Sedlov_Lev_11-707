namespace NuclearPowerPlant
{
    class Program
    {
        static void Main()
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
