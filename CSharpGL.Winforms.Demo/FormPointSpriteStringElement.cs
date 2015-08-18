﻿using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.SceneElements;
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
    public partial class FormPointSpriteStringElement : Form
    {
        float translateX = 0, translateY = 0, translateZ = 0;

        SatelliteRotator rotator;
        ScientificCamera camera;
        PointSpriteStringElement textElement;
        PyramidElement pyramidElement;

        public FormPointSpriteStringElement()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            {
                this.camera = CameraDictionary.Instance[this.GetType().Name];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            rotator = new SatelliteRotator(this.camera);
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            textElement = new PointSpriteStringElement("good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good good good good good!", new vec3(0, 0, 0));
            textElement = new PointSpriteStringElement("good good good good good good good good good good good!", new vec3(0, 0, 0));
            //textElement = new PointSpriteFontElement("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", new vec3(0, 0, 0));
            textElement.Initialize();

            textElement.BeforeRendering += textElement_BeforeRendering;
            textElement.AfterRendering += textElement_AfterRendering;

            pyramidElement = new PyramidElement();
            pyramidElement.Initialize();
            pyramidElement.BeforeRendering += pyramidElement_BeforeRendering;
            pyramidElement.AfterRendering += pyramidElement_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        void pyramidElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            pyramidElement.shaderProgram.Unbind();
        }

        void pyramidElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 modelMatrix = mat4.identity();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 projectionMatrix = this.camera.GetProjectionMat4();
            projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            ShaderProgram shaderProgram = pyramidElement.shaderProgram;
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strmodelMatrix, modelMatrix.to_array());
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        void textElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            textElement.shaderProgram.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_POINT_SMOOTH);
        }

        void textElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 modelMatrix = mat4.identity();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 projectionMatrix = this.camera.GetProjectionMat4();
            projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Enable(GL.GL_POINT_SPRITE_ARB);
            //GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);//TODO: test TexEnvi()
            GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
            GL.Enable(GL.GL_POINT_SMOOTH);
            GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
            GL.Enable(GL.GL_BLEND);
            GL.BlendEquation(GL.GL_FUNC_ADD_EXT);
            GL.BlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

            GL.BindTexture(GL.GL_TEXTURE_2D, textElement.texture[0]);

            ShaderProgram shaderProgram = textElement.shaderProgram;
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PointSpriteStringElement.strmodelMatrix, modelMatrix.to_array());
            shaderProgram.SetUniform(PointSpriteStringElement.strpointSize, textElement.PointSize);
            shaderProgram.SetUniform(PointSpriteStringElement.strtex, textElement.texture[0]);
            shaderProgram.SetUniform(PointSpriteStringElement.strtextColor, textElement.textColor.x, textElement.textColor.y, textElement.textColor.z);
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            pyramidElement.Render(Objects.RenderModes.Render);
            textElement.Render(Objects.RenderModes.Render);
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

        private void FormAlwaysFaceCamera_Load(object sender, EventArgs e)
        {
            this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);

            MessageBox.Show("Use 'c' to switch camera types between perspective and ortho");
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float interval = 0.1f;

            if (e.KeyChar == 'c')
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
            else if (e.KeyChar == 'w')
            {
                translateY += interval;
            }
            else if (e.KeyChar == 's')
            {
                translateY -= interval;
            }
            else if (e.KeyChar == 'a')
            {
                translateX -= interval;
            }
            else if (e.KeyChar == 'd')
            {
                translateX += interval;
            }
            else if (e.KeyChar == 'q')
            {
                translateZ -= interval;
            }
            else if (e.KeyChar == 'e')
            {
                translateZ += interval;
            }
        }
    }
}
