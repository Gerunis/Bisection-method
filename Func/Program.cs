using System;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> f = x => Math.Cos(x) + 2 * x - 1.5;
            Console.Write("Start = ");
            var start = double.Parse( Console.ReadLine());
            Console.Write("End = ");
            var end = double.Parse(Console.ReadLine());
            Console.Write("Delta = ");
            var delta = double.Parse(Console.ReadLine());
            Console.WriteLine("x = ",Counters.Count(start, end,f,delta));
        }
    }
}
