﻿namespace CSharpGL
{
    public class BuildInRenderer : Renderer
    {
        public BuildInRenderer(vec3 lengths, IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.Size = lengths;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projection", arg.Camera.GetProjectionMatrix());
            this.SetUniform("view", arg.Camera.GetViewMatrix());
            if (modelMatrixRecord.IsMarked())
            {
                this.SetUniform("model", this.GetModelMatrix());
                modelMatrixRecord.CancelMark();
            }

            base.DoRender(arg);
        }
    }
}