﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Manages a scene to be rendered and updated.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Scene : IDisposable
    {
        //private UIRoot cursorRoot = new UIRoot();
        private UIRoot rootUI = new UIRoot();

        private SceneRootObject rootObject;

        private ViewPort rootViewPort;

        /// <summary>
        /// Manages a scene to be rendered and updated.
        /// </summary>
        /// <param name="camera">Camera of the scene</param>
        /// <param name="canvas">Canvas that this scene binds to.</param>
        /// <param name="objects">Objects to be rendered</param>
        public Scene(ICamera camera, ICanvas canvas, params SceneObject[] objects)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.Camera = camera;
            this.Canvas = canvas;
            var rootObject = new SceneRootObject(this);
            rootObject.Children.AddRange(objects);
            this.rootObject = rootObject;
            this.rootViewPort = new ViewPort(camera,
                AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                new Padding(0, 0, 0, 0), canvas.Size);
            //var cursor = UICursor.CreateDefault();
            //cursor.Enabled = false;
            //this.cursorRoot.Children.Add(cursor);
            //this.Cursor = cursor;
        }

        private const string strScene = "Scene";

        /// <summary>
        /// camera of the scene.
        /// </summary>
        [Category(strScene)]
        [Description("camera of the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICamera Camera { get; private set; }

        /// <summary>
        /// Canvas that this scene binds to.
        /// </summary>
        [Category(strScene)]
        [Description("Canvas that this scene binds to.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICanvas Canvas { get; private set; }

        /// <summary>
        /// background color.
        /// </summary>
        [Category(strScene)]
        [Description("background color.")]
        public Color ClearColor { get; set; }

        ///// <summary>
        ///// OpenGL UI for cursor.
        ///// </summary>
        //public UICursor Cursor { get; set; }

        /// <summary>
        /// Root object of all objects to be rendered in the scene.
        /// </summary>
        [Category(strScene)]
        [Description("Root object of all objects to be rendered in the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneRootObject RootObject { get { return this.rootObject; } }

        /// <summary>
        /// Root object of all viewports to be rendered in the scene.
        /// </summary>
        [Category(strScene)]
        [Description("Root object of all viewports to be rendered in the scene.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ViewPort RootViewPort { get { return this.rootViewPort; } }

        /// <summary>
        /// hosts all UI renderers.
        /// </summary>
        [Category(strScene)]
        [Description("hosts all UI renderers.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public UIRoot RootUI { get { return this.rootUI; } }

        /// <summary>
        /// Please bind this method to Control.Resize event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Resize(object sender, EventArgs e)
        {
            var control = sender as ICanvas;
            if (control == null) { throw new ArgumentException(); }

            this.Camera.Resize(control.Size.Width, control.Size.Height);

            this.rootUI.Size = control.Size;
            //this.cursorRoot.Size = control.Size;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Running ? "Scripts running" : "Scripts not running");
        }
    }
}