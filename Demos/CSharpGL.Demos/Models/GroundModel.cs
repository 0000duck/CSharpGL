﻿using System;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 正方形
    /// </summary>
    internal class GroundModel : IBufferable
    {
        internal vec3[] positions;

        public GroundModel(int squreCountPerLine)
        {
            this.positions = GeneratePositions(squreCountPerLine);
        }

        private static vec3[] GeneratePositions(int squreCountPerLine)
        {
            var positions = new vec3[(squreCountPerLine + 1) * 4];
            int index = 0;
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                positions[index++] = new vec3(
                    1, 0, -1 + 2 * (float)i / (float)(squreCountPerLine));
                positions[index++] = new vec3(
                    -1, 0, -1 + 2 * (float)i / (float)(squreCountPerLine));
            }
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                positions[index++] = new vec3(
                    -1 + 2 * (float)i / (float)(squreCountPerLine), 0, 1);
                positions[index++] = new vec3(
                    -1 + 2 * (float)i / (float)(squreCountPerLine), 0, -1);
            }

            return positions;
        }

        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = positions.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = positions.Length;
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Lines, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}