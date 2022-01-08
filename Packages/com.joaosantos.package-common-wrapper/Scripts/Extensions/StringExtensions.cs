using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.Extensions.Colors;

namespace JoaoSant0s.Extensions.Strings
{
    public static class StringExtensions
    {
        private static string[] defaultTagsPrefix = new string[] { "<b", "<i", "<size", "<color" };
        private static string[] defaultTagsSufix = new string[] { "</b", "</i", "</size", "</color" };

        /// <summary>
        /// Add to the string the bold tags: <b>        
        /// </summary>        
        public static string ToBold(this string value)
        {
            return string.Format("<b>{0}</b>", value);
        }

        /// <summary>
        /// Add to the string the italic tags: <i>        
        /// </summary>
        public static string ToItalic(this string value)
        {
            return string.Format("<i>{0}</i>", value);
        }

        /// <summary>
        /// Add to the string the color tags: <color>        
        /// </summary>
        /// <param name="color"> the new color for the text</param>
        public static string ToModifiedColor(this string value, Color color)
        {
            var newValue = value;
            if (value.Contains("<color="))
            {
                newValue = value.ToStripHTMLTags("color");
            }
            return string.Format("<color={0}>{1}</color>", color.ToHex(), newValue);
        }

        /// <summary>
        /// Add to the string the size tags: <size>        
        /// </summary>
        /// <param name="size"> the new size for the text</param>
        public static string ToSize(this string value, int size)
        {
            return string.Format("<size={0}>{1}</size>", size, value);
        }

        /// <summary>
        /// Remove all default HTML tags: bold, italic, size, color
        /// </summary>
        public static string ToStripHTMLTags(this string value)
        {
            var newValue = value.Clone().ToString();

            for (int i = 0; i < defaultTagsPrefix.Length; i++)
            {
                var prefix = defaultTagsPrefix[i];
                if (newValue.Contains(prefix))
                {
                    var startIndex = newValue.IndexOf(prefix);
                    var sentenxeStartIndex = newValue.IndexOf(">", startIndex) + 1;
                }
            }
            return value;
        }

        /// <summary>
        /// Remove just specific HTML tags
        /// pass the identical tag format that will be removed:
        /// run: <b>test</b>.ToStripHTMLTags("b");
        /// result: test
        /// run: <b><size=50>test</size></b>.ToStripHTMLTags("size");
        /// result: <b>test</b>
        /// </summary>
        public static string ToStripHTMLTags(this string value, params string[] specificTags)
        {
            return value;
        }
    }
}
