﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a label that always faces camera in 3D space.
    /// </summary>
    public partial class LabelRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("billboardCenter_worldspace",
                    this.ModelMatrix.GetTranslate());
                this.modelMatrixRecord.CancelMark();
            }
            if (labelHeightRecord.IsMarked())
            {
                this.SetUniform("labelHeight", this.LabelHeight);
                labelHeightRecord.CancelMark();
            }
            if (textRecord.IsMarked())
            {
                if (this.model != null)
                {
                    this.model.SetText(this.text, this.fontTexture);
                }
            }
            if (discardTransparencyRecord.IsMarked())
            {
                bool discard = this.DiscardTransparency;
                this.SetUniform("discardTransparency", discard);
                this.blendSwitch.InUse = discard;
            }
            int[] viewport = OpenGL.GetViewport();
            this.SetUniform("viewportSize", new vec2(viewport[2], viewport[3]));
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);

            base.DoRender(arg);
        }

    }
}
