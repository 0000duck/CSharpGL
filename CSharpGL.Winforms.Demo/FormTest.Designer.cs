﻿namespace CSharpGL.Winforms.Demo
{
    partial class FormTest
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
            this.btnBasis = new System.Windows.Forms.Button();
            this.btnCylinderElement = new System.Windows.Forms.Button();
            this.btnModernSingleTextureFont = new System.Windows.Forms.Button();
            this.btnPyramidElement = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnSatelliteRotation = new System.Windows.Forms.Button();
            this.btnWholeFontTextureElement = new System.Windows.Forms.Button();
            this.btnTranslateOnScreen = new System.Windows.Forms.Button();
            this.btnLegacySimpleUIRect = new System.Windows.Forms.Button();
            this.btnSimpleUIRect = new System.Windows.Forms.Button();
            this.btnSimpleUIAxis = new System.Windows.Forms.Button();
            this.btnSimpleUIColorPalette = new System.Windows.Forms.Button();
            this.btnSimpleUICube = new System.Windows.Forms.Button();
            this.btnDebugging = new System.Windows.Forms.Button();
            this.btnWell = new System.Windows.Forms.Button();
            this.btnAlwaysFaceCamera = new System.Windows.Forms.Button();
            this.btnFormPointSpriteFontElement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasis
            // 
            this.btnBasis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBasis.Location = new System.Drawing.Point(13, 15);
            this.btnBasis.Margin = new System.Windows.Forms.Padding(4);
            this.btnBasis.Name = "btnBasis";
            this.btnBasis.Size = new System.Drawing.Size(353, 29);
            this.btnBasis.TabIndex = 6;
            this.btnBasis.Text = "all kinds of basic codes";
            this.btnBasis.UseVisualStyleBackColor = true;
            this.btnBasis.Click += new System.EventHandler(this.btnBasis_Click);
            // 
            // btnCylinderElement
            // 
            this.btnCylinderElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCylinderElement.Location = new System.Drawing.Point(13, 163);
            this.btnCylinderElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnCylinderElement.Name = "btnCylinderElement";
            this.btnCylinderElement.Size = new System.Drawing.Size(353, 29);
            this.btnCylinderElement.TabIndex = 1;
            this.btnCylinderElement.Text = "CylinderElement+SatelliteRotation";
            this.btnCylinderElement.UseVisualStyleBackColor = true;
            this.btnCylinderElement.Click += new System.EventHandler(this.btnCylinderElement_Click);
            // 
            // btnModernSingleTextureFont
            // 
            this.btnModernSingleTextureFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModernSingleTextureFont.Location = new System.Drawing.Point(13, 237);
            this.btnModernSingleTextureFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnModernSingleTextureFont.Name = "btnModernSingleTextureFont";
            this.btnModernSingleTextureFont.Size = new System.Drawing.Size(353, 29);
            this.btnModernSingleTextureFont.TabIndex = 4;
            this.btnModernSingleTextureFont.Text = "FontElement";
            this.btnModernSingleTextureFont.UseVisualStyleBackColor = true;
            this.btnModernSingleTextureFont.Click += new System.EventHandler(this.btnFreeTypeTextVAOElement_Click);
            // 
            // btnPyramidElement
            // 
            this.btnPyramidElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPyramidElement.Location = new System.Drawing.Point(13, 52);
            this.btnPyramidElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnPyramidElement.Name = "btnPyramidElement";
            this.btnPyramidElement.Size = new System.Drawing.Size(353, 29);
            this.btnPyramidElement.TabIndex = 5;
            this.btnPyramidElement.Text = "PyramidElement";
            this.btnPyramidElement.UseVisualStyleBackColor = true;
            this.btnPyramidElement.Click += new System.EventHandler(this.btnPyramidElement_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCamera.Location = new System.Drawing.Point(13, 89);
            this.btnCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(353, 29);
            this.btnCamera.TabIndex = 3;
            this.btnCamera.Text = "PyramidElement+Camera(MouseWheel)";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnSatelliteRotation
            // 
            this.btnSatelliteRotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSatelliteRotation.Location = new System.Drawing.Point(13, 126);
            this.btnSatelliteRotation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSatelliteRotation.Name = "btnSatelliteRotation";
            this.btnSatelliteRotation.Size = new System.Drawing.Size(353, 29);
            this.btnSatelliteRotation.TabIndex = 2;
            this.btnSatelliteRotation.Text = "PyramidElement+SatelliteRotation";
            this.btnSatelliteRotation.UseVisualStyleBackColor = true;
            this.btnSatelliteRotation.Click += new System.EventHandler(this.btnSatelliteRotation_Click);
            // 
            // btnWholeFontTextureElement
            // 
            this.btnWholeFontTextureElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWholeFontTextureElement.Location = new System.Drawing.Point(13, 200);
            this.btnWholeFontTextureElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnWholeFontTextureElement.Name = "btnWholeFontTextureElement";
            this.btnWholeFontTextureElement.Size = new System.Drawing.Size(353, 29);
            this.btnWholeFontTextureElement.TabIndex = 0;
            this.btnWholeFontTextureElement.Text = "WholeFontTextureElement";
            this.btnWholeFontTextureElement.UseVisualStyleBackColor = true;
            this.btnWholeFontTextureElement.Click += new System.EventHandler(this.btnWholeFontTextureElement_Click);
            // 
            // btnTranslateOnScreen
            // 
            this.btnTranslateOnScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslateOnScreen.Location = new System.Drawing.Point(13, 274);
            this.btnTranslateOnScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnTranslateOnScreen.Name = "btnTranslateOnScreen";
            this.btnTranslateOnScreen.Size = new System.Drawing.Size(353, 29);
            this.btnTranslateOnScreen.TabIndex = 4;
            this.btnTranslateOnScreen.Text = "TranslateOnScreen";
            this.btnTranslateOnScreen.UseVisualStyleBackColor = true;
            this.btnTranslateOnScreen.Click += new System.EventHandler(this.btnTranslateOnScreen_Click);
            // 
            // btnLegacySimpleUIRect
            // 
            this.btnLegacySimpleUIRect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLegacySimpleUIRect.Location = new System.Drawing.Point(13, 311);
            this.btnLegacySimpleUIRect.Margin = new System.Windows.Forms.Padding(4);
            this.btnLegacySimpleUIRect.Name = "btnLegacySimpleUIRect";
            this.btnLegacySimpleUIRect.Size = new System.Drawing.Size(353, 29);
            this.btnLegacySimpleUIRect.TabIndex = 4;
            this.btnLegacySimpleUIRect.Text = "LegacySimpleUIRect";
            this.btnLegacySimpleUIRect.UseVisualStyleBackColor = true;
            this.btnLegacySimpleUIRect.Click += new System.EventHandler(this.btnLegacySimpleUIRect_Click);
            // 
            // btnSimpleUIRect
            // 
            this.btnSimpleUIRect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpleUIRect.Location = new System.Drawing.Point(13, 348);
            this.btnSimpleUIRect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIRect.Name = "btnSimpleUIRect";
            this.btnSimpleUIRect.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIRect.TabIndex = 4;
            this.btnSimpleUIRect.Text = "SimpleUIRect";
            this.btnSimpleUIRect.UseVisualStyleBackColor = true;
            this.btnSimpleUIRect.Click += new System.EventHandler(this.btnSimpleUIRect_Click);
            // 
            // btnSimpleUIAxis
            // 
            this.btnSimpleUIAxis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpleUIAxis.Location = new System.Drawing.Point(13, 385);
            this.btnSimpleUIAxis.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIAxis.Name = "btnSimpleUIAxis";
            this.btnSimpleUIAxis.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIAxis.TabIndex = 4;
            this.btnSimpleUIAxis.Text = "SimpleUIAxis";
            this.btnSimpleUIAxis.UseVisualStyleBackColor = true;
            this.btnSimpleUIAxis.Click += new System.EventHandler(this.btnSimpleUIAxis_Click);
            // 
            // btnSimpleUIColorPalette
            // 
            this.btnSimpleUIColorPalette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpleUIColorPalette.Location = new System.Drawing.Point(13, 459);
            this.btnSimpleUIColorPalette.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIColorPalette.Name = "btnSimpleUIColorPalette";
            this.btnSimpleUIColorPalette.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIColorPalette.TabIndex = 4;
            this.btnSimpleUIColorPalette.Text = "SimpleUIColorPalette";
            this.btnSimpleUIColorPalette.UseVisualStyleBackColor = true;
            this.btnSimpleUIColorPalette.Click += new System.EventHandler(this.btnSimpleUIColorPalette_Click);
            // 
            // btnSimpleUICube
            // 
            this.btnSimpleUICube.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpleUICube.Location = new System.Drawing.Point(13, 422);
            this.btnSimpleUICube.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUICube.Name = "btnSimpleUICube";
            this.btnSimpleUICube.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUICube.TabIndex = 4;
            this.btnSimpleUICube.Text = "SimpleUICube";
            this.btnSimpleUICube.UseVisualStyleBackColor = true;
            this.btnSimpleUICube.Click += new System.EventHandler(this.btnSimpleUICube_Click);
            // 
            // btnDebugging
            // 
            this.btnDebugging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugging.Location = new System.Drawing.Point(13, 496);
            this.btnDebugging.Margin = new System.Windows.Forms.Padding(4);
            this.btnDebugging.Name = "btnDebugging";
            this.btnDebugging.Size = new System.Drawing.Size(353, 29);
            this.btnDebugging.TabIndex = 4;
            this.btnDebugging.Text = "Debugging and profiling";
            this.btnDebugging.UseVisualStyleBackColor = true;
            this.btnDebugging.Click += new System.EventHandler(this.btnDebugging_Click);
            // 
            // btnWell
            // 
            this.btnWell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWell.Location = new System.Drawing.Point(13, 533);
            this.btnWell.Margin = new System.Windows.Forms.Padding(4);
            this.btnWell.Name = "btnWell";
            this.btnWell.Size = new System.Drawing.Size(353, 29);
            this.btnWell.TabIndex = 4;
            this.btnWell.Text = "Well";
            this.btnWell.UseVisualStyleBackColor = true;
            this.btnWell.Click += new System.EventHandler(this.btnWell_Click);
            // 
            // btnAlwaysFaceCamera
            // 
            this.btnAlwaysFaceCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlwaysFaceCamera.Enabled = false;
            this.btnAlwaysFaceCamera.Location = new System.Drawing.Point(13, 570);
            this.btnAlwaysFaceCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlwaysFaceCamera.Name = "btnAlwaysFaceCamera";
            this.btnAlwaysFaceCamera.Size = new System.Drawing.Size(353, 29);
            this.btnAlwaysFaceCamera.TabIndex = 4;
            this.btnAlwaysFaceCamera.Text = "Always Face Camera";
            this.btnAlwaysFaceCamera.UseVisualStyleBackColor = true;
            this.btnAlwaysFaceCamera.Click += new System.EventHandler(this.btnAlwaysFaceCamera_Click);
            // 
            // btnFormPointSpriteFontElement
            // 
            this.btnFormPointSpriteFontElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormPointSpriteFontElement.Location = new System.Drawing.Point(13, 607);
            this.btnFormPointSpriteFontElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormPointSpriteFontElement.Name = "btnFormPointSpriteFontElement";
            this.btnFormPointSpriteFontElement.Size = new System.Drawing.Size(353, 29);
            this.btnFormPointSpriteFontElement.TabIndex = 4;
            this.btnFormPointSpriteFontElement.Text = "FormPointSpriteFontElement";
            this.btnFormPointSpriteFontElement.UseVisualStyleBackColor = true;
            this.btnFormPointSpriteFontElement.Click += new System.EventHandler(this.btnFormPointSpriteFontElement_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 659);
            this.Controls.Add(this.btnWholeFontTextureElement);
            this.Controls.Add(this.btnCylinderElement);
            this.Controls.Add(this.btnSatelliteRotation);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.btnSimpleUICube);
            this.Controls.Add(this.btnFormPointSpriteFontElement);
            this.Controls.Add(this.btnAlwaysFaceCamera);
            this.Controls.Add(this.btnWell);
            this.Controls.Add(this.btnDebugging);
            this.Controls.Add(this.btnSimpleUIColorPalette);
            this.Controls.Add(this.btnSimpleUIAxis);
            this.Controls.Add(this.btnSimpleUIRect);
            this.Controls.Add(this.btnLegacySimpleUIRect);
            this.Controls.Add(this.btnTranslateOnScreen);
            this.Controls.Add(this.btnModernSingleTextureFont);
            this.Controls.Add(this.btnPyramidElement);
            this.Controls.Add(this.btnBasis);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "测试窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasis;
        private System.Windows.Forms.Button btnCylinderElement;
        private System.Windows.Forms.Button btnModernSingleTextureFont;
        private System.Windows.Forms.Button btnPyramidElement;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnSatelliteRotation;
        private System.Windows.Forms.Button btnWholeFontTextureElement;
        private System.Windows.Forms.Button btnTranslateOnScreen;
        private System.Windows.Forms.Button btnLegacySimpleUIRect;
        private System.Windows.Forms.Button btnSimpleUIRect;
        private System.Windows.Forms.Button btnSimpleUIAxis;
        private System.Windows.Forms.Button btnSimpleUIColorPalette;
        private System.Windows.Forms.Button btnSimpleUICube;
        private System.Windows.Forms.Button btnDebugging;
        private System.Windows.Forms.Button btnWell;
        private System.Windows.Forms.Button btnAlwaysFaceCamera;
        private System.Windows.Forms.Button btnFormPointSpriteFontElement;
    }
}