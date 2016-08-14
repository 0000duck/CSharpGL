﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>
    public sealed class OneIndexBufferPtr : IndexBufferPtr
    {
        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="firstIndex">要渲染的第一个索引的位置。<para>First index to be rendered.</para></param>
        /// <param name="elementCount">索引数组中有多少个元素。<para>How many indexes to be rendered?</para></param>
        /// <param name="type">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal OneIndexBufferPtr(uint bufferId, DrawMode mode, int firstIndex, int elementCount,
            IndexElementType type, int length, int byteLength)
            : base(mode, bufferId, length, byteLength)
        {
            this.FirstIndex = firstIndex;
            this.ElementCount = elementCount;
            this.OriginalElementCount = elementCount;
            this.Type = type;
        }

        /// <summary>
        /// 要渲染的第一个索引的位置。
        /// <para>First index to be rendered.</para>
        /// </summary>
        public int FirstIndex { get; set; }

        /// <summary>
        /// 要渲染多少个索引。
        /// <para>How many indexes to be rendered?</para>
        /// </summary>
        public int ElementCount { get; set; }

        /// <summary>
        /// How many indexes are there in total?
        /// </summary>
        public int OriginalElementCount { get; private set; }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexElementType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="shaderProgram"></param>
        public override void Render(RenderEventArgs arg, ShaderProgram shaderProgram)
        {
            IntPtr offset;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    offset = new IntPtr(this.FirstIndex * sizeof(byte));
                    break;
                case IndexElementType.UnsighedShort:
                    offset = new IntPtr(this.FirstIndex * sizeof(ushort));
                    break;
                case IndexElementType.UnsignedInt:
                    offset = new IntPtr(this.FirstIndex * sizeof(uint));
                    break;
                default:
                    throw new NotImplementedException();
            }
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.BufferId);
            if (arg.RenderMode == RenderModes.ColorCodedPicking
                && arg.PickingGeometryType == GeometryType.Point
                && this.Mode.ToGeometryType() == GeometryType.Line)// picking point from a line
            {
                // this may render points that should not appear. 
                // so need to select by another picking.
                OpenGL.DrawElements((uint)DrawMode.Points, this.ElementCount, (uint)this.Type, offset);
            }
            else
            {
                OpenGL.DrawElements((uint)this.Mode, this.ElementCount, (uint)this.Type, offset);
            }
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string type = string.Empty;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    type = "byte";
                    break;
                case IndexElementType.UnsighedShort:
                    type = "ushort";
                    break;
                case IndexElementType.UnsignedInt:
                    type = "uint";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return string.Format("glDrawElements({0}, {1}, {2}, new IntPtr({3} * sizeof({4}))",
                this.Mode, this.ElementCount, this.Type, this.FirstIndex, type);
        }
    }
}
