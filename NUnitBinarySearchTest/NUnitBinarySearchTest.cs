using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearch;

namespace NUnitBinarySearchTest
{
    [TestFixture]
    public class NUnitBinarySearchTest
    {
        [TestCase(new[] { 1, 2, 5, 8, 9, 1241, 5555 }, 9, ExpectedResult = 4)]
        [TestCase(new[] { 1, 2 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 5, 8, 9, 1241, 5555 }, 11, ExpectedResult = null)]
        [TestCase(new[] { 1 }, 1, ExpectedResult = 0)]
        public int? TestInt(int[] arrat, int key)
        {
            return arrat.BinarySearch(key, (x, y) => x.CompareTo(y));
        }

        //[TestCase(new[] { 1, 2, 5, 8, 9, 1241, 5555 }, 9, ExpectedResult = 4)]
        //[TestCase(new[] { 1, 2 }, 1, ExpectedResult = 0)]
        //[TestCase(new[] { 1, 2, 5, 8, 9, 1241, 5555 }, 11, ExpectedResult = null)]
        //[TestCase(new[] { 1 }, 1, ExpectedResult = 0)]
        //public int? TestIntWith(int[] arrat, int key)
        //{
        //    return arrat.BinarySearch(key);
        //}

        [TestCase(new[] { 1.7, 2d, 5.2d, 8.8, 9.999, 1241d, 5555.7 }, 5555.7, ExpectedResult = 6)]
        public int? TestInt(double[] arrat, double key)
        {
            return arrat.BinarySearch(key, ((d, d1) => d.CompareTo(d1)));
        }

        [TestCase(null, 5)]
        public void TestExc(int[] arrat, int key)
        {
            Assert.Throws<ArgumentNullException>(() => arrat.BinarySearch(key, (x, y) => x.CompareTo(y)));
        }

    }
}
