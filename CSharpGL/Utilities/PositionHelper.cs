﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class PositionHelper
    {
        /// <summary>
        /// Move positions where around (0, 0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static void Move2Center(this vec3[] positions)
        {
            if (positions.Length == 0) { return; }

            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Length; i++)
            {
                vec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = positions[i] - mid;
            }
        }

        /// <summary>
        /// Move positions where around (0, 0, 0)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static void Move2Center(this IList<vec3> positions)
        {
            if (positions.Count == 0) { return; }

            vec3 min = positions[0], max = positions[0];
            for (int i = 1; i < positions.Count; i++)
            {
                vec3 value = positions[i];
                if (value.x < min.x) { min.x = value.x; }
                if (value.y < min.y) { min.y = value.y; }
                if (value.z < min.z) { min.z = value.z; }
                if (max.x < value.x) { max.x = value.x; }
                if (max.y < value.y) { max.y = value.y; }
                if (max.z < value.z) { max.z = value.z; }
            }
            vec3 mid = max / 2 + min / 2;
            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] = positions[i] - mid;
            }
        }

    }
}
