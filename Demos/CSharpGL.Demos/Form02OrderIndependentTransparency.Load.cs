﻿using System;
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
    public partial class Form02OrderIndependentTransparency : Form
    {


        private void Form02OrderIndependentTransparency_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new Teapot();
                var OITRenderer = new OrderIndependentTransparencyRenderer(
                    bufferable, Teapot.strPosition, Teapot.strNormal);
                OITRenderer.Name = "OIT Renderer";
                {
                    GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                    OITRenderer.BuildListsRenderer.SwitchList.Add(lineWidthSwitch);
                    OITRenderer.ResolveListsRenderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                    OITRenderer.BuildListsRenderer.SwitchList.Add(pointSizeSwitch);
                    OITRenderer.ResolveListsRenderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    OITRenderer.BuildListsRenderer.SwitchList.Add(polygonModeSwitch);
                    OITRenderer.ResolveListsRenderer.SwitchList.Add(polygonModeSwitch);
                    GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(uint.MaxValue);
                    OITRenderer.BuildListsRenderer.SwitchList.Add(primitiveRestartSwitch);
                    OITRenderer.ResolveListsRenderer.SwitchList.Add(primitiveRestartSwitch);
                }
                this.OITRenderer = OITRenderer;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.OITRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
