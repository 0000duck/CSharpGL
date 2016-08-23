﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a bounding box.
    /// </summary>
    public class BoundingBoxRenderer : Renderer, IBoundingBox
    {

        /// <summary>
        /// get a bounding box renderer.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z direction.</param>
        /// <param name="originalWorldPosition"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer Create(vec3 lengths, vec3 originalWorldPosition = new vec3())
        {
            var bufferable = new BoundingBoxModel(lengths);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", BoundingBoxModel.strPosition);
            var result = new BoundingBoxRenderer(bufferable, shaderCodes, map, new PolygonModeSwitch(PolygonModes.Lines), new PolygonOffsetFillSwitch());
            result.halfLengths = new vec4(lengths / 2, 1.0f);
            result.OriginalWorldPosition = originalWorldPosition;
            result.ModelMatrix = glm.translate(mat4.identity(), originalWorldPosition);
            return result;
        }

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <paramref name="shaderCodes"/> and buffers in <paramref name="bufferable"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        private BoundingBoxRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.BoundingBoxColor = Color.White;
        }

        private UpdatingRecord boundingBoxColorRecord = new UpdatingRecord();
        private vec3 boundingBoxColor;
        /// <summary>
        /// 
        /// </summary>
        public Color BoundingBoxColor
        {
            get { return boundingBoxColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                if (color != boundingBoxColor)
                {
                    boundingBoxColor = color;
                    boundingBoxColorRecord.Mark();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.boundingBoxColorRecord.IsMarked())
            {
                this.SetUniform("boundingBoxColor", this.boundingBoxColor);
                this.boundingBoxColorRecord.CancelMark();
            }

            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMat4());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMat4());
            if (base.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.ModelMatrix);
            }

            base.DoRender(arg);
        }

        vec4 halfLengths;
        /// <summary>
        /// max position in world space.
        /// </summary>
        vec3 IBoundingBox.MaxPosition
        {
            get
            {
                // NOTE: make sure this.ModelMatrix don't rotate.
                return new vec3(this.ModelMatrix * this.halfLengths);
            }
        }

        /// <summary>
        /// min position in world space.
        /// </summary>
        vec3 IBoundingBox.MinPosition
        {
            get
            {
                // NOTE: make sure this.ModelMatrix don't rotate.
                return new vec3(this.ModelMatrix * (-this.halfLengths));
            }
        }
    }
}
