﻿namespace CSharpGL
{
    /// <summary>
    /// uniform ivec4 variable[10];
    /// </summary>
    public class UniformIVec4Array : UniformArrayVariable<ivec4>
    {
        /// <summary>
        /// uniform vec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformIVec4Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, this.Value.Array);
        }
    }
}