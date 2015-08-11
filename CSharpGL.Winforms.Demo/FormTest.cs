﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnUnmanagedArray_Click(object sender, EventArgs e)
        {
            UnmanagedArrayTest.TypicalScene();
            string message = string.Format("{0}", "All successfully done!");
            MessageBox.Show(message, "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnPyramidVAOElement_Click(object sender, EventArgs e)
        {
            (new FormPyramidVAOElement()).Show();
        }

        private void btnScientificCamera_Click(object sender, EventArgs e)
        {
            (new FormScientificCamera()).Show();
        }

        private void btnSatelliteRotation_Click(object sender, EventArgs e)
        {
            (new FormSatelliteRotation()).Show();
        }

        private void btnCylinderVAOElement_Click(object sender, EventArgs e)
        {
            (new FormCylinderVAOElement()).Show();
        }

        private void btnWholeFontTextureElement_Click(object sender, EventArgs e)
        {
            (new FormWholeFontTextureElement()).Show();
        }

        private void btnFreeTypeTextVAOElement_Click(object sender, EventArgs e)
        {
            (new FormFontElement()).Show();
        }

    }
}
