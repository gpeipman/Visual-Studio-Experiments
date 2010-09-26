using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Experiments.LinqPLinqPerformance
{
    class PrimeNumberDemo
    {
        public void ShowDemo()
        {
            var firstTimeFaster = false;

            //Set how many tests we want to do
            var upperLimits = new List<int> { 10, 100, 500, 1000, 5000, 7500, 10000, 20000, 50000, 100000, 150000 };

            foreach (var upperLimit in upperLimits)
            {
                //Create the numbers to test for this upper limit
                var numbersToCheck = CreateNumberList(upperLimit);

                //Run the demos for both parallel and sequential runs
                long sequentialTime = RunSequentialTest(numbersToCheck);
                long parallelTime = RunParallelTest(numbersToCheck);


                Console.WriteLine("Testing Prime Numbers Up To {0}", upperLimit);
                Console.WriteLine("     Sequential Time {0}ms", sequentialTime);
                Console.WriteLine("     Parallel Time {0}ms", parallelTime);
                Console.WriteLine();

                //If this is the first time the parallel test is faster
                //show some eye candy
                if (!firstTimeFaster && (parallelTime < sequentialTime))
                {
                    Console.WriteLine("The Parallel Execution time is now faster than the sequential execution time.");
                    Console.WriteLine();

                    firstTimeFaster = true;
                }

                Console.WriteLine();
            }
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

        /// <summary>
        /// Runs a prime check on a list of numbers using PLINQ
        /// </summary>
        /// <param name="numbersToCheck"></param>
        /// <returns></returns>
        private static long RunParallelTest(IEnumerable<PotentialPrime> numbersToCheck)
        {
            var watch = new Stopwatch();
            watch.Start();

            Parallel.ForEach(numbersToCheck, num =>
            {
                var q = IsPrime(num.Value);
                num.IsPrime = q;

            });

            return watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Runs a prime check on a list of numbers using standard looping
        /// </summary>
        /// <param name="numbersToCheck"></param>
        /// <returns></returns>
        private static long RunSequentialTest(IEnumerable<PotentialPrime> numbersToCheck)
        {
            var watch = new Stopwatch();
            watch.Start();

            foreach (var num in numbersToCheck)
            {
                var q = IsPrime(num.Value);
                num.IsPrime = q;

            }
            return watch.ElapsedMilliseconds;
        }

        private static IEnumerable<PotentialPrime> CreateNumberList(int max)
        {
            var numbersToCheck = new List<PotentialPrime>(max);
            for (int i = 3; i < max; i++)
            {
                var pot = new PotentialPrime
                              {
                                  Value = i + 1, 
                                  IsPrime = false
                              };

                numbersToCheck.Add(pot);

            }
            return numbersToCheck;
        }

        /// <summary>
        /// Determines if a specific number is prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsPrime(int number)
        {
            var found = false;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    found = true;
                    break;
                }
            }

            return !found;
        }
    }
}
