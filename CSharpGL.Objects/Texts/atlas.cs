﻿using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    ///**
    // * The atlas struct holds a texture that contains the visible US-ASCII characters
    // * of a certain font rendered with a certain character height.
    // * It also contains an array that contains all the information necessary to
    // * generate the appropriate vertex and texture coordinates for each character.
    // *
    // * After the constructor is run, you don't need to use any FreeType functions anymore.
    // */

    /// <summary>
    ///
    /// </summary>
    struct CharacterInformation
    {
        public float advanceX;	// advance.x
        public float advanceY;	// advance.y

        public float bitmapWidth;	// bitmap.width;
        public float bitmapHeight;	// bitmap.height;

        public float bitmapLeft;	// bitmap_left;
        public float bitmapTop;	// bitmap_top;

        public float xoffset;	// x offset of glyph in texture coordinates
        public float yoffset;	// y offset of glyph in texture coordinates
    } //c[128];		// character information

    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    class Atlas
    {
        public uint[] tex = new uint[1];		// texture object

        public int widthOfTexture;			// width of texture in pixels
        public int heightOfTexture;			// height of texture in pixels

        public CharacterInformation[] characterInfos = new CharacterInformation[128];
        int[] MaxWidth = new int[1];

        public Atlas(FreeTypeFace face, int fontHeight, Shaders.ShaderProgram shaderProgram)
        {
            //	Get the maximum texture size supported by GL.
            GL.GetInteger(GetTarget.MaxTextureSize, MaxWidth);

            /* Find minimum size for a texture holding all visible ASCII characters */
            FindTextureSize(face, fontHeight);

            /* Create a texture that will be used to hold all ASCII glyphs */
            CreateTextureObject(shaderProgram);

            /* Paste all glyph bitmaps into the texture, remembering the offset */
            int xoffset = 0;
            int yoffset = 0;

            int newRowHeight = 0;

            for (int i = 32; i < 128; i++)
            {
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i), fontHeight);

                if (xoffset + bmpGlyph.obj.bitmap.width + 1 >= MaxWidth[0])
                {
                    yoffset += newRowHeight;
                    newRowHeight = 0;
                    xoffset = 0;
                }

                if (bmpGlyph.obj.bitmap.buffer != IntPtr.Zero)
                {
                    GL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, xoffset, yoffset, bmpGlyph.obj.bitmap.width, bmpGlyph.obj.bitmap.rows, TexSubImage2DFormats.Alpha, TexSubImage2DType.UnsignedByte, bmpGlyph.obj.bitmap.buffer);

                    int size = (bmpGlyph.obj.bitmap.width * bmpGlyph.obj.bitmap.rows);
                    byte[] bmp = new byte[size];
                    UnmanagedArray<byte> bmpBytes = new UnmanagedArray<byte>(size);
                    Marshal.Copy(bmpGlyph.obj.bitmap.buffer, bmp, 0, bmp.Length);
                    Marshal.Copy(bmp, 0, bmpBytes.Header, bmpBytes.Count);

                    // Next we expand the bitmap into an opengl texture
                    // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
                    int width = next_po2(bmpGlyph.obj.bitmap.width);
                    int height = next_po2(bmpGlyph.obj.bitmap.rows);
                    UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * width * height);
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            expanded[2 * (col + row * width)] = expanded[2 * (col + row * width) + 1] =
                                (col >= bmpGlyph.obj.bitmap.width || row >= bmpGlyph.obj.bitmap.rows) ?
                                (byte)0 : bmp[col + bmpGlyph.obj.bitmap.width * row];
                        }
                    }
                    //{
                    //    //  Create the bitmap.
                    //    {
                    //        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                    //            width / 2,
                    //            bmpGlyph.obj.bitmap.rows,
                    //            width * 4 / 2,
                    //            System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                    //            expanded.Header);
                    //        bitmap.Save(string.Format("Atlas{0}.bmp", i));
                    //    }
                    //    {
                    //        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                    //            bmpGlyph.obj.bitmap.width,
                    //            bmpGlyph.obj.bitmap.rows,
                    //            bmpGlyph.obj.bitmap.width * 4,
                    //            System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                    //            bmpBytes.Header);//bmpGlyph.obj.bitmap.buffer);
                    //        bitmap.Save(string.Format("bmpGlyph{0}.bmp", i));
                    //    }
                    //}
                }
                characterInfos[i].advanceX = bmpGlyph.glyphRec.advance.x >> 6;
                characterInfos[i].advanceY = bmpGlyph.glyphRec.advance.y >> 6;

                characterInfos[i].bitmapWidth = bmpGlyph.obj.bitmap.width;
                characterInfos[i].bitmapHeight = bmpGlyph.obj.bitmap.rows;

                characterInfos[i].bitmapLeft = bmpGlyph.obj.left;
                characterInfos[i].bitmapTop = bmpGlyph.obj.top;

                characterInfos[i].xoffset = xoffset / (float)widthOfTexture;
                characterInfos[i].yoffset = yoffset / (float)heightOfTexture;

                newRowHeight = Math.Max(newRowHeight, bmpGlyph.obj.bitmap.rows);
                xoffset += bmpGlyph.obj.bitmap.width + 1;
            }

            // 把整个纹理输出为图片
            {
                UnmanagedArray<byte> image = new UnmanagedArray<byte>(widthOfTexture * heightOfTexture);

                GL.GetTexImage(GetTexImageTargets.Texture2D, 0, GetTexImageFormats.Alpha, GetTexImageTypes.UnsignedByte, image);

                //  Create the bitmap.
                foreach (var pixelFormat in Enum.GetValues(typeof(System.Drawing.Imaging.PixelFormat)))
                {
                    try
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                            widthOfTexture,
                            heightOfTexture,
                            widthOfTexture * 4,
                            (System.Drawing.Imaging.PixelFormat)pixelFormat,
                            image.Header);

                        bitmap.Save(string.Format("wholeTexture-{0}.bmp", pixelFormat));
                        bitmap.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        private void CreateTextureObject(Shaders.ShaderProgram shaderProgram)
        {
            //GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, tex);
            GL.BindTexture(GL.GL_TEXTURE_2D, tex[0]);
            shaderProgram.SetUniform1("tex", tex[0]);

            GL.TexImage2D(TexImage2DTargets.Texture2D, 0, TexImage2DFormats.Alpha, widthOfTexture, heightOfTexture, 0, TexImage2DFormats.Alpha, TexImage2DTypes.UnsignedByte, IntPtr.Zero);

            /* We require 1 byte alignment when uploading texture data */
            GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
        }

        private void FindTextureSize(FreeTypeFace face, int fontHeight)
        {
            this.widthOfTexture = 0;
            this.heightOfTexture = 0;

            int newRowWidth = 0;
            int newRowHeight = 0;

            for (int i = 32; i < 128; i++)
            {
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i), fontHeight);

                if (newRowWidth + bmpGlyph.obj.bitmap.width + 1 >= MaxWidth[0])
                {
                    widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
                    heightOfTexture += newRowHeight;
                    newRowWidth = 0;
                    newRowHeight = 0;
                }
                newRowWidth += bmpGlyph.obj.bitmap.width + 1;
                newRowHeight = Math.Max(newRowHeight, bmpGlyph.obj.bitmap.rows);
            }

            widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
            heightOfTexture += newRowHeight;
        }

        internal int next_po2(int a)
        {
            int rval = 1;
            while (rval < a) rval <<= 1;
            return rval;
        }

        ~Atlas()
        {
            //glDeleteTextures(1, &tex);
            //GL.DeleteTextures(1, tex);
        }
    };
}
