﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 2D纹理
    /// </summary>
    public class sampler2D : IDisposable
    {
        private bool initialized;
        private uint[] id = new uint[1];

        /// <summary>
        /// 纹理名（用于标识一个纹理，由OpenGL指定），可在shader中用于指定uniform sampler2D纹理变量。
        /// </summary>
        public uint Id { get { return this.id[0]; } }

        public void Initialize(System.Drawing.Bitmap bitmap)
        {
            if (!this.initialized)
            {
                DoInitialize(bitmap);

                this.initialized = true;
            }
        }

        private void DoInitialize(System.Drawing.Bitmap bitmap)
        {
            // get texture's size.
            int targetTextureWidth;
            int targetTextureHeight;
            {
                //	Get the maximum texture size supported by OpenGL.
                int[] textureMaxSize = { 0 };
                OpenGL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

                //	Find the target width and height sizes, which is just the highest
                //	posible power of two that'll fit into the image.

                targetTextureWidth = textureMaxSize[0];
                for (int size = 1; size <= textureMaxSize[0]; size *= 2)
                {
                    if (bitmap.Width < size)
                    {
                        targetTextureWidth = size / 2;
                        break;
                    }
                    if (bitmap.Width == size)
                    {
                        targetTextureWidth = size;
                        break;
                    }
                }

                for (int size = 1; size <= textureMaxSize[0]; size *= 2)
                {
                    if (bitmap.Height < size)
                    {
                        targetTextureHeight = size / 2;
                        break;
                    }
                    if (bitmap.Height == size)
                    {
                        targetTextureHeight = size;
                        break;
                    }
                }
            }

            // scale bitmap to right size.
            System.Drawing.Bitmap targetImage = bitmap;
            if (bitmap.Width != targetTextureWidth || bitmap.Height != targetTextureWidth)
            {
                //  Resize the image.
                targetImage = (System.Drawing.Bitmap)bitmap.GetThumbnailImage(targetTextureWidth, targetTextureWidth, null, IntPtr.Zero);
            }

            // generate texture.
            {
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = targetImage.LockBits(new Rectangle(0, 0, targetImage.Width, targetImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                OpenGL.GenTextures(1, id);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, id[0]);
                OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA,
                    targetImage.Width, targetImage.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                    bitmapData.Scan0);
                //  Unlock the image.
                targetImage.UnlockBits(bitmapData);
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                /* Clamping to edges is important to prevent artifacts when scaling */
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP_TO_EDGE);
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP_TO_EDGE);
                /* Linear filtering usually looks best for text */
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
            }

            // release temp image.
            if (targetImage != bitmap)
            {
                targetImage.Dispose();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~sampler2D()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                } // end if

                // TODO: Dispose unmanaged resources.
                OpenGL.DeleteTextures(this.id.Length, this.id);
                this.id[0] = 0;

            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        public void Bind()
        {
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, this.id[0]);
        }

        public void Unbind()
        {
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
        }
    }
}
