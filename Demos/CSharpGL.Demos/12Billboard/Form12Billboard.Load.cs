﻿using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form12Billboard : Form
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
                const int gridsPer2Unit = 20;
                const int scale = 2;
                var ground = GroundRenderer.Create(new GroundModel(gridsPer2Unit * scale));
                ground.Scale = new vec3(scale, scale, scale);
                var obj = new SceneObject();
                obj.Renderer = ground;
                this.scene.RootObject.Children.Add(obj);
            }
            {
                SimpleRenderer movableRenderer = SimpleRenderer.Create(new Teapot());
                movableRenderer.RotationAxis = new vec3(0, 1, 0);
                movableRenderer.Scale = new vec3(0.1f, 0.1f, 0.1f);
                this.movableRenderer = movableRenderer;
                SceneObject obj = movableRenderer.WrapToSceneObject();
                this.scene.RootObject.Children.Add(obj);
            }
            {
                BillboardRenderer billboardRenderer = BillboardRenderer.Create(new BillboardModel());
                SceneObject obj = billboardRenderer.WrapToSceneObject(new UpdateBillboardPosition(movableRenderer));
                this.scene.RootObject.Children.Add(obj);
            }
            {
                LabelRenderer labelRenderer = LabelRenderer.Create();
                labelRenderer.Text = "Teapot - CSharpGL";
                SceneObject obj = labelRenderer.WrapToSceneObject(new UpdateLabelPosition(movableRenderer));
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
            {
                this.scene.Start();
            }
        }

        private string[] timerEnabledSign = { "-", "/", "|", "\\", };
        private int timerEnableSignIndex = 0;
        private RendererBase movableRenderer;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerEnableSignIndex++;
            if (timerEnableSignIndex >= timerEnabledSign.Length)
            { timerEnableSignIndex = 0; }
            this.lblTimerEnabled.Text = timerEnabledSign[timerEnableSignIndex];

            //foreach (var sceneObject in this.scene.RootObject.Children)
            //{
            //    foreach (var obj in sceneObject)
            //    {
            //        obj.Update(this.timer1.Interval);
            //    }
            //}
        }
    }
}