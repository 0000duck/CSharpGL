﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form15Scene : Form
    {

        private Scene scene;

        private FormProperyGrid formPropertyGrid;
        private UIText glText;
        private CSharpGL.TestHelpers.BlendFactorHelper blendFactorHelper = new TestHelpers.BlendFactorHelper();

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.rotator = rotator;
                this.scene = new Scene(camera);
            }
            {
                var glText = new UIText(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    new Padding(10, 10, 10, 10), new Size(550, 50), -100, 100);
                glText.Initialize();
                glText.SwitchList.Add(new ClearColorSwitch());// show black back color to indicate glText's area.
                glText.Text = "The quick brown fox jumps over the lazy dog!";
                this.glText = glText;
                this.scene.UIRoot.Children.Add(glText);

                var glAxis = new UIAxis(AnchorStyles.Right | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(70, 70), -100, 100);
                glAxis.Initialize();
                this.scene.UIRoot.Children.Add(glAxis);

                this.UpdateLabel();
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.glText);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }

        private void UpdateLabel()
        {
            this.lblCurrentBlend.Text = string.Format("glBlend({0}, {1});",
                this.glText.BlendSwitch.SourceFactor,
                this.glText.BlendSwitch.DestFactor);
        }
    }
}
