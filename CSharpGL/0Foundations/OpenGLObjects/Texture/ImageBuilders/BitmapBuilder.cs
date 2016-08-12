﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content with Bitmap.
    /// </summary>
    public class NewBitmapBuilder : NewImageBuilder
    {
        private System.Drawing.Bitmap bitmap;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        public NewBitmapBuilder(System.Drawing.Bitmap bitmap)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        public override void Build(BindTextureTarget target)
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            if (target == BindTextureTarget.Texture1D)
            {
                OpenGL.TexImage1D((uint)target, 0, (int)OpenGL.GL_RGBA, bitmap.Width, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else if (target == BindTextureTarget.Texture2D)
            {
                OpenGL.TexImage2D((uint)target, 0, (int)OpenGL.GL_RGBA, bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else
            { throw new NotImplementedException(); }

            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
        }
    }
}
