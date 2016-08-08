﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain
    {
        private string[] timerEnabledSign = { "-", "/", "|", "\\", };
        private int timerEnableSignIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerEnableSignIndex++;
            if (timerEnableSignIndex >= timerEnabledSign.Length)
            { timerEnableSignIndex = 0; }
            this.lblTimerEnabled.Text = timerEnabledSign[timerEnableSignIndex];

            foreach (var sceneObject in this.scientificCanvas.Scene.ObjectList)
            {
                foreach (var obj in sceneObject)
                {
                    obj.Update(this.timer1.Interval);
                }
            }
        }

    }
}
