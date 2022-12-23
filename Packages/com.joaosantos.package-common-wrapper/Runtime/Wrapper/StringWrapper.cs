using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public static class StringWrapper
    {
        /// <summary>
        /// Adding extra zeros on positive numbers
        /// Eg: FillPositiveNumberFormat(9) => "09"
        /// Eg: FillPositiveNumberFormat(3, 3) => "003"
        /// </summary>
        /// <param name="value"> base vector2 to be comparable </param>
        /// <param name="padding"> the list of comparable vectors2 </param>
        public static string FillPositiveNumberFormat(int value, int padding = 2)
        {
            if (padding < 0) throw new ArgumentOutOfRangeException("Padding must be a non-negative number.");

            return (value >= 0) ? value.ToString().PadLeft(padding, '0') : value.ToString();
        }
    }
}
