﻿using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterPlaneRenderer : Renderer
    {
        public static WaterPlaneRenderer Create(int sideLength)
        {
            var model = new WaterPlaneModel(sideLength);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.frag.glsl"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("a_vertex", WaterPlaneModel.strPosition);
            var renderer = new WaterPlaneRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = new vec3(sideLength, 0, sideLength);

            return renderer;
        }

        private WaterPlaneRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

    }
}