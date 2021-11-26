using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RandomRange = UnityEngine.Random;

namespace JoaoSant0s.Extensions.Collections
{
    public static class CollectionExtensions
    {
        public delegate bool PredicateCondition<T>(T parameter);

        /// <summary>
        /// Find in an array an element based on a Predicate Condition      
        /// </summary>
        /// <param name="conditionAction"> the action condition to check ele element condition</param>
        public static T Find<T>(this T[] array, PredicateCondition<T> conditionAction)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (conditionAction(array[i])) return array[i];
            }
            return default(T);
        }

        /// <summary>
        /// Get a random element from a List     
        /// </summary>        
        public static T Random<T>(this List<T> array)
        {
            return array.Random(array.Count);
        }

        /// <summary>
        /// Get a random element from a List with the specific size     
        /// </summary>
        /// <param name="amount"> number of elements that will be analyzed in the list </param>
        public static T Random<T>(this List<T> array, int amount)
        {
            return array[RandomRange.Range(0, amount)];
        }

        /// <summary>
        /// Get a random element from an array     
        /// </summary>   
        public static T Random<T>(this T[] array)
        {
            return array.Random(array.Length);
        }

        /// <summary>
        /// Get a random element from an array with the specific size     
        /// </summary>
        /// <param name="amount"> number of elements that will be analyzed in the array </param>
        public static T Random<T>(this T[] array, int amount)
        {
            return array[RandomRange.Range(0, amount)];
        }
    }
}
