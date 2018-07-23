using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FibonacciNumbersLogic
{
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Generates Fibonacci sequence.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">invalid data</exception>
        /// <exception cref="System.ArgumentException">invalid data</exception>
        public static IEnumerable<BigInteger> GenerateFibonacciSequence(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} can't be non-positive");
            }

            BigInteger fib1 = 0, fib2 = 1, sum = 0;

            IEnumerable <BigInteger> GenerateSequence()
            {
                yield return fib1;

                if (n==1)
                {
                    yield break;
                }

                yield return fib2;

                int i = 2;

                while (i < n)
                {
                    yield return (sum = fib1 + fib2);
                    fib1 = fib2;
                    fib2 = sum;
                    i++;
                }
            }

            return GenerateSequence();

        }
    }
}
