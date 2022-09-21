/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.Extensions.Numbers
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Convert the number on the degree to a radian representation        
        /// </summary>        
        public static float Deg2Rad(this float value)
        {
            return value * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Convert the number on the degree to a radian representation        
        /// </summary>        
        public static float Deg2Rad(this int value)
        {
            return value * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Convert the number on the radian to a degree representation        
        /// </summary>        
        public static float Rad2Deg(this float value)
        {
            return value * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Convert the number on the radian to a degree representation        
        /// </summary>        
        public static float Rad2Deg(this int value)
        {
            return value * Mathf.Rad2Deg;
        }
    }
}