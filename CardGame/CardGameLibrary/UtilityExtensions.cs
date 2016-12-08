using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary
{
    static class UtilityExtensions
    {
        static Random random = new Random();
        /// <summary>
        /// Fisher and Yates shuffle
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> inputList)
        {
            var result = inputList.ToArray();
            int n = inputList.Count();
            for (int i = n - 1; i >= 1; i --)
            {
                // random number from 0 to n-1;
                var randDestination = random.Next(0, i - 1);
                // swap
                T temp = result[randDestination];
                result[randDestination] = result[i];
                result[i] = temp;
            }

            return result;
        }
    }
}
