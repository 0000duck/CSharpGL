﻿namespace CSharpGL.Demos
{
    partial class FormMain
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
            this.btnForm00GLCanvas = new System.Windows.Forms.Button();
            this.btnForm01Simple = new System.Windows.Forms.Button();
            this.btnForm02EmitNormalLine = new System.Windows.Forms.Button();
            this.btnForm03UnProjection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm00GLCanvas
            // 
            this.btnForm00GLCanvas.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm00GLCanvas.Location = new System.Drawing.Point(12, 12);
            this.btnForm00GLCanvas.Name = "btnForm00GLCanvas";
            this.btnForm00GLCanvas.Size = new System.Drawing.Size(269, 37);
            this.btnForm00GLCanvas.TabIndex = 0;
            this.btnForm00GLCanvas.Text = "Form00 GLCanvas";
            this.btnForm00GLCanvas.UseVisualStyleBackColor = true;
            this.btnForm00GLCanvas.Click += new System.EventHandler(this.btnForm00GLCanvas_Click);
            // 
            // btnForm01Simple
            // 
            this.btnForm01Simple.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm01Simple.Location = new System.Drawing.Point(12, 55);
            this.btnForm01Simple.Name = "btnForm01Simple";
            this.btnForm01Simple.Size = new System.Drawing.Size(269, 37);
            this.btnForm01Simple.TabIndex = 0;
            this.btnForm01Simple.Text = "Form01 Simple";
            this.btnForm01Simple.UseVisualStyleBackColor = true;
            this.btnForm01Simple.Click += new System.EventHandler(this.btnForm01Simple_Click);
            // 
            // btnForm02EmitNormalLine
            // 
            this.btnForm02EmitNormalLine.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm02EmitNormalLine.Location = new System.Drawing.Point(12, 98);
            this.btnForm02EmitNormalLine.Name = "btnForm02EmitNormalLine";
            this.btnForm02EmitNormalLine.Size = new System.Drawing.Size(269, 37);
            this.btnForm02EmitNormalLine.TabIndex = 0;
            this.btnForm02EmitNormalLine.Text = "Form02 EmitNormalLine";
            this.btnForm02EmitNormalLine.UseVisualStyleBackColor = true;
            this.btnForm02EmitNormalLine.Click += new System.EventHandler(this.btnForm02EmitNormalLine_Click);
            // 
            // btnForm03UnProjection
            // 
            this.btnForm03UnProjection.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm03UnProjection.Location = new System.Drawing.Point(12, 141);
            this.btnForm03UnProjection.Name = "button1";
            this.btnForm03UnProjection.Size = new System.Drawing.Size(269, 37);
            this.btnForm03UnProjection.TabIndex = 0;
            this.btnForm03UnProjection.Text = "Form03 UnProjection";
            this.btnForm03UnProjection.UseVisualStyleBackColor = true;
            this.btnForm03UnProjection.Click += new System.EventHandler(this.btnForm03UnProjection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 545);
            this.Controls.Add(this.btnForm03UnProjection);
            this.Controls.Add(this.btnForm02EmitNormalLine);
            this.Controls.Add(this.btnForm01Simple);
            this.Controls.Add(this.btnForm00GLCanvas);
            this.Name = "FormMain";
            this.Text = "CSharpGL Test/Demo Panel - http://bitzhuwei.cnblogs.com";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm00GLCanvas;
        private System.Windows.Forms.Button btnForm01Simple;
        private System.Windows.Forms.Button btnForm02EmitNormalLine;
        private System.Windows.Forms.Button btnForm03UnProjection;
    }
}