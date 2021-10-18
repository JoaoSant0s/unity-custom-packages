using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace JoaoSant0s.Extensions.NaughtyAttributes
{
    public static class NaughtyAttributesExtensions
    {
        public static int Count<T>(this DropdownList<T> dropDown)
        {
            var count = 0;
            foreach (var item in dropDown)
            {
                count++;
            }
            return count;
        }
    }
}
