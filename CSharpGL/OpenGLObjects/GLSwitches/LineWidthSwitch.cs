﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class LineWidthSwitch : GLSwitch
    {
        static float min;
        static float max;

        static LineWidthSwitch()
        {
            OpenGL.LineWidthRange(out min, out max);
            //OpenGL.GetFloat(GetTarget.LineWidthGranularity, lineWidthRange);//TODO: what does LineWidthGranularity mean?
        }

        public float MinLineWidth { get; private set; }
        public float MaxLineWidth { get; private set; }

        public float LineWidth { get; set; }

        public LineWidthSwitch() : this(1.0f) { }

        public LineWidthSwitch(float lineWidth)
        {
            this.LineWidth = lineWidth;
            this.MinLineWidth = min;
            this.MaxLineWidth = max;
        }

        float[] original = new float[1];

        public override string ToString()
        {
            return string.Format("Line Width: {0}", LineWidth);
        }

        protected override void SwitchOn()
        {
            OpenGL.GetFloat(GetTarget.LineWidth, original);

            OpenGL.LineWidth(LineWidth);
        }

        protected override void SwitchOff()
        {
            OpenGL.LineWidth(original[0]);
        }
    }
}
