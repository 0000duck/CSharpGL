﻿using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer : Renderer
    {
        public static WaterRenderer Create(int waterPlaneLength)
        {
            var model = new WaterPlaneModel(waterPlaneLength);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.frag.glsl"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("a_vertex", WaterPlaneModel.strPosition);
            var renderer = new WaterRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.waterTextureRenderer = WaterTextureRenderer.Create(waterPlaneLength);
            renderer.backgroundRenderer = WaterBackgroundRenderer.Create(waterPlaneLength);
            renderer.Lengths = new vec3(waterPlaneLength + 1, waterPlaneLength + 1, waterPlaneLength + 1);
            renderer.waterPlaneLength = waterPlaneLength;

            return renderer;
        }

        private WaterTextureRenderer waterTextureRenderer;
        private WaterBackgroundRenderer backgroundRenderer;
        private int waterPlaneLength;

        private WaterRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

    }
}