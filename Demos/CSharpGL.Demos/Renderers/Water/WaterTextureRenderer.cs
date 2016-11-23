﻿using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterTextureRenderer : Renderer
    {
        private int waterPlaneLength;
        public float passedTime;

        public static WaterTextureRenderer Create(int waterPlaneLength)
        {
            var model = new PlaneModel(waterPlaneLength / 2);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\WaterTexture.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\WaterTexture.frag.glsl"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("a_vertex", PlaneModel.strPosition);
            map.Add("a_texCoord", PlaneModel.strTexCoord);
            var renderer = new WaterTextureRenderer(model, shaderCodes, map, new FrontFaceState(FrontFaceMode.CCW), new ClearColorState(Color.Black, 0), new ViewportState(0, 0, TEXTURE_SIZE, TEXTURE_SIZE));
            renderer.ModelSize = new vec3(waterPlaneLength, 0, waterPlaneLength);
            renderer.waterPlaneLength = waterPlaneLength;

            return renderer;
        }

        private WaterTextureRenderer(
            IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
        }
    }
}