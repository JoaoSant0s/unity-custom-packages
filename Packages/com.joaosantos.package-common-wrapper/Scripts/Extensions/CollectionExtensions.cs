using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RandomRange = UnityEngine.Random;

namespace JoaoSant0s.Extensions.Collections
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Get a random element from a List     
        /// </summary>                
        public static T Random<T>(this ICollection<T> array)
        {
            return array.Random(array.Count);
        }

        /// <summary>
        /// Get a random element from a List with the specific size     
        /// </summary>
        /// <param name="amount"> number of elements that will be analyzed in the list </param>        
        public static T Random<T>(this ICollection<T> collection, int amount)
        {
            return collection.ElementAt(RandomRange.Range(0, amount));
        }
    }
}
