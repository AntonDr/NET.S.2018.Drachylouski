using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbersLogic
{
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Generates the numbers.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">invalid data</exception>
        public static IEnumerable<int> GenerateNumbers(int n)
        {
            if (n<2 )
            {
                throw new ArgumentException("invalid data");
            }

            int fib1 = 1, fib2 = 1, sum = 0;

            yield return fib1;
            yield return fib2;

            int i = 2;

            while (i<n)
            {
                yield return (sum = fib1 + fib2);
                fib1 = fib2;
                fib2 = sum;
                i++;    
            }


        }
    }
}
