﻿using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    class VR04PositionBuffer:PropertyBuffer
    {
        public VR04PositionBuffer(string varNameInVertexShader) : base(varNameInVertexShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw) { }

        protected override UnmanagedArrayBase CreateElements(int elementCount)
        {
            return new UnmanagedArray<QuadPosition>(elementCount);
        }
    }
}
