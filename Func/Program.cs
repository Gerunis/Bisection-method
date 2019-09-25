using System;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<double, double> f = x => Math.Cos(x) + 2 * x - 1.5;
            Console.Write("Start = ");
            var start = double.Parse(Console.ReadLine());
            Console.Write("End = ");
            var end = double.Parse(Console.ReadLine());
            Console.Write("Delta = ");
            var delta = double.Parse(Console.ReadLine());
            var z = Counters.Count(start, end, f, delta);
            var z2 = Counters.CountNewton(start, end, f, delta);
            //int i = 0;
            //var t = delta;
            //for (; t != 1; i++)
            //    t *= 10;
            //Console.WriteLine("x = " + Math.Round(z, i, MidpointRounding.AwayFromZero) + '±' + delta);

            Console.WriteLine("x = " + z);
            Console.WriteLine("x = " + z2);
        }
    }
}
