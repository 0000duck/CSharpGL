﻿namespace CSharpGL.Demos
{
    partial class Form12Billboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openTextureDlg = new System.Windows.Forms.OpenFileDialog();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            this.lblCubePosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // openTextureDlg
            // 
            this.openTextureDlg.Filter = "Image File(*.TTF;*.OTF)|*.TTF;*.OTF";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 33);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(757, 502);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            // 
            // lblCubePosition
            // 
            this.lblCubePosition.AutoSize = true;
            this.lblCubePosition.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCubePosition.Location = new System.Drawing.Point(9, 9);
            this.lblCubePosition.Name = "lblCubePosition";
            this.lblCubePosition.Size = new System.Drawing.Size(179, 20);
            this.lblCubePosition.TabIndex = 4;
            this.lblCubePosition.Text = "Cube Pos: x, y, z";
            // 
            // Form12Billboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 548);
            this.Controls.Add(this.lblCubePosition);
            this.Controls.Add(this.glCanvas1);
            this.Name = "Form12Billboard";
            this.Text = "Form12Billboard";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openTextureDlg;
        private System.Windows.Forms.Label lblCubePosition;
    }
}