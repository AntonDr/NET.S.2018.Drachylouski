using System;
using System.Collections;
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
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// Position in array or null.
        /// </returns>
        /// <exception cref="ArgumentNullException">array</exception>
        /// <exception cref="System.ArgumentException">Invalid data</exception>
        public static int? BinarySearch<T>(this T[] array, T key,Comparison<T> comparer = null)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            if (comparer==null)
            {
                if (key is IComparable<T>)
                {
                    comparer = Comparer<T>.Default.Compare;
                }
                else
                {
                    throw new ArgumentNullException($"{nameof(comparer)} can not compare the items");
                }
            }

            if (array.Length == 0 || comparer(key,array[0])<0 || comparer(key,array[array.Length-1])>0 )
            {
                return null;
            }

            int left = 0;
            int rigth = array.Length;


            while (left < rigth)
            {
                int mid = left + (rigth - left) / 2;

                if(comparer(key,array[mid])<=0)
                {
                    rigth = mid;
                }
                else left = mid + 1;
            }

            if (comparer(array[rigth],key)==0)
            {
                return rigth;
            }
            else return null;
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Position in array or null</returns>
        public static int? BinarySearch<T>(this T[] array, T key, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                if (key is IComparable)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException($"{nameof(comparer)} can not compare the items");
                }
            }

            return BinarySearch(array, key, comparer.Compare);
        }
    }
}
