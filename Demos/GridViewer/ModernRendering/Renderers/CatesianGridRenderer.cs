﻿using CSharpGL;
using System.IO;

namespace GridViewer
{
    public partial class CatesianGridRenderer : GridViewRenderer
    {
        private Texture codedColorSampler;

        public static CatesianGridRenderer Create(vec3 originalWorldPosition, CatesianGrid grid, Texture codedColorSampler)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", CatesianGrid.strPosition);
            map.Add("in_uv", CatesianGrid.strColor);
            var renderer = new CatesianGridRenderer(originalWorldPosition, grid, shaderCodes, map, codedColorSampler);
            renderer.ModelSize = (grid.DataSource.SourceActiveBounds.MaxPosition - grid.DataSource.SourceActiveBounds.MinPosition).Abs();
            renderer.WorldPosition = -grid.DataSource.Position;
            return renderer;
        }

        private CatesianGridRenderer(vec3 originalWorldPosition, CatesianGrid catesianGrid, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, Texture codedColorSampler, params GLState[] switches)
            : base(originalWorldPosition, catesianGrid, shaderCodes, attributeMap, switches)
        {
            this.codedColorSampler = codedColorSampler;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("colorCodeSampler", new samplerValue(
                TextureTarget.Texture1D, this.codedColorSampler.Id, 0));
        }

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMatrix());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMatrix());
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("modelMatrix", model.Value);
                this.modelTicks = model.UpdateTicks;
            }

            base.DoRender(arg);
        }
    }
}