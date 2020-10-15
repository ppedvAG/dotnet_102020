using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Hallo TPL ***");

            //Parallel.Invoke(Zähle, Zähle, Zähle);

            //Parallel.For(0, 100_000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            var t1 = new Task(() =>
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(800);
                throw new FieldAccessException();
                Console.WriteLine("T1 fertig");
            });
            t1.ContinueWith(t => Console.WriteLine("T1 Continue Fertig"));
            t1.ContinueWith(t => Console.WriteLine("T1 OK"), TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.ContinueWith(t => Console.WriteLine($"T1 ERROR {t.Exception.InnerException.Message}"), TaskContinuationOptions.OnlyOnFaulted);

            var t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 gestartet");
                Thread.Sleep(1800);
                Console.WriteLine("T2 fertig");
                return 34567890;
            });
            t2.ContinueWith(t => Console.WriteLine($"T2: Result: {t.Result}"));

            t1.Start();
            t2.Start();

            //Console.WriteLine($"T2: Result: {t2.Result}");

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
