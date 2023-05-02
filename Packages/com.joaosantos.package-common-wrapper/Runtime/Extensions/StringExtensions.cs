/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using JoaoSant0s.Extensions.Colors;

namespace JoaoSant0s.Extensions.Strings
{
    public static class StringExtensions
    {
        /// <summary>
        /// Add to the string the bold tags: <b>        
        /// </summary>        
        public static string ToBold(this string value)
        {
            return string.Format($"<b>{value}</b>");
        }

        /// <summary>
        /// Add to the string the italic tags: <i>        
        /// </summary>
        public static string ToItalic(this string value)
        {
            return string.Format($"<i>{value}</i>");
        }

        /// <summary>
        /// Add to the string the color tags: <color>        
        /// </summary>
        /// <param name="color"> the new color for the text</param>
        public static string ToModifiedColor(this string value, Color color)
        {
            return string.Format($"<color={color.ToHex()}>{value}</color>");
        }

        /// <summary>
        /// Add to the string the size tags: <size>        
        /// </summary>
        /// <param name="size"> the new size for the text</param>
        public static string ToSize(this string value, int size)
        {
            return string.Format($"<size={size}>{value}</size>");
        }
    }
}
