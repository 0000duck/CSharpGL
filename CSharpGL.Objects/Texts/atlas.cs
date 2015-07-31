﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    /**
     * The atlas struct holds a texture that contains the visible US-ASCII characters
     * of a certain font rendered with a certain character height.
     * It also contains an array that contains all the information necessary to
     * generate the appropriate vertex and texture coordinates for each character.
     *
     * After the constructor is run, you don't need to use any FreeType functions anymore.
     */


    struct CharacterInformation
    {
        public float ax;	// advance.x
        public float ay;	// advance.y

        public float bw;	// bitmap.width;
        public float bh;	// bitmap.height;

        public float bl;	// bitmap_left;
        public float bt;	// bitmap_top;

        public float tx;	// x offset of glyph in texture coordinates
        public float ty;	// y offset of glyph in texture coordinates
    } //c[128];		// character information

    /// <summary>
    /// 字形集
    /// </summary>
    class atlas
    {
        public uint[] tex = new uint[1];		// texture object

        public int widthOfTexture;			// width of texture in pixels
        public int heightOfTexture;			// height of texture in pixels

        public CharacterInformation[] characterInfos = new CharacterInformation[128];
        const int MaxWidth = 1024;

        public atlas(FreeTypeFace face, int height, Shaders.ShaderProgram shaderProgram)
        {
            // Freetype measures the font size in 1/64th of pixels for accuracy 
            // so we need to request characters in size*64
            // 设置字符大小？
            FreeTypeAPI.FT_Set_Char_Size(face.pointer, height << 6, height << 6, 96, 96);

            // Provide a reasonably accurate estimate for expected pixel sizes
            // when we later on create the bitmaps for the font
            // 设置像素大小？
            FreeTypeAPI.FT_Set_Pixel_Sizes(face.pointer, 0, height);

            int roww = 0;
            int rowh = 0;
            widthOfTexture = 0;
            heightOfTexture = 0;

            /* Find minimum size for a texture holding all visible ASCII characters */
            for (int i = 32; i < 128; i++)
            {
                // We first convert the number index to a character index
                // 根据字符获取其编号
                int index = FreeTypeAPI.FT_Get_Char_Index(face.pointer, Convert.ToChar(i));

                // Here we load the actual glyph for the character
                // 加载此字符的字形
                {
                    int ret = FreeTypeAPI.FT_Load_Glyph(face.pointer, index, FT_LOAD_TYPES.FT_LOAD_DEFAULT);// todo; try to set to FT_LOAD_RENDER
                    if (ret != 0) { throw new Exception(string.Format("Could not load character '{0}'", Convert.ToChar(i))); }
                }

                //if (FreeTypeAPI.FT_Load_Glyph(pface, i, FT_LOAD_TYPES.FT_LOAD_RENDER) != 0)
                //{ throw new Exception(string.Format("Loading character {0} failed!\n", Convert.ToChar(i))); }
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i));
                //System.IntPtr pGlyph;
                //{
                //    int ret = FreeTypeAPI.FT_Get_Glyph(face.obj.glyphrec, out pGlyph);
                //    if (ret != 0) { throw new Exception(); }
                //}
                //GlyphRec glyphRec = (GlyphRec)Marshal.PtrToStructure(face.obj.glyphrec, typeof(GlyphRec));

                //FreeTypeAPI.FT_Glyph_To_Bitmap(out pGlyph, FT_RENDER_MODES.FT_RENDER_MODE_NORMAL, 0, 1);
                //BitmapGlyph glyph_bmp = (BitmapGlyph)Marshal.PtrToStructure(pGlyph, typeof(BitmapGlyph));

                if (roww + bmpGlyph.obj.bitmap.width + 1 >= MaxWidth)
                {
                    widthOfTexture = Math.Max(widthOfTexture, roww);
                    heightOfTexture += rowh;
                    roww = 0;
                    rowh = 0;
                }
                roww += bmpGlyph.obj.bitmap.width + 1;
                rowh = Math.Max(rowh, bmpGlyph.obj.bitmap.rows);
            }

            widthOfTexture = Math.Max(widthOfTexture, roww);
            heightOfTexture += rowh;

            /* Create a texture that will be used to hold all ASCII glyphs */
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, tex);
            GL.BindTexture(GL.GL_TEXTURE_2D, tex[0]);
            //int uniform_tex = shaderProgram.GetUniformLocation("tex");
            shaderProgram.SetUniform1("tex", 0);
            //GL.Uniform1(uniform_tex, 0);

            //glTexImage2D(GL_TEXTURE_2D, 0, GL_ALPHA, w, h, 0, GL_ALPHA, GL_UNSIGNED_BYTE, 0);
            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_ALPHA, widthOfTexture, heightOfTexture, 0, GL.GL_ALPHA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);

            /* We require 1 byte alignment when uploading texture data */
            //glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

            /* Paste all glyph bitmaps into the texture, remembering the offset */
            int ox = 0;
            int oy = 0;

            rowh = 0;

            for (int i = 32; i < 128; i++)
            {
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i));

                if (ox + bmpGlyph.obj.bitmap.width + 1 >= MaxWidth)
                {
                    oy += rowh;
                    rowh = 0;
                    ox = 0;
                }

                GL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, ox, oy, bmpGlyph.obj.bitmap.width, bmpGlyph.obj.bitmap.rows, TexSubImage2DFormat.Alpha, TexSubImage2DType.UnsignedByte, bmpGlyph.obj.bitmap.buffer);

                characterInfos[i].ax = bmpGlyph.glyphRec.advance.x >> 6;
                characterInfos[i].ay = bmpGlyph.glyphRec.advance.y >> 6;

                characterInfos[i].bw = bmpGlyph.obj.bitmap.width;
                characterInfos[i].bh = bmpGlyph.obj.bitmap.rows;

                characterInfos[i].bl = bmpGlyph.obj.left;
                characterInfos[i].bt = bmpGlyph.obj.top;

                characterInfos[i].tx = ox / (float)widthOfTexture;
                characterInfos[i].ty = oy / (float)heightOfTexture;

                rowh = Math.Max(rowh, bmpGlyph.obj.bitmap.rows);
                ox += bmpGlyph.obj.bitmap.width + 1;
            }
        }

        ~atlas()
        {
            //glDeleteTextures(1, &tex);
            //GL.DeleteTextures(1, tex);
        }
    };
}
