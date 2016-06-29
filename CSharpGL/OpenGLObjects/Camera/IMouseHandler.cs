﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Handle mouse events for <see cref="CameraManipupater"/>.
    /// </summary>
    public interface IMouseHandler
    {
        void canvas_MouseWheel(object sender, MouseEventArgs e);

        void canvas_MouseUp(object sender, MouseEventArgs e);

        void canvas_MouseMove(object sender, MouseEventArgs e);

        //void SetBounds(int width, int height);

        void canvas_MouseDown(object sender, MouseEventArgs e);
    }
}
