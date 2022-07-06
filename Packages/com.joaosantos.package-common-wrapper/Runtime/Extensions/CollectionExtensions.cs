using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RandomRange = UnityEngine.Random;
using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.Extensions.Collections
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Get a random element from a ICollection     
        /// </summary>                
        public static T Random<T>(this ICollection<T> array)
        {
            return array.Random(array.Count);
        }

        /// <summary>
        /// Get a random element from a ICollection with the specific size     
        /// </summary>
        /// <param name="amount"> number of elements that will be analyzed in the list </param>        
        public static T Random<T>(this ICollection<T> collection, int amount)
        {
            return collection.ElementAt(RandomRange.Range(0, amount));
        }

        /// <summary>
        /// Get a subset list:
        /// var collection = [2, 3, 4, 5]
        /// collection.Subset(1) => {2, 4, 5}
        /// </summary>
        /// <param name="start"> from the start index: inclusive </param>
        public static List<T> ToSubsetList<T>(this ICollection<T> collection, int start)
        {
            return collection.Subset<T>(start, collection.Count()).ToList();
        }

        /// <summary>
        /// Get a subset list 
        /// var collection = [2, 3, 4, 5]
        /// collection.Subset(0, 2) => {2, 3}
        /// </summary>
        /// <param name="start"> from the start index: inclusive </param>             
        /// <param name="end"> until the end index: exclusive </param>          
        public static List<T> ToSubsetList<T>(this ICollection<T> collection, int start, int end)
        {
            return collection.Subset<T>(start, end).ToList();
        }

        /// <summary>
        /// Get a subset list:
        /// var collection = [2, 3, 4, 5]
        /// collection.Subset(1) => [2, 4, 5]
        /// </summary>
        /// <param name="start"> from the start index: inclusive </param>
        public static T[] ToSubsetArray<T>(this ICollection<T> collection, int start)
        {
            return collection.Subset<T>(start, collection.Count()).ToArray();
        }

        /// <summary>
        /// Get a subset list 
        /// var collection = [2, 3, 4, 5]
        /// collection.Subset(0, 2) => [2, 3]
        /// </summary>
        /// <param name="start"> from the start index: inclusive </param>             
        /// <param name="end"> until the end index: exclusive </param>          
        public static T[] ToSubsetArray<T>(this ICollection<T> collection, int start, int end)
        {
            return collection.Subset<T>(start, end).ToArray();
        }

        private static IEnumerable<T> Subset<T>(this ICollection<T> collection, int start, int end)
        {
            return collection.Where((c, index) => start <= index && index < end);
        }
    }
}
