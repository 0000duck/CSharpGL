﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class ShaderToyRenderer : Renderer
    {

        public ShaderToyRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }

    }
}
