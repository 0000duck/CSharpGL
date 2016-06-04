﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn00GLCanvas_Click(object sender, EventArgs e)
        {
            (new Form00GLCanvas()).Show();
        }

        private void btn01Renderer_Click(object sender, EventArgs e)
        {
            (new Form01Renderer()).Show();
        }

        private void btn02OrderIndependentTransparency_Click(object sender, EventArgs e)
        {
            (new Form02OrderIndependentTransparency()).Show();
        }

        private void btn04SimpleCompute_Click(object sender, EventArgs e)
        {
            (new Form04SimpleCompute()).Show();
        }

        private void btn05ParticleSimulator_Click(object sender, EventArgs e)
        {
            (new Form05ParticleSimulator()).Show();
        }

        private void btn06ImageProcessing_Click(object sender, EventArgs e)
        {
            (new Form06ImageProcessing()).Show();
        }

        private void btn07Billboard_Click(object sender, EventArgs e)
        {
            (new Form07Billboard()).Show();
        }

        private void btn08AnalyzedBillboard_Click(object sender, EventArgs e)
        {
            (new Form08AnalyzedBillboard()).Show();
        }

        private void btn09UIRenderer_Click(object sender, EventArgs e)
        {
            (new Form09UIRenderer()).Show();
        }

        private void btn10RaycastVolumeRenderer_Click(object sender, EventArgs e)
        {
            (new Form10RaycastVolumeRenderer()).Show();
        }

        private void btn11SharpFont_Click(object sender, EventArgs e)
        {
            (new Form1111SharpFont()).Show();
        }

    }
}
