﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 含有字形贴图及其配置信息的单例类型。
    /// </summary>
    public sealed class FontResource : IDisposable
    {
        private static FontResource defaultInstance = new FontResource();

        public static FontResource Default
        {
            get
            {
                return defaultInstance;
            }
        }

        public samplerValue GetSamplerValue()
        {
            return new samplerValue(
                BindTextureTarget.Texture2D,
                this.FontTextureId,
                OpenGL.GL_TEXTURE0);
        }

        public const string strTTFTexture = "TTFTexture";
        public const string strFontHeight = "FontHeight";
        public const string strFirstChar = "FirstChar";
        public const string strLastChar = "LastChar";

        private FontResource()
        {
            {
                var bitmap = ManifestResourceLoader.LoadBitmap(@"GlyphTextures\ANTQUAI.TTF.png");
                // generate texture.
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(OpenGL.GL_TEXTURE0);
                var ids = new uint[1];
                OpenGL.GenTextures(1, ids);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, ids[0]);
                /* Clamping to edges is important to prevent artifacts when scaling */
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP_TO_EDGE);
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP_TO_EDGE);
                /* Linear filtering usually looks best for text */
                OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
                OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA,
                    bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                    bitmapData.Scan0);
                //  Unlock the image.
                bitmap.UnlockBits(bitmapData);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
                this.TextureSize = bitmap.Size;
                this.FontTextureId = ids[0];
                bitmap.Dispose();
            }
            {
                string xmlContent = ManifestResourceLoader.LoadTextFile(@"GlyphTextures\ANTQUAI.TTF.xml");
                XElement xElement = XElement.Parse(xmlContent, LoadOptions.None);
                this.FontHeight = int.Parse(xElement.Attribute(strFontHeight).Value);
                this.FirstChar = (char)int.Parse(xElement.Attribute(strFirstChar).Value);
                this.LastChar = (char)int.Parse(xElement.Attribute(strLastChar).Value);
                this.CharInfoDict = CharacterInfoDictHelper.Parse(
                    xElement.Element(CharacterInfoDictHelper.strCharacterInfoDict));
            }
        }

        /// <summary>
        /// 字形高度
        /// </summary>
        public int FontHeight { get; set; }

        /// <summary>
        /// 第一个字符
        /// </summary>
        public char FirstChar { get; set; }

        /// <summary>
        /// 最后一个字符
        /// </summary>
        public char LastChar { get; set; }

        ///// <summary>
        ///// 含有各个字形的贴图。
        ///// </summary>
        //private System.Drawing.Bitmap FontBitmap;
        public Size TextureSize { get; set; }

        /// <summary>
        /// 含有各个字形的贴图的Id。
        /// </summary>
        public uint FontTextureId { get; set; }

        /// <summary>
        /// 记录每个字符在<see cref="FontBitmap"/>里的偏移量及其字形的宽高。
        /// </summary>
        public FullDictionary<char, CharacterInfo> CharInfoDict { get; private set; }

        ~FontResource()
        {
            this.Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            var ids = new uint[] { FontTextureId, };
            OpenGL.DeleteTextures(ids.Length, ids);

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
