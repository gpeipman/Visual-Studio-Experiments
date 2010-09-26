namespace Experiments.FibonacciPerformance
{
    static class Fibonacci
    {
        public static int FibonacciRecursive(int x)
        {
            if (x == 0 || x == 1)
                return x;

            return FibonacciRecursive(x - 1) +
                   FibonacciRecursive(x - 2);
        }

        public static int FibonacciFlat(int x)
        {
            var previousValue = -1;
            var currentResult = 1;

            for (var i = 0; i <= x; ++i)
            {
                var sum = currentResult + previousValue;
                previousValue = currentResult;
                currentResult = sum;
            }

            return currentResult;
        }
    }
}
