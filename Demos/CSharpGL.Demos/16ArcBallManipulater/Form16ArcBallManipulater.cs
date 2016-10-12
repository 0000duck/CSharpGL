﻿using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form16ArcBallManipulater : Form
    {
        private SatelliteManipulater cameraManipulater;

        public Form16ArcBallManipulater()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '3')
            {
                var frmPropertyGrid = new FormProperyGrid(this);
                frmPropertyGrid.Show();
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render(RenderModes.Render);

            // render 'o' as a circle.
            {
                Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
                // Cross cursor shows where the mouse is.
                OpenGL.DrawText(mousePosition.X - offset.X,
                    this.glCanvas1.Height - (mousePosition.Y + offset.Y) - 1,
                    Color.Red, "Courier New", crossCursorSize, "o");
            }
        }

        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);
    }
}