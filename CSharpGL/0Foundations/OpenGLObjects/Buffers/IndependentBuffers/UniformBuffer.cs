﻿namespace CSharpGL
{
    // http://blog.csdn.net/csxiaoshui/article/details/32101977
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public partial class UniformBuffer : Buffer
    {
        private static OpenGL.glUniformBlockBinding glUniformBlockBinding;
        private static OpenGL.glBindBufferRange glBindBufferRange;
        private static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.UniformBuffer; }
        }

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal UniformBuffer(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            if (glUniformBlockBinding == null)
            {
                glUniformBlockBinding = OpenGL.GetDelegateFor<OpenGL.glUniformBlockBinding>();
                glBindBufferRange = OpenGL.GetDelegateFor<OpenGL.glBindBufferRange>();
                glBindBufferBase = OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>();
            }
        }

        /// <summary>
        /// Bind this uniform buffer object and a uniform block to the same binding point.
        /// </summary>
        /// <param name="uniformBlockIndex">index of uniform block got by (glGetUniformBlockIndex).</param>
        /// <param name="uniformBlockBindingPoint">binding point maintained by OpenGL context.</param>
        /// <param name="program">shader program.</param>
        public void Binding(ShaderProgram program, uint uniformBlockIndex, uint uniformBlockBindingPoint)
        {
            glBindBufferBase(OpenGL.GL_UNIFORM_BUFFER, uniformBlockBindingPoint, this.BufferId);
            glUniformBlockBinding(program.ProgramId, uniformBlockIndex, uniformBlockBindingPoint);
        }
    }
}