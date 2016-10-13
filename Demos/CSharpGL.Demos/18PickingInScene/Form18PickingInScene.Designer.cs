﻿namespace CSharpGL.Demos
{
    partial class Form18PickingInScene
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPickingGeometryType = new System.Windows.Forms.ComboBox();
            this.cmbRenderMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblDrawText = new System.Windows.Forms.Label();
            this.lblReadColor = new System.Windows.Forms.Label();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Picking Geometry Type:";
            // 
            // cmbPickingGeometryType
            // 
            this.cmbPickingGeometryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPickingGeometryType.FormattingEnabled = true;
            this.cmbPickingGeometryType.Location = new System.Drawing.Point(207, 15);
            this.cmbPickingGeometryType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPickingGeometryType.Name = "cmbPickingGeometryType";
            this.cmbPickingGeometryType.Size = new System.Drawing.Size(160, 23);
            this.cmbPickingGeometryType.TabIndex = 2;
            this.cmbPickingGeometryType.SelectedIndexChanged += new System.EventHandler(this.cmbPickingGeometryType_SelectedIndexChanged);
            // 
            // cmbRenderMode
            // 
            this.cmbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRenderMode.FormattingEnabled = true;
            this.cmbRenderMode.Location = new System.Drawing.Point(487, 15);
            this.cmbRenderMode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRenderMode.Name = "cmbRenderMode";
            this.cmbRenderMode.Size = new System.Drawing.Size(160, 23);
            this.cmbRenderMode.TabIndex = 4;
            this.cmbRenderMode.SelectedIndexChanged += new System.EventHandler(this.cmbRenderMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Render Mode:";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 91);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(5);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(1293, 724);
            this.glCanvas1.TabIndex = 0;
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblColor.Location = new System.Drawing.Point(13, 44);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(64, 20);
            this.lblColor.TabIndex = 5;
            // 
            // lblDrawText
            // 
            this.lblDrawText.AutoSize = true;
            this.lblDrawText.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDrawText.Location = new System.Drawing.Point(13, 68);
            this.lblDrawText.Name = "lblDrawText";
            this.lblDrawText.Size = new System.Drawing.Size(89, 20);
            this.lblDrawText.TabIndex = 6;
            this.lblDrawText.Text = "DrawText";
            // 
            // lblReadColor
            // 
            this.lblReadColor.AutoSize = true;
            this.lblReadColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblReadColor.Location = new System.Drawing.Point(84, 44);
            this.lblReadColor.Name = "lblReadColor";
            this.lblReadColor.Size = new System.Drawing.Size(149, 20);
            this.lblReadColor.TabIndex = 7;
            this.lblReadColor.Text = "Color At Mouse";
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "png";
            this.dlgSaveFile.FileName = "*.png";
            this.dlgSaveFile.Filter = "(*.png)|*.png";
            this.dlgSaveFile.RestoreDirectory = true;
            // 
            // Form18PickingInScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 828);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblDrawText);
            this.Controls.Add(this.lblReadColor);
            this.Controls.Add(this.cmbRenderMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPickingGeometryType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glCanvas1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form18PickingInScene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form18PickingInScene";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPickingGeometryType;
        private System.Windows.Forms.ComboBox cmbRenderMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblDrawText;
        private System.Windows.Forms.Label lblReadColor;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
    }
}