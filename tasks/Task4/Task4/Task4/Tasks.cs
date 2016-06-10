using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    public static class Tasks
    {
        public static void Run()
        {
            var random = new Random();

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    Console.WriteLine($"done computing result for {x}");
                    return (int)Math.Pow(x,3);
                });

                tasks.Add(task);
            }

            Console.WriteLine("doing something else ...");

            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { Console.WriteLine($"result is {t.Result}"); return t.Result; })
                );
            }

            var divisibleTask = ComputeDivisible();
            Console.ReadLine();
        }

        public static Task<bool> IsDivisible(int x, int divisor)
        {
            return Task.Run(() =>
            {
                for (var i = 2; i < x - 1; i++)
                {
                    if (x % divisor != 0) return false;
                }
                return true;
            });
        }

        public static async Task ComputeDivisible()
        {
            for (var i = 1000; i < int.MaxValue; i++)
            { 
                if (await IsDivisible(i, (int)(Math.Pow(2, i))/i)) Console.WriteLine($"divisible number: {i}");
            }
        }
    }
}
