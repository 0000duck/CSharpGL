﻿using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 正方形
    /// </summary>
    internal class EmitNormalLineRenderer : PickableRenderer
    {
        public static EmitNormalLineRenderer Create(IBufferable model, string positionNameInIBufferable)
        {
            var shaderCodes = new ShaderCode[3];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.geom"), ShaderType.GeometryShader);
            shaderCodes[2] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Normal", "normal");
            var ground = new EmitNormalLineRenderer(model, shaderCodes, map, positionNameInIBufferable);
            return ground;
        }

        public Color LineColor { get; set; }

        private EmitNormalLineRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            this.LineColor = Color.White;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = glm.scale(mat4.identity(), this.Scale);
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            this.SetUniform("lineColor", this.LineColor.ToVec3());
            base.DoRender(arg);
        }
    }
}