﻿namespace CSharpGL
{
    /// <summary>
    /// Teapot.
    /// <para>Uses <see cref="OneIndexBuffer&lt;T&gt;"/></para>
    /// </summary>
    public class Teapot : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public Teapot()
        {
            this.model = new TeapotModel();
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        /// <summary>
        ///
        /// </summary>
        public const string strNormal = "normal";

        private TeapotModel model;
        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr colorBufferPtr;
        private PropertyBufferPtr normalBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] positions = model.GetPositions();
                        buffer.Create(positions.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
                        }
                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.Create(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
                        }
                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.Create(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
                        }
                        normalBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return normalBufferPtr;
            }
            else
            {
                return null;
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
                using (var buffer = new OneIndexBuffer<ushort>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    ushort[] faces = model.GetFaces();
                    buffer.Create(faces.Length);
                    unsafe
                    {
                        var array = (ushort*)buffer.Header.ToPointer();
                        for (int i = 0; i < faces.Length; i++)
                        {
                            array[i] = (ushort)(faces[i] - 1);
                        }
                    }

                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
    }
}