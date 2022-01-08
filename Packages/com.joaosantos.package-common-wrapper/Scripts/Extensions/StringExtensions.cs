using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.Extensions.Colors;

namespace JoaoSant0s.Extensions.Strings
{
    public static class StringExtensions
    {
        public static string ToBold(this string value)
        {
            return string.Format("<b>{0}</b>", value);
        }

        public static string ToItalic(this string value)
        {
            return string.Format("<i>{0}</i>", value);
        }

        public static string ToModifiedColor(this string value, Color color)
        {
            return string.Format("<color={0}>{1}</color>", color.ToHex(), value);
        }

        public static string ToSize(this string value, int size)
        {
            return string.Format("<size={0}>{1}</size>", size, value);
        }
    }
}
