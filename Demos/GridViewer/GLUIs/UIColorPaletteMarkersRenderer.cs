﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    class UIColorPaletteMarkersRenderer : UIRenderer
    {

        /// <summary>
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIColorPaletteMarkersRenderer(int maxMarkerCount,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.SwitchList.Add(new ClearColorSwitch(Color.Red));
        }

        protected override void DoRender(RenderEventArg arg)
        {
            base.DoRender(arg);
        }
    }
}
