﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class PickableRenderer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (arg.RenderMode == RenderModes.ColorCodedPicking)
            {
                this.innerPickableRenderer.Render(arg);
            }
            else// if (arg.RenderMode == RenderModes.Render)
            {
                base.DoRender(arg);
            }

        }

    }
}
