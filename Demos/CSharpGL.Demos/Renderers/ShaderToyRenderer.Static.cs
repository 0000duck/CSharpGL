﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    partial class ShaderToyRenderer
    {
        static readonly IBufferable staticBufferable = new Cube();
        static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.frag"), ShaderType.FragmentShader),
        };
        static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "in_Position", },
            new string[] { Cube.strPosition, });


    }
}
