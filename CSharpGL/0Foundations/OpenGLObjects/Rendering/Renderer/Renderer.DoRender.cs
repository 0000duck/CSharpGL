﻿using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    public partial class Renderer
    {
        //private Stack<UniformVariable> uniformVariableStack = new Stack<UniformVariable>();

        //private Stack<UniformArrayVariable> uniformArrayVariableStack = new Stack<UniformArrayVariable>();
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            SetUniformValues(program);

            SwitchesOn();

            this.vertexArrayObject.Render(arg, program);

            SwithesOff();

            //ResetUniformValues(program);
            // 解绑shader
            program.Unbind();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwitchesOn()
        {
            int count = this.switchList.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList[i].On();
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwithesOff()
        {
            int count = this.switchList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }
        }

        ////[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void ResetUniformValues(ShaderProgram program)
        //{
        //    //while (uniformArrayVariableStack.Count > 0)
        //    //{
        //    //    UniformArrayVariable item = uniformArrayVariableStack.Pop();
        //    //    item.ResetUniform(program);
        //    //}

        //    while (uniformVariableStack.Count > 0)
        //    {
        //        UniformVariable item = uniformVariableStack.Pop();
        //        item.ResetUniform(program);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetUniformValues(ShaderProgram program)
        {
            //var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            //foreach (var item in updatedUniforms) { item.DoSetUniform(program); uniformVariableStack.Push(item); }
            UniformVariable[] array = this.uniformVariables.ToArray();
            foreach (var item in array)
            {
                item.SetUniform(program);
            }
        }
    }
}