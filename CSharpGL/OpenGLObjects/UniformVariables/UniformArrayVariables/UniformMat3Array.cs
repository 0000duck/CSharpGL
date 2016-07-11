﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat3 variable[10];
    /// </summary>
    public class UniformMat3Array : UniformArrayVariable<mat3>
    {

        /// <summary>
        /// uniform mat3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat3Array(string varName) : base(varName) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix3(VarName, this.Value.Array);
        }
    }

}
