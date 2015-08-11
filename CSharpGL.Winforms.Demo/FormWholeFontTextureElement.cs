﻿using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormWholeFontTextureElement : Form
    {
        SatelliteRotator rotator;
        ScientificCamera camera;
        WholeFontTextureElement element;
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public mat4 modelMatrix;
        private float rotation;

        public FormWholeFontTextureElement()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey("FormWholeFontTextureElement"))
            {
                this.camera = CameraDictionary.Instance["FormWholeFontTextureElement"];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add("FormWholeFontTextureElement", this.camera);
            }

            rotator = new SatelliteRotator(this.camera);
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.Load += FormWholeFontTextureElement_Load;

            //element = new WholeFontTextureElement("STLITI.TTF.png", "STLITI.TTF.xml");
            element = new WholeFontTextureElement("msyh.ttc.png", "msyh.ttc.xml");
            element.Initialize();

            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.Scale(e.Delta);
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            element.shaderProgram.Unbind();
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            if (element.blend)
            {
                GL.Disable(GL.GL_BLEND);
            }
        }
        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            uint texture = element.texture[0];
            GL.BindTexture(GL.GL_TEXTURE_2D, texture);

            if (element.blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }
            //rotation += 3.0f;
            modelMatrix = mat4.identity();// glm.rotate(rotation, new vec3(0, 1, 0));
            viewMatrix = this.camera.GetViewMat4();
            projectionMatrix = this.camera.GetProjectionMat4();
            mat4 matrix = projectionMatrix * viewMatrix * modelMatrix;

            ShaderProgram shaderProgram = element.shaderProgram;
            shaderProgram.Bind();
            shaderProgram.SetUniform(WholeFontTextureElement.strtex, texture);
            shaderProgram.SetUniform(WholeFontTextureElement.strcolor, 1.0f, 1.0f, 1.0f, 1.0f);
            shaderProgram.SetUniformMatrix4(WholeFontTextureElement.strtransformMatrix, matrix.to_array());
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            this.rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rotator.mouseDownFlag)
            {
                this.rotator.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.rotator.MouseUp(e.X, e.Y);
        }

        private void FormWholeFontTextureElement_Load(object sender, EventArgs e)
        {
            this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);

            MessageBox.Show("Use 'c' to switch camera types between perspective and ortho");
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                this.element.blend = !this.element.blend;
            }
            else if (e.KeyChar == 'c')
            {
                switch (this.camera.CameraType)
                {
                    case CameraTypes.Perspecitive:
                        this.camera.CameraType = CameraTypes.Ortho;
                        break;
                    case CameraTypes.Ortho:
                        this.camera.CameraType = CameraTypes.Perspecitive;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);
            }
        }

    }
}
