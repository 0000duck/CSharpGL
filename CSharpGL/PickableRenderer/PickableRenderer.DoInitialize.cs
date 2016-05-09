﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class PickableRenderer
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (this.positionBufferPtr.DataSize != 3 || this.positionBufferPtr.DataType != GL.GL_FLOAT)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }
        }
    }
}
