﻿namespace CSharpGL
{
    // http://blog.csdn.net/csxiaoshui/article/details/32101977
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class PixelUnpackBuffer<T> : IndependentBuffer<T> where T : struct
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed"></param>
        public PixelUnpackBuffer(BufferUsage usage, bool noDataCopyed = false)
            : base(usage, noDataCopyed)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override IndependentBufferPtr Upload2GraphicsCard()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_PIXEL_UNPACK_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new PixelUnpackBufferPtr(buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}