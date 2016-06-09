﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form13SimplexNoise : Form
    {

        /// <summary>
        /// 控制Camera的旋转、进退
        /// </summary>
        SatelliteRotator rotator;
        /// <summary>
        /// 摄像机
        /// </summary>
        Camera camera;

        public Form13SimplexNoise()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            {
                mat4 projectionMatrix = arg.Camera.GetProjectionMat4();
                mat4 viewMatrix = arg.Camera.GetViewMat4();
                mat4 modelMatrix = mat4.identity();
                this.targetRenderer.SetUniform("projectionMatrix", projectionMatrix);
                this.targetRenderer.SetUniform("viewMatrix", viewMatrix);
                this.targetRenderer.SetUniform("modelMatrix", modelMatrix);
                this.targetRenderer.Render(arg);
            }
            GLControl uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Layout();
                mat4 projection, view, model;
                projection = glAxis.GetOrthoProjection();
                vec3 position = (this.camera.Position - this.camera.Target).normalize();
                view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                float length = Math.Max(glAxis.Size.Width, glAxis.Size.Height) / 2;
                model = glm.scale(mat4.identity(),
                    new vec3(length, length, length));
                glAxis.Renderer.SetUniform("projectionMatrix", projection);
                glAxis.Renderer.SetUniform("viewMatrix", view);
                glAxis.Renderer.SetUniform("modelMatrix", model);

                glAxis.Render(arg);
            }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (camera != null)
            {
                camera.MouseWheel(e.Delta);
            }
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);

                this.uiRoot.Size = this.glCanvas1.Size;
            }
        }

    }
}
