﻿using System;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form04SimpleCompute : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                SimpleComputeRenderer renderer = SimpleComputeRenderer.Create();
                renderer.Initialize();
                SceneObject obj = renderer.WrapToSceneObject();
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("S: Scene's property grid.");
                builder.AppendLine("C: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}