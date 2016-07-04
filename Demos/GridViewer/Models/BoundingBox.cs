﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GridViewer
{
    /// <summary>
    /// bounding box.
    /// </summary>
    public partial class BoundingBox : IBufferable
    {

        private vec3[] positions = new vec3[] 
        { 
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
            new vec3(1, 1, -1),  new vec3(-1, 1, -1),
            new vec3(1, -1, -1), new vec3(-1, -1, -1),
            new vec3(1, -1, 1),  new vec3(-1, -1, 1),
            new vec3(1, 1, 1),   new vec3(-1, 1, 1),
        };

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;
        private vec3 lengths;

        /// <summary>
        /// bounding box.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z axis.</param>
        public BoundingBox(vec3 lengths)
        {
            this.lengths = lengths;
        }

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create(positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i] / 2 * this.lengths;
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.QuadStrip, 0, positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

    }
}
