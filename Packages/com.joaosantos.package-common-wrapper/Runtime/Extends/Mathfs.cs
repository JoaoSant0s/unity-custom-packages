/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public static class Mathfs
    {
        /// <summary> Equivalent to 2*pi </summary>
        public const float TAU = Mathf.PI * 2;

        /// <summary>
        /// Exponential interpolation, the multiplicative version of lerp, useful for values such as scaling or zooming
        /// </summary>
        /// <param name="start">The start value</param>
		/// <param name="end">The end value</param>
		/// <param name="interval">The interval from 0 to 1 representing position along the eerp</param>
        public static float Eerp(float start, float end, float interval)
        {
            var clampedInterval = Mathf.Clamp01(interval);
            return Mathf.Pow(start, 1 - clampedInterval) * Mathf.Pow(end, clampedInterval);
        }

        /// <summary>Inverse exponential interpolation, the multiplicative version of InverseLerp, useful for values such as scaling or zooming</summary>
		/// <param name="start">The start value</param>
		/// <param name="end">The end value</param>
		/// <param name="value">A value between a and b. Note: values outside this range are still valid, and will be extrapolated</param>
		public static float InverseEerp(float start, float end, float value)
        {
            var clampedValue = Mathf.Clamp(value, start, end);

            if (clampedValue == 0f || end == 0f)
            {
                return 0.0f;
            }

            return Mathf.Log(start / clampedValue) / Mathf.Log(start / end);
        }

        /// <summary>The Sum of a sequence of float numbers </summary>
		/// <param name="numbers">The sequence of float numbers</param>		
        public static float Sum(params float[] numbers)
        {
            var value = 0f;

            for (int i = 0; i < numbers.Length; i++)
            {
                value += numbers[i];
            }

            return value;
        }

        /// <summary>The Sum of a sequence of integer numbers </summary>
		/// <param name="numbers">The sequence of integer numbers</param>		
        public static int Sum(params int[] numbers)
        {
            var value = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                value += numbers[i];
            }

            return value;
        }

        /// <summary>The Product of a sequence of float numbers </summary>
		/// <param name="numbers">The sequence of float numbers</param>	
        public static float Product(params float[] numbers)
        {
            var value = 1f;

            for (int i = 0; i < numbers.Length; i++)
            {
                value *= numbers[i];
            }

            return value;
        }

        /// <summary>The Product of a sequence of integer numbers</summary>
		/// <param name="numbers">The sequence of integer numbers</param>	
        public static int Product(params int[] numbers)
        {
            var value = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                value *= numbers[i];
            }

            return value;
        }

        /// <summary>The Product of a sequence of float numbers</summary>
		/// <param name="numbers">The sequence of float numbers</param>	

        public static float Avarage(params float[] numbers)
        {
            if (numbers.Length == 0) return 0;

            return Sum(numbers) / numbers.Length;
        }

        /// <summary>The Product of a sequence of integer numbers</summary>
		/// <param name="numbers">The sequence of integer numbers</param>	
        public static int Avarage(params int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            return Sum(numbers) / numbers.Length;
        }
    }
}
