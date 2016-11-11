﻿using System;

namespace CSharpGL
{
    public partial class HighlightRenderer
    {
        /// <summary>
        /// 清空高亮显示。
        /// </summary>
        public void ClearHighlightIndexes()
        {
            var indexBufferPtr = this.indexBufferPtr as OneIndexBuffer;
            indexBufferPtr.ElementCount = 0;
        }

        /// <summary>
        /// 设置要高亮显示的图元。
        /// </summary>
        /// <param name="mode">要高亮显示的图元类型</param>
        /// <param name="indexes">要高亮显示的图元的索引。</param>
        public void SetHighlightIndexes(DrawMode mode, params uint[] indexes)
        {
            int indexesLength = indexes.Length;
            if (indexesLength > this.maxElementCount)
            {
                IndexBuffer original = this.indexBufferPtr;
                this.indexBufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, mode, IndexElementType.UInt, indexesLength);
                this.maxElementCount = indexesLength;
                original.Dispose();
            }

            var indexBufferPtr = this.indexBufferPtr as OneIndexBuffer;
            IntPtr pointer = indexBufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (int i = 0; i < indexesLength; i++)
                {
                    array[i] = indexes[i];
                }
            }
            indexBufferPtr.UnmapBuffer();

            indexBufferPtr.Mode = mode;
            indexBufferPtr.ElementCount = indexesLength;
        }
    }
}