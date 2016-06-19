﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class ScientificCanvas : GLCanvas
    {

        void ScientificCanvas_Load(object sender, EventArgs e)
        {
            var camera = new Camera(new vec3(3, 1, 2), new vec3(), new vec3(0, 1, 0),
                 CameraType.Ortho, this.Width, this.Height);
            this.Scene = new Scene(camera);

            this.OpenGLDraw += ScientificCanvas_OpenGLDraw;
            this.MouseDown += ScientificCanvas_MouseDown;
            this.MouseMove += ScientificCanvas_MouseMove;
            this.MouseUp += ScientificCanvas_MouseUp;
            this.MouseWheel += ScientificCanvas_MouseWheel;
        }

    }
}
