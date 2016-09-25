﻿using System;

namespace CSharpGL
{
    // uniform Uniforms {
    //     vec3 vPos;
    //     float scale;
    //     ...
    // } someUniformBlock;
    // block name is 'Uniforms'.
    /// <summary>
    /// A uiform block in shader.
    /// </summary>
    public class UniformBlock<T> : UniformSingleVariableBase where T : struct, IEquatable<T>
    {
        /// <summary>
        ///
        /// </summary>
        protected T value;

        /// <summary>
        /// Don't rename this property because its used in Renderer.GetVariable&lt;T&gt;(T value, string varNameInShader).
        /// </summary>
        public T Value
        {
            get { return this.value; }
            set
            {
                if (!value.Equals(this.value))
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        /// <summary>
        /// A uiform variable in shader.
        /// </summary>
        /// <param name="blockName"></param>
        public UniformBlock(string blockName) : base(blockName) { }

        /// <summary>
        /// A uiform variable in shader.
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="value"></param>
        public UniformBlock(string blockName, T value) : base(blockName) { this.Value = value; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.VarName, this.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            if (uniformBufferPtr == null)
            {
                uniformBufferPtr = Initialize(program);
            }
            else
            {
                IntPtr pointer = uniformBufferPtr.MapBuffer(MapBufferAccess.WriteOnly, bind: true);
                unsafe
                {
                    var array = (byte*)pointer.ToPointer();
                    byte[] bytes = this.value.ToBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        array[i] = bytes[i];
                    }
                }
                uniformBufferPtr.UnmapBuffer(unbind: true);
            }

            this.Updated = false;
        }

        /// <summary>
        /// Initialize and setup uniform block's value.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        private UniformBufferPtr Initialize(ShaderProgram program)
        {
            throw new System.NotImplementedException();
        }

        private UniformBufferPtr uniformBufferPtr = null;
    }
}