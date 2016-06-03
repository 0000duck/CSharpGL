﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// root UI for opengl.
    /// </summary>
    public class GLRoot : UIRenderer
    {

        /// <summary>
        /// root UI for opengl
        /// </summary>
        /// <param name="size">opengl canvas' size</param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public GLRoot(
            System.Drawing.Size size, int zNear, int zFar)
            : base(null,
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right |
            System.Windows.Forms.AnchorStyles.Bottom |
            System.Windows.Forms.AnchorStyles.Top,
            new System.Windows.Forms.Padding(), size, zNear, zFar)
        {
            this.Name = "GLRoot";
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"GLControls.GLRoot.GLRoot.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"GLControls.GLRoot.GLRoot.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            // todo: recover this
            //PickableRenderer renderer = (new Axis()).GetRenderer(shaderCodes, map, "position");

            //this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var renderer = this.Renderer as OneIndexRenderer;
            if (renderer != null)
            {
                GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(renderer.IndexBufferPtr);
                renderer.SwitchList.Add(primitiveRestartSwitch);
            }
        }

    }
}
