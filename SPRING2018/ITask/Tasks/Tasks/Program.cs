using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        public static int N { get; set; }
        public static int AmountOfTasks { get; set; } = 4;
        public static int[] Vector { get; set; } = new int[N];
        public static int[,] Matrix { get; set; } = new int[N, N];
        public static int[] Result { get ; set ; } = new int[N];

        public static void Calc(int n)
        {
            N = n;
            Vector = new int[N];
            Matrix = new int[N, N];
            Result = new int[N];
            var r = new Random();
            for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                Matrix[i, j] = r.Next();

            for (int i = 0; i < N; i++)
                Vector[i] = r.Next();

            var timer = new Stopwatch();
            var result2 = new int[N];
            timer.Start();
            for (int i = 0; i < N; i++)
            {
                var sum = 0;

                for (int j = 0; j < N; j++)
                    sum += Matrix[i, j] * Vector[j];

                result2[i] = sum;
            }
            timer.Stop();

            var time1 = timer.Elapsed;

            timer.Reset();

            var task1 = new Task<int[]>(Func1);
            var task2 = new Task<int[]>(Func1);
            var task3 = new Task<int[]>(Func1);
            var task4 = new Task<int[]>(Func1);

            timer.Start();

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            timer.Stop();

            var time2 = timer.Elapsed;

            Task.WaitAll(task1, task2, task3, task4);

            var comparison = time1 > time2 ? "Быстрее" : "Медленнее";

            Console.WriteLine($"Последовательно: {time1.ToString().Substring(11)}; Параллельно: {time2.ToString().Substring(11)} {comparison}");
        } 

        public static void Main()
        {
            for (int i = 100; i < 1000; i+=100)
            {
                Console.Write($"{i} ");
                Calc(i);
            }
        }

        static int[] Func1()
        {
            int part = N / AmountOfTasks;
            var id = (Convert.ToInt32(Task.CurrentId) - 1)%3;
            var start = part * id;
            var end = part * (id + 1);

            for (int i = start; i < end; i++)
            {
                var sum = 0;
                for (int j = 0; j < N; j++)
                    sum += Matrix[i, j] * Vector[j];
                Result[i] = sum;
            }

            return Result;
        }
    }
}