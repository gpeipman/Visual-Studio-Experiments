using System;
using System.Diagnostics;

namespace Experiments.FibonacciPerformance
{
    class Program
    {
        static void Main()
        {
            var watch = new Stopwatch();

            Console.WriteLine("Measuring recursive implementation");

            watch.Start();            
            for(var i=0; i<42; i++)
            {
                Fibonacci.FibonacciRecursive(i);
            }            
            watch.Stop();

            Console.WriteLine("Recursive: " + watch.Elapsed);
            Console.WriteLine("\r\nMeasuring flat implementation");

            watch.Reset();
            for (var i = 0; i < 42; i++)
            {
                Fibonacci.FibonacciFlat(i);
            }
            watch.Stop();

            Console.WriteLine("Flat: " + watch.Elapsed);
            Console.WriteLine("\r\nPress any key to quit ...");
            Console.ReadLine();
        }
    }
}