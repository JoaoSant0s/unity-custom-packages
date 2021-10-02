using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RandomRange = UnityEngine.Random;

public static class CollectionExtensions
{
    public delegate bool PredicateCondition<T>(T parameter);

    public static T Find<T>(this T[] array, PredicateCondition<T> action)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (action(array[i])) return array[i];
        }
        return default(T);
    }

    public static T Random<T>(this List<T> array)
    {
        return array.Random(array.Count);
    }

    public static T Random<T>(this List<T> array, int amount)
    {
        return array[RandomRange.Range(0, amount)];
    }

    public static T Random<T>(this T[] array)
    {
        return array.Random(array.Length);
    }

    public static T Random<T>(this T[] array, int amount)
    {
        return array[RandomRange.Range(0, amount)];
    }
}
