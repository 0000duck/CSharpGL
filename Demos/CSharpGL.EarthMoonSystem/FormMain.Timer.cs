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

namespace CSharpGL.EarthMoonSystem
{
    public partial class FormMain
    {

        bool started = false;
        DateTime startTime;
        DateTime lastTime;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!started) { lastTime = DateTime.Now; startTime = lastTime; ; started = true; }

            var now = DateTime.Now;
            var elasped = now.Subtract(lastTime);
            lastTime = now;
            for (int i = 0; i < this.thingList.Count; i++)
            {
                this.thingList[i].Elapse(elasped.TotalMilliseconds * this.TimeSpeed);
            }
        }
    }
}
