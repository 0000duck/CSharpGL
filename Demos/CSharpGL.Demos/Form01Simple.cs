﻿using CSharpGL.ModelAdapters;
using CSharpGL.Models;
using GLM;
using System;
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
    public partial class Form01Simple : Form
    {
        public enum GeometryModel
        {
            BigDipper,
            Chain,
        }

        private GeometryModel selectedModel = GeometryModel.Chain;
        public GeometryModel SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (value != selectedModel)
                {
                    selectedModel = value;
                    if (this.rendererPropertyGrid != null)
                    { this.rendererPropertyGrid.DisplayObject(this.rendererDict[value]); }
                    this.cameraUpdated = true;
                    this.UpdateMVP(this.rendererDict[this.selectedModel]);
                }
            }
        }

        Dictionary<GeometryModel, ModernRenderer> rendererDict = new Dictionary<GeometryModel, ModernRenderer>();

        ///// <summary>
        ///// 要渲染的对象
        ///// </summary>
        //ModernRenderer renderer;

        bool cameraUpdated = true;

        public bool CameraUpdated
        {
            get { return cameraUpdated; }
        }

        /// <summary>
        /// 控制Camera的旋转、进退
        /// </summary>
        SatelliteRotator rotator;
        /// <summary>
        /// 摄像机
        /// </summary>
        Camera camera;

        private FormBulletinBoard bulletinBoard;
        private FormProperyGrid rendererPropertyGrid;
        private FormProperyGrid cameraPropertyGrid;
        private FormProperyGrid formPropertyGrid;

        public Form01Simple()
        {
            InitializeComponent();

            this.RenderMode = RenderModes.Render;

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            // 天蓝色背景
            //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} {1}", this.Name, this.rendererDict[this.selectedModel].DrawMode);
        }

        public Color ClearColor { get; set; }

        RenderModes renderMode;
        private readonly object synObj = new object();
        private Point mousePosition;

        public RenderModes RenderMode
        {
            get { return renderMode; }
            set
            {
                if (value != renderMode)
                {
                    renderMode = value;
                    this.UpdateMVP(this.rendererDict[this.selectedModel]);
                }
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            lock (this.synObj)
            {
                if (this.RenderMode == RenderModes.ColorCodedPicking)
                { GL.ClearColor(1, 1, 1, 1); }
                else if (this.RenderMode == RenderModes.Render)
                { GL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f); }

                GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

                ModernRenderer renderer = this.rendererDict[this.SelectedModel];
                if (renderer != null)
                {
                    if (cameraUpdated)
                    {
                        UpdateMVP(renderer);
                        cameraUpdated = false;
                    }
                    renderer.Render(new RenderEventArgs(RenderMode, this.camera));
                }

                {
                    var pdata = new UnmanagedArray<Pixel>(1);
                    GL.ReadPixels(this.mousePosition.X, this.glCanvas1.Height - this.mousePosition.Y - 1, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pdata.Header);
                    Color c = pdata[0].ToColor();
                    c = Color.FromArgb(255, c);
                    this.lblReadColor.BackColor = c;
                    this.lblText.Text = string.Format("{0}: {1}", this.mousePosition, this.lblReadColor.BackColor);
                }
            }
        }

        private void UpdateMVP(ModernRenderer renderer)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            if (this.RenderMode == RenderModes.ColorCodedPicking)
            {
                IColorCodedPicking picking = renderer;
                picking.MVP = projectionMatrix * viewMatrix * modelMatrix;
            }
            else if (this.RenderMode == RenderModes.Render)
            {
                renderer.SetUniformValue("projectionMatrix", projectionMatrix);
                renderer.SetUniformValue("viewMatrix", viewMatrix);
                renderer.SetUniformValue("modelMatrix", modelMatrix);
            }
            else
            { throw new NotImplementedException(); }
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            if (rotator.MouseDownFlag)
            {
                rotator.MouseMove(e.X, e.Y);
                this.cameraUpdated = true;
            }

            lock (this.synObj)
            {
                IColorCodedPicking pickable = this.rendererDict[this.SelectedModel];
                pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                IPickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                    this.camera, e.X, e.Y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                if (pickedGeometry != null)
                {
                    this.bulletinBoard.SetContent(pickedGeometry.ToString());
                }
                else
                {
                    this.bulletinBoard.SetContent("picked nothing.");
                }
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);

            rotator.MouseUp(e.X, e.Y);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            cameraUpdated = true;
        }

        private void Form01ModernRenderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                Random random = new Random();
                var bufferables = new IBufferable[]{
                    new BigDipperAdapter(new BigDipper()),
                    new ChainModelAdapter(new ChainModel(random.Next(7, 100), 5, 5)),
                };
                var keys = new GeometryModel[] { GeometryModel.BigDipper, GeometryModel.Chain, };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    IBufferable bufferable = bufferables[i];
                    GeometryModel key = keys[i];
                    ShaderCode[] shaders = new ShaderCode[2];
                    shaders[0] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.vert"), ShaderType.VertexShader);
                    shaders[1] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.frag"), ShaderType.FragmentShader);
                    var propertyNameMap = new PropertyNameMap();
                    propertyNameMap.Add("in_Position", "position");
                    propertyNameMap.Add("in_Color", "color");
                    string positionNameInIBufferable = "position";
                    var renderer = ModernRendererFactory.GetModernRenderer(bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    renderer.Initialize();
                    GLSwitch lineWidthSwitch = new LineWidthSwitch(10.0f);
                    renderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10.0f);
                    renderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    renderer.SwitchList.Add(polygonModeSwitch);

                    this.rendererDict.Add(key, renderer);
                }
                this.SelectedModel = GeometryModel.Chain;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.bulletinBoard = frmBulletinBoard;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.rendererDict[this.SelectedModel]);
                frmPropertyGrid.Show();
                this.rendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.camera);
                frmPropertyGrid.Show();
                this.cameraPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }

        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lock (this.synObj)
                    {
                        Save2PictureHelper.Save2Picture(0, 0,
                            this.glCanvas1.Width, this.glCanvas1.Height,
                            dlgSaveFile.FileName);
                    }
                }
            }
        }

    }
}
