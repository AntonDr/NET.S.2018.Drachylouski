using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearchClass
    {
        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>Position in array</returns>
        /// <exception cref="System.ArgumentException">Invalid data</exception>
        public static int? BinarySearch<T>(this T[] array, T key) where T:IComparable<T>
        {
            if (array.Length == 0 || key.CompareTo(array[0])<0 || key.CompareTo(array[array.Length-1])>0 )
            {
                throw new ArgumentException("Invalid data");
            }

            int left = 0;
            int rigth = array.Length;


            while (left < rigth)
            {
                int mid = left + (rigth - left) / 2;

                if(key.CompareTo(array[mid])<=0)
                {
                    rigth = mid;
                }
                else left = mid + 1;
            }

            if (array[rigth].CompareTo(key)==0)
            {
                return rigth;
            }
            else return null;
        }
    }
}
