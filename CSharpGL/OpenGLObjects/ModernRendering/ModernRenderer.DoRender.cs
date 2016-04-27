﻿using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer
    {

        protected override void DoRender(RenderEventArgs e)
        {
            ShaderProgram program = this.shaderProgram;
            if (program == null) { return; }

            // 绑定shader
            program.Bind();

            var updatedUniforms = (from item in this.uniformVariables where item.Updated select item).ToArray();
            foreach (var item in updatedUniforms) { item.SetUniform(program); }

            foreach (var item in switchList) { item.On(); }

            if (this.vertexArrayObject == null)
            {
                IndexBufferPtr indexBufferPtr = this.GetIndexBufferPtr();
                PropertyBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
                if (indexBufferPtr != null && propertyBufferPtrs != null)
                {
                    var vertexArrayObject = new VertexArrayObject(
                        indexBufferPtr, propertyBufferPtrs);
                    vertexArrayObject.Create(e, program);

                    this.vertexArrayObject = vertexArrayObject;
                }
            }
            {
                VertexArrayObject vertexArrayObject = this.vertexArrayObject;
                if (vertexArrayObject != null)
                {
                    if (vertexArrayObject.IndexBufferPtr != this.GetIndexBufferPtr())
                    { vertexArrayObject.IndexBufferPtr = this.GetIndexBufferPtr(); }
                    vertexArrayObject.Render(e, program);
                }
            }

            foreach (var item in switchList) { item.Off(); }

            foreach (var item in updatedUniforms) { item.ResetUniform(program); item.Updated = false; }

            // 解绑shader
            program.Unbind();
        }


        protected abstract IndexBufferPtr indexBufferPtr { get; }
    }
}
