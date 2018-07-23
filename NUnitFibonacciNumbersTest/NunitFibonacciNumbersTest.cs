using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using FibonacciNumbersLogic;
using System.Numerics;
using System.Reflection.Emit;

namespace NUnitFibonacciNumbersTest
{
    [TestFixture]
    public class NunitFibonacciNumbersTest
    {
        [Test]
        public void FibonacciBigIntegerTest()
        {

            BigInteger[][] expected =
            {
                new BigInteger[]{0, 1, 1, 2, 3,5,8},
                new BigInteger[]{0},
                new BigInteger[]{0, 1},
                new BigInteger[]{ 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
                    , 89, 144, 233, 377, 610, 987, 1597, 2584, 4181,
                    6765, 10946, 17711, 28657, 46368, 75025, 121393,
                    196418, 317811, 514229, 832040, 1346269, 2178309,
                    3524578, 5702887, 9227465, 14930352, 24157817, 39088169,
                    63245986, 102334155 }
            };

            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], FibonacciNumbers.GenerateFibonacciSequence(expected[i].Length));
            }
        }
    }
}
