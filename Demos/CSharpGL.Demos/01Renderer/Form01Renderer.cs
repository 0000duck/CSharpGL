﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form01Renderer : Form
    {
        public enum GeometryModel
        {
            Axis,
            BigDipper,
            Chain,
            Tetrahedron,
            Cube,
            Sphere,
            Teapot,
            Bezier1D,
            Bezier2D,
        }

        private GeometryModel selectedModel = GeometryModel.BigDipper;

        public GeometryModel SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (value != selectedModel)
                {
                    selectedModel = value;
                    if (this.pickableRendererPropertyGrid != null)
                    {
                        this.pickableRendererPropertyGrid.DisplayObject(this.rendererDict[value].PickableRenderer);
                        this.highlightRendererPropertyGrid.DisplayObject(this.rendererDict[value].Highlighter);
                        //this.frmIndexBufferPtrBoard.SetTarget(this.rendererDict[value].PickableRenderer.IndexBufferPtr);
                    }

                    //this.cameraUpdated = true;
                }
            }
        }

        private Dictionary<GeometryModel, HighlightedPickableRenderer> rendererDict = new Dictionary<GeometryModel, HighlightedPickableRenderer>();

        ///// <summary>
        ///// 要渲染的对象
        ///// </summary>
        //Renderer renderer;

        //bool cameraUpdated = true;

        //public bool CameraUpdated
        //{
        //    get { return cameraUpdated; }
        //}

        /// <summary>
        /// 摄像机
        /// </summary>
        private Camera camera;

        private FormBulletinBoard pickedGeometryBoard;
        private FormProperyGrid pickableRendererPropertyGrid;
        private FormProperyGrid highlightRendererPropertyGrid;
        private FormProperyGrid formPropertyGrid;

        public Form01Renderer()
        {
            InitializeComponent();

            this.RenderMode = RenderModes.Render;

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.TextColor = Color.White;

            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} {1} FPS: {2}", this.Name,
                //this.rendererDict[this.selectedModel].PickableRenderer.IndexBufferPtr.Mode, 
             this.rendererDict[this.selectedModel].PickableRenderer,
                this.glCanvas1.FPS.ToShortString());
        }

        public Color ClearColor { get; set; }

        private readonly object synObj = new object();

        public RenderModes RenderMode { get; set; }

        public Color TextColor { get; set; }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            lock (this.synObj)
            {
                RenderersDraw(this.RenderMode);

                DrawText(e);
            }
        }

        private void RenderersDraw(RenderModes renderMode, bool renderScene = true, bool renderUI = true)
        {
            var arg = new RenderEventArgs(renderMode, this.glCanvas1.ClientRectangle, this.camera, this.PickingGeometryType);
            if (renderMode == RenderModes.ColorCodedPicking)
            {
                if (renderScene)
                {
                    ColorCodedPicking.Render4Picking(arg, this.rendererDict[this.selectedModel].PickableRenderer as IColorCodedPicking);
                }
            }
            else if (renderMode == RenderModes.Render)
            {
                // 天蓝色背景
                //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
                OpenGL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

                OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

                if (renderScene) { SceneRenderersDraw(arg); }
                if (renderUI) { UIRenderersDraw(arg); }
            }
        }

        private void UIRenderersDraw(RenderEventArgs arg)
        {
            UIRoot uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Render(arg);
            }
        }

        private void SceneRenderersDraw(RenderEventArgs arg)
        {
            HighlightedPickableRenderer renderer = this.rendererDict[this.SelectedModel];
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

        private void DrawText(PaintEventArgs e)
        {
            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            PickedGeometry pickedGeometry = this.pickedGeometry;
            if (pickedGeometry != null)
            {
                string content = string.Format("[index: {0}]",
                    pickedGeometry.Indexes.PrintArray());
                //SizeF size = e.Graphics.MeasureString(content, font);
                Size size = this.uiText.Size;
                // make sure the text be displayed.
                int x = mousePosition.X - (size.Width / 2);
                if (x + (size.Width) >= this.glCanvas1.Width)
                { x = this.glCanvas1.Width - size.Width; }
                else if (x < 0)
                { x = 0; }
                // make sure the text be displayed.
                int y = this.glCanvas1.Height - mousePosition.Y - 1;
                if (y + size.Height + 1 >= this.glCanvas1.Height)
                { y = this.glCanvas1.Height - 15 - 5; }
                else if (y < 15) { if (y > 0) { y += 15; } else { y = 15; } }
                else { y += 15; }
                //OpenGL.DrawText(x, y,
                //    this.TextColor, "Courier New", fontSize,
                //    content);
                this.lblDrawText.Text = content;
                Padding margin = this.uiText.Margin;
                margin.Left = x; margin.Bottom = y;
                this.uiText.Margin = margin;
                this.uiText.Text = content;
                this.uiText.Enabled = true;
            }
            else
            {
                //OpenGL.DrawText(mousePosition.X,
                //    this.glCanvas1.Height - mousePosition.Y - 1,
                //    this.TextColor, "Courier New", fontSize,
                //    "");
                this.lblDrawText.Text = "";
                //this.uiText.Text = "";
                this.uiText.Enabled = false;
            }
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.MouseWheel(e.Delta);
            //cameraUpdated = true;
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lock (this.synObj)
                    {
                        string filename = dlgSaveFile.FileName;
                        Bitmap bitmap = Save2PictureHelper.ScreenShot(0, 0, this.glCanvas1.Width, this.glCanvas1.Height);
                        bitmap.Save(filename);
                        Process.Start("explorer", "/select, " + filename);
                    }
                }
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

        private void Form01Renderer_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in this.rendererDict)
            {
                item.Value.Dispose();
            }
        }
    }
}