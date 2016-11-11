namespace CSharpGL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Some Points
    /// </summary>
    public partial class Points : IBufferable
    {
        private vec3[] pointPositions;

        /// <summary>
        ///
        /// </summary>
        public vec3 WorldPosition { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }

        /// <summary>
        /// Some Points
        /// </summary>
        /// <param name="pointPositions"></param>
        public Points(IList<vec3> pointPositions)
        {
            vec3[] positions = pointPositions.ToArray();
            var box = positions.Move2Center();
            this.Lengths = box.MaxPosition - box.MinPosition;
            this.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;
            this.pointPositions = positions;
        }

        /// <summary>
        ///
        /// </summary>
        public const string strposition = "position";

        private CSharpGL.VertexAttributeBuffer positionBufferPtr;

        private CSharpGL.IndexBuffer indexBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public CSharpGL.VertexAttributeBuffer GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strposition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = this.pointPositions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < this.pointPositions.Length; i++)
                        {
                            array[i] = this.pointPositions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            throw new System.ArgumentException("bufferName");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public CSharpGL.IndexBuffer GetIndexBufferPtr()
        {
            if ((indexBufferPtr == null))
            {
                int vertexCount = this.pointPositions.Length;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.Points, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
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