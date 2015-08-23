﻿using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.UIs;
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
    public partial class FormSimpleUICube : Form
    {

        SimpleUICube uiLeftBottomRect;
        SimpleUICube uiLeftTopRect;
        SimpleUICube uiRightBottomRect;
        SimpleUICube uiRightTopRect;

        AxisElement axisElement;

        ScientificCamera camera;

        SatelliteRotator satelliteRoration;

        public FormSimpleUICube()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            {
                this.camera = CameraDictionary.Instance[this.GetType().Name];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            satelliteRoration = new SatelliteRotator(camera);

            Padding padding = new System.Windows.Forms.Padding(40, 40, 40, 40);
            Size size = new Size(100, 100);
            //Size size = new Size(5, 5);
            IUILayoutParam param;
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            uiLeftBottomRect = new SimpleUICube(param);
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            uiLeftTopRect = new SimpleUICube(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            uiRightBottomRect = new SimpleUICube(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            uiRightTopRect = new SimpleUICube(param);

            uiLeftBottomRect.Initialize();
            uiLeftTopRect.Initialize();
            uiRightBottomRect.Initialize();
            uiRightTopRect.Initialize();

            uiLeftBottomRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            uiLeftTopRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            uiRightBottomRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            uiRightTopRect.BeforeRendering += SimpleUIRect_BeforeRendering;

            uiLeftBottomRect.AfterRendering += SimpleUIRect_AfterRendering;
            uiLeftTopRect.AfterRendering += SimpleUIRect_AfterRendering;
            uiRightBottomRect.AfterRendering += SimpleUIRect_AfterRendering;
            uiRightTopRect.AfterRendering += SimpleUIRect_AfterRendering;

            axisElement = new AxisElement();
            axisElement.Initialize();
            axisElement.BeforeRendering += axisElement_BeforeRendering;
            axisElement.AfterRendering += axisElement_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        void SimpleUIRect_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUICube element = sender as SimpleUICube;

            element.shaderProgram.Unbind();
        }

        void SimpleUIRect_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUICube element = sender as SimpleUICube;

            mat4 projectionMatrix, viewMatrix, modelMatrix;

            float maxDepth = (float)Math.Sqrt(3);
            element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, this.camera, maxDepth);

            ShaderProgram shaderProgram = element.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(SimpleUICube.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUICube.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUICube.strmodelMatrix, modelMatrix.to_array());
        }

        void axisElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            AxisElement element = sender as AxisElement;

            element.shaderProgram.Unbind();
        }

        void axisElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.UpdateMVP(mvp);
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormTranslateOnScreen_Load(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0}",
                "Use 'c' to switch camera types between perspective and ortho"));
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            axisElement.Render(Objects.RenderModes.Render);

            uiLeftBottomRect.Render(Objects.RenderModes.Render);
            uiLeftTopRect.Render(Objects.RenderModes.Render);
            uiRightBottomRect.Render(Objects.RenderModes.Render);
            uiRightTopRect.Render(Objects.RenderModes.Render);
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }


        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            satelliteRoration.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (satelliteRoration.mouseDownFlag)
            {
                satelliteRoration.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            satelliteRoration.MouseUp(e.X, e.Y);
        }

        private void PrintCameraInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("position:{0}", this.camera.Position));
            builder.Append(string.Format(" target:{0}", this.camera.Target));
            builder.Append(string.Format(" up:{0}", this.camera.UpVector));
            builder.Append(string.Format(" camera type: {0}", this.camera.CameraType));

            this.txtInfo.Text = builder.ToString();
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            }
        }
    }
}
