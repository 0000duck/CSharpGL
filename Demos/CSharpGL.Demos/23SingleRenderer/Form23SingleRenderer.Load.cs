﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form23SingleRenderer
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(3, 4, 5) * 4, new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
                var scene = new Scene(camera, this.glCanvas1);
                this.scene = scene;
                this.glCanvas1.Resize += this.scene.Resize;
            }

            var frmSelectRenderer = new FormSelectType(typeof(RendererBase), false,
                x => !x.IsAbstract && x.GetCustomAttributes(typeof(DemoRendererAttribute), true).Length > 0);
            frmSelectRenderer.StartPosition = FormStartPosition.CenterScreen;
            frmSelectRenderer.Size = new Size(600, 500);
            if (frmSelectRenderer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RendererTransporter transporter = DemoRendererFactory.Create(frmSelectRenderer.SelectedType);
                if (transporter == null)
                {
                    throw new Exception(string.Format(
                        "Please add this renderer type [{0}] to Factory.", frmSelectRenderer.SelectedType));
                }
                SceneObject obj = transporter.Renderer.WrapToSceneObject(generateBoundingBox: true);
                this.scene.RootObject.Children.Add(obj);
                this.scene.Camera.ZoomCamera(transporter.Renderer.GetBoundingBox());
                var frmProperty = new FormProperyGrid(transporter.Renderer);
                frmProperty.Show();
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}