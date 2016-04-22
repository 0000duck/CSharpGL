﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonModeSwitch : GLSwitch
    {

        int[] originalPolygonMode = new int[2];

        public PolygonModeSwitch() : this(PolygonModes.Filled) { }

        public PolygonModeSwitch(PolygonModes mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            return string.Format("Polygon Mode: {0}", Mode);
        }

        public override void On()
        {
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, Mode);
        }

        public override void Off()
        {
            if (originalPolygonMode[0] == originalPolygonMode[1])
            {
                GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
            }
            else
            {
                GL.PolygonMode(PolygonModeFaces.Front, (PolygonModes)originalPolygonMode[0]);
                GL.PolygonMode(PolygonModeFaces.Back, (PolygonModes)originalPolygonMode[1]);
            }
        }

        public PolygonModes Mode { get; set; }
    }

}
