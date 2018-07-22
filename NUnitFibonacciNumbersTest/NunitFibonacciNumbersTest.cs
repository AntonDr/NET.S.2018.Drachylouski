using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using FibonacciNumbersLogic;

namespace NUnitFibonacciNumbersTest
{
    [TestFixture]
    public class NunitFibonacciNumbersTest
    {
        [TestCase(5, ExpectedResult = new int[] {1,1,2, 3, 5})]

        [TestCase(6, ExpectedResult = new int[] { 1, 1, 2, 3, 5,8 })]
        [TestCase(3, ExpectedResult = new int[] { 1, 1, 2})]
        [TestCase(10, ExpectedResult = new int[] { 1, 1, 2, 3, 5,8,13,21,34,55 })]
        public int[] FindFibb(int n)
        {
            int [] arra = FibonacciNumbers.GenerateNumbers(n).ToArray();
            return arra;
        }
    }
}
