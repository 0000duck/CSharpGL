﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Helper class for array.
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// Print elements in format 'element, element, element, ...'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string PrintArray(this System.Collections.IEnumerable array, string seperator = " ")
        {
            if (array == null) { return string.Empty; }

            var builder = new StringBuilder();
            foreach (object item in array)
            {
                builder.Append(item);
                builder.Append(seperator);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Print elements in format 'x,y,z; x,y,z; ...'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="components">2, 3, or 4.</param>
        /// <returns></returns>
        public static string PrintVectors(this float[] array, int components = 3)
        {
            if (components < 1) { throw new ArgumentOutOfRangeException("components"); }

            if (array == null) { return string.Empty; }

            var builder = new StringBuilder();
            int counter = 0;
            foreach (float item in array)
            {
                builder.Append(item.ToShortString());
                counter++;
                if (counter % components == 0)
                {
                    builder.Append("; ");
                    counter = 0;
                }
                else
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }
    }
}
