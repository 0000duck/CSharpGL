﻿using System;

namespace CSharpGL.Demos
{
    internal class ParticleModel : IBufferable
    {
        public static readonly float[] attractor_masses = new float[maxAttractor];

        public const int particleGroupSize = 128;
        public const int particleGroupCount = 8000;
        public const int particleCount = (particleGroupSize * particleGroupCount);
        public const int maxAttractor = 64;

        public const string strPosition = "position";
        public const string strVelocity = "velocity";
        private VertexAttributeBufferPtr positionBufferPtr = null;
        private VertexAttributeBufferPtr velocityBufferPtr = null;
        private IndexBufferPtr indexBufferPtr;
        private Random random = new Random();

        static ParticleModel()
        {
            Random random = new Random();
            for (int i = 0; i < maxAttractor; i++)
            {
                attractor_masses[i] = 0.5f + (float)random.NextDouble() * 0.5f;
            }
        }

        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec4>(
                        varNameInShader, VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy))
                    {
                        buffer.Create(particleCount);
                        unsafe
                        {
                            var array = (vec4*)buffer.Header.ToPointer();
                            for (int i = 0; i < particleCount; i++)
                            {
                                array[i] = new vec4(
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble())
                                    );
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }

                return positionBufferPtr;
            }
            else if (bufferName == strVelocity)
            {
                if (velocityBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec4>(
                        varNameInShader, VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy))
                    {
                        buffer.Create(particleCount);
                        unsafe
                        {
                            var array = (vec4*)buffer.Header.ToPointer();
                            for (int i = 0; i < particleCount; i++)
                            {
                                array[i] = new vec4(
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    0
                                    );
                            }
                        }

                        velocityBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }

                return velocityBufferPtr;
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
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, particleCount))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}