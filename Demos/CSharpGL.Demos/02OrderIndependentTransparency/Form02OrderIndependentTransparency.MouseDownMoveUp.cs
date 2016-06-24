﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form02OrderIndependentTransparency : Form
    {

        private Point lastMousePosition;

        //internal void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    this.lastMousePosition = new Point(e.X, e.Y);

        //    // operate camera
        //    rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
        //    rotator.MouseDown(e.X, e.Y);

        //    if (sender == this.glCanvas1)
        //    {
        //        this.form03.glCanvas1_MouseDown(sender, e);
        //    }
        //}

        internal void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition.X == e.X && lastMousePosition.Y == e.Y) { return; }

            //// operate camera
            //rotator.MouseMove(e.X, e.Y);

            this.lastMousePosition = new Point(e.X, e.Y);

            if (sender == this.glCanvas1)
            {
                this.form03.glCanvas1_MouseMove(sender, e);
            }
        }

        //internal void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    // operate camera
        //    rotator.MouseUp(e.X, e.Y);

        //    this.lastMousePosition = new Point(e.X, e.Y);

        //    if (sender == this.glCanvas1)
        //    {
        //        this.form03.glCanvas1_MouseUp(sender, e);
        //    }
        //}

    }
}
