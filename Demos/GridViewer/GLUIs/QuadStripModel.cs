﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    ///  /|\ y
    ///   |
    ///   |
    ///   |
    ///   ---------------&gt; x
    /// (0, 0)
    /// 0    2    4    6    8    10
    /// --------------------------
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// --------------------------
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    class QuadStripModel : IBufferable
    {

        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        /// <summary>
        /// 
        /// </summary>
        public const string texCoord = "texCoord";
        /// <summary>
        /// 
        /// </summary>
        public const string color = "color";

        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr texCoordBufferPtr;
        private PropertyBufferPtr colorBufferPtr;

        public QuadStripModel(int quadCount, Bitmap bitmap = null)
        {
            this.quadCount = quadCount;
            this.bitmap = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create((this.quadCount + 1) * 2);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < (this.quadCount + 1); i++)
                            {
                                array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(this.quadCount), 0.5f, 0);
                                array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(this.quadCount), -0.5f, 0);
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == texCoord)
            {
                if (texCoordBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(
                        varNameInShader, 1, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create((this.quadCount + 1) * 2);
                        unsafe
                        {
                            //Random random = new Random();
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < (this.quadCount + 1); i++)
                            {
                                //array[i * 2 + 0] = (float)random.NextDouble();
                                array[i * 2 + 0] = (float)i / (float)this.quadCount;
                                array[i * 2 + 1] = array[i * 2 + 0];
                            }
                        }

                        texCoordBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return texCoordBufferPtr;
            }
            else if (bufferName == color)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create((this.quadCount + 1) * 2);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < (this.quadCount + 1); i++)
                            {
                                int x = this.bitmap.Width * i / this.quadCount;
                                vec3 value = this.bitmap.GetPixel(x, 0).ToVec3();
                                array[i * 2 + 0] = value;
                                array[i * 2 + 1] = value;
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.QuadStrip, 0, (this.quadCount + 1) * 2))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
        private int quadCount;
        private Bitmap bitmap;
    }
}
