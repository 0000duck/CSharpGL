﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class Renderer : RendererBase, IModelTransform
    {

        /// <summary>
        /// algorithm for rendering.
        /// </summary>
        public ShaderProgram Program { get; protected set; }

        // data structure for rendering.

        /// <summary>
        /// 
        /// </summary>
        protected VertexArrayObject vertexArrayObject;
        /// <summary>
        /// 
        /// </summary>
        protected PropertyBufferPtr[] propertyBufferPtrs;
        /// <summary>
        /// 
        /// </summary>
        protected IndexBufferPtr indexBufferPtr;
        /// <summary>
        /// 
        /// </summary>
        protected GLSwitchList switchList = new GLSwitchList();

        /// <summary>
        /// model data that can be transfermed into OpenGL Buffer's pointer.
        /// </summary>
        protected IBufferable bufferable;
        /// <summary>
        /// All shader codes needed for this renderer.
        /// </summary>
        protected ShaderCode[] shaderCodes;
        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="bufferable"/>.
        /// </summary>
        protected PropertyNameMap propertyNameMap;


        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderCodes"/> and buffers in <see cref="bufferable"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        public Renderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
        {
            this.bufferable = bufferable;
            this.shaderCodes = shaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.switchList.AddRange(switches);
        }

        private mat4 modelMatrix = mat4.identity();
        /// <summary>
        /// records whether modelMatrix is updated.
        /// </summary>
        protected UpdatingRecord modelMatrixRecord = new UpdatingRecord();
        /// <summary>
        /// transform this model from model's space to world's space.
        /// </summary>
        public virtual mat4 ModelMatrix
        {
            get { return modelMatrix; }
            set
            {
                if (value != modelMatrix)
                {
                    modelMatrix = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 OriginalWorldPosition { get; protected set; }
    }
}
