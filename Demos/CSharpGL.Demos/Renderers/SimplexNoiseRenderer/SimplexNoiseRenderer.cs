﻿using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class SimplexNoiseRenderer : PickableRenderer
    {
        public static SimplexNoiseRenderer Create()
        {
            var model = new Sphere(1, 180, 360);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.frag"), ShaderType.FragmentShader);
            var provider = new ShaderCodeArray(shaderCodes);
            var map = new AttributeMap();
            map.Add("in_Position", Sphere.strPosition);
            var renderer = new SimplexNoiseRenderer(model, provider, map, Sphere.strPosition);
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private SimplexNoiseRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, positionNameInIBufferable, switches)
        {
        }
    }
}