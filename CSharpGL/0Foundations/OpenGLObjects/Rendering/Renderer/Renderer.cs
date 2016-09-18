﻿namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class Renderer : RendererBase
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
        protected VertexAttributeBufferPtr[] propertyBufferPtrs;

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
        public IBufferable Model { get; protected set; }

        /// <summary>
        /// All shader codes needed for this renderer.
        /// </summary>
        protected ShaderCode[] shaderCodes;

        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="Model"/>.
        /// </summary>
        protected PropertyNameMap propertyNameMap;

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderCodes"/> and buffers in <see cref="Model"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        public Renderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
        {
            //this.OriginalWorldPosition = new vec3(0, 0, 0);// this is not needed.
            this.Scale = new vec3(1, 1, 1);
            //this.RotationAngle = 0;// this is not needed.
            this.RotationAxis = new vec3(1, 0, 0);

            this.Model = model;
            this.shaderCodes = shaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.switchList.AddRange(switches);
        }
    }
}