﻿using System;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {
        private FirstPerspectiveManipulater cameraManipulater;

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeNodeContextMenuStrip();

            InitializeScene();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.Resize += this.scene.Resize;
            this.glCanvas1.OpenGLDraw += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.glCanvas1_OpenGLDraw);
        }

        private void InitializeScene()
        {
            var camera = new Camera(new vec3(1, 2, 3), new vec3(0, 0, 0), new vec3(0, 1, 0),
               CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.scene = new Scene(camera, this.glCanvas1);
            var cameraManipulater = new FirstPerspectiveManipulater();
            cameraManipulater.Bind(camera, this.glCanvas1);
            this.cameraManipulater = cameraManipulater;
        }

        private void InitializeNodeContextMenuStrip()
        {
            string[] names = Enum.GetNames(typeof(BuildInSceneObject));
            foreach (string item in names)
            {
                this.addSceneObjectToolStripMenuItem.DropDownItems.Add(item, null,
                    this.addSceneObjectToolStripMenuItem_Click);
            }
        }
    }
}