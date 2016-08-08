﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form06ImageProcessing : Form
    {

        private SatelliteManipulater rotator;

        public Form06ImageProcessing()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            //GL.ClearColor(0, 0, 0, 0);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'o')
            {
                if (this.openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    {
                        RendererBase renderer = (this.obj.Renderer as RendererBaseComponent).Renderer;
                        renderer.Dispose();
                    }
                    {
                        var renderer = new ImageProcessingRenderer(this.openTextureDlg.FileName);
                        renderer.Initialize();
                        (this.obj.Renderer as RendererBaseComponent).Renderer = renderer;
                    }
                }
            }
            else if (e.KeyChar == 'c')
            {
                var renderer = (this.obj.Renderer as RendererBaseComponent).Renderer as ImageProcessingRenderer;
                renderer.SwitchDisplayImage(true);
            }
            else if (e.KeyChar == 'x')
            {
                var renderer = (this.obj.Renderer as RendererBaseComponent).Renderer as ImageProcessingRenderer;
                renderer.SwitchDisplayImage(false);
            }
        }

    }
}
