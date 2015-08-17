﻿using CSharpGL.Maths;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 用shader+VAO+组装的texture显示字符串
    /// </summary>
    public class PointSpriteFontElement : SceneElementBase
    {
        private static readonly int maxPointSize;
        static PointSpriteFontElement()
        {
            int[] sizeRange = new int[2];
            GL.GetInteger(GetTarget.PointSizeRange, sizeRange);
            maxPointSize = sizeRange[1];
        }

        // source data
        private string content;
        private vec3 position;

        // result data
        public uint[] texture = new uint[1];
        uint[] vao = new uint[1];
        public ShaderProgram shaderProgram;
        private PrimitiveModes primitiveMode;
        public const string strprojectionMatrix = "projectionMatrix";
        public const string strviewMatrix = "viewMatrix";
        public const string strmodelMatrix = "modelMatrix";
        private uint attributeIndexPosition;
        private int fontSize;
        private int textureWidth;

        /// <summary>
        /// 用shader+VAO+组装的texture显示字符串
        /// </summary>
        /// <param name="content">要显示的字符串</param>
        /// <param name="position">字符串的中心位置</param>
        public PointSpriteFontElement(string content, vec3 position, int fontSize = 32)
        {
            if (fontSize >= maxPointSize) { throw new ArgumentException(); }

            this.content = content;
            this.position = position;
            this.fontSize = fontSize;
        }

        protected override void DoInitialize()
        {
            InitTexture(this.content);

            InitShaderProgram();

            InitVAO();
        }

        //private void InitTexture(string content)
        //{
        //    Bitmap newImage = new Bitmap("PointSpriteFontElement-Texture.png");
        //    // step 6: generate texture
        //    //  Lock the image bits (so that we can pass them to OGL).
        //    BitmapData bitmapData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height),
        //        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        //    //GL.ActiveTexture(GL.GL_TEXTURE0);
        //    GL.GenTextures(1, texture);
        //    GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);
        //    GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
        //        newImage.Width, newImage.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
        //        bitmapData.Scan0);
        //    //  Unlock the image.
        //    newImage.UnlockBits(bitmapData);
        //    /* We require 1 byte alignment when uploading texture data */
        //    //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
        //    /* Clamping to edges is important to prevent artifacts when scaling */
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);
        //    /* Linear filtering usually looks best for text */
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
        //    GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
        //    newImage.Dispose();
        //}

        private void InitTexture(string content)
        {
            // step 1: get totalWidth
            int glyphsLength = 0;
            {
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (FontResource.Instance.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        int glyphWidth = cInfo.width;
                        glyphsLength += glyphWidth;
                    }
                    //else
                    //{ throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                }

                //glyphsLength = (glyphsLength * this.fontSize / FontResource.Instance.FontHeight);
            }

            // step 2: setup contentBitmap
            Bitmap contentBitmap = null;
            {
                int interval = FontResource.Instance.FontHeight / 5; if (interval < 1) { interval = 1; }
                int totalLength = glyphsLength + interval * (content.Length - 1);
                int currentTextureWidth = 0;
                int currentWidthPosition = 0;
                int currentHeightPosition = 0;
                if (totalLength * this.fontSize / FontResource.Instance.FontHeight> maxPointSize)// 超过1行能显示的内容
                {
                    currentTextureWidth = maxPointSize * FontResource.Instance.FontHeight / this.fontSize;

                    int lineCount = (glyphsLength - 1) / currentTextureWidth + 1;
                    // 确保整篇文字的高度在贴图中间。
                    currentHeightPosition = (glyphsLength - FontResource.Instance.FontHeight * lineCount) / 2;
                }
                else//只在一行内即可显示所有字符
                {
                    if (totalLength >= FontResource.Instance.FontHeight)
                    {
                        currentHeightPosition = (glyphsLength - FontResource.Instance.FontHeight) / 2;
                    }
                    else
                    {
                        // 确保整篇文字的高度在贴图中间。
                        currentWidthPosition = (FontResource.Instance.FontHeight - glyphsLength) / 2;
                        glyphsLength = FontResource.Instance.FontHeight;
                    }

                    currentTextureWidth = totalLength;
                }

                //this.textureWidth = textureWidth * this.fontSize / FontResource.Instance.FontHeight;
                //currentWidthPosition = currentWidthPosition * this.fontSize / FontResource.Instance.FontHeight;
                //currentHeightPosition = currentHeightPosition * this.fontSize / FontResource.Instance.FontHeight;

                contentBitmap = new Bitmap(currentTextureWidth, currentTextureWidth);
                Graphics gContentBitmap = Graphics.FromImage(contentBitmap);
                Bitmap bigBitmap = FontResource.Instance.FontBitmap;
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (FontResource.Instance.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        //for (int col = 0; col < cInfo.width; col++)
                        //{
                        //    for (int row = 0; row < FontResource.Instance.FontHeight; row++)
                        //    {
                        //        var color = bigBitmap.GetPixel(cInfo.xoffset + col, cInfo.yoffset + row);
                        //        contentBitmap.SetPixel(currentWidthPosition + col, currentHeightPosition + row, color);
                        //    }
                        //}

                        gContentBitmap.DrawImage(bigBitmap,
                            new Rectangle(currentWidthPosition, currentHeightPosition, cInfo.width, FontResource.Instance.FontHeight),
                            new Rectangle(cInfo.xoffset, cInfo.yoffset, cInfo.width, FontResource.Instance.FontHeight),
                            GraphicsUnit.Pixel);

                        currentWidthPosition += cInfo.width + interval;
                        if (currentWidthPosition >= contentBitmap.Width)
                        {
                            currentWidthPosition = 0;
                            currentHeightPosition += FontResource.Instance.FontHeight;
                        }
                    }
                }
                gContentBitmap.Dispose();
            }

            // step 4: get texture's size 
            int targetTextureWidth;
            {

                //	Get the maximum texture size supported by OpenGL.
                int[] textureMaxSize = { 0 };
                GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

                //	Find the target width and height sizes, which is just the highest
                //	posible power of two that'll fit into the image.

                targetTextureWidth = textureMaxSize[0];
                //System.Drawing.Bitmap bitmap = contentBitmap;
                int scaledWidth = 8 * contentBitmap.Width * this.fontSize / FontResource.Instance.FontHeight;

                for (int size = 1; size <= textureMaxSize[0]; size *= 2)
                {
                    if (scaledWidth < size)
                    {
                        targetTextureWidth = size / 2;
                        break;
                    }
                    if (scaledWidth == size)
                        targetTextureWidth = size;
                }

                this.textureWidth = targetTextureWidth;
            }

            // step 5: scale contentBitmap to right size
            System.Drawing.Bitmap targetImage = contentBitmap;
            if (contentBitmap.Width != targetTextureWidth || contentBitmap.Height != targetTextureWidth)
            {
                //  Resize the image.
                targetImage = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(targetTextureWidth, targetTextureWidth, null, IntPtr.Zero);
            }

            // step 6: generate texture
            {
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = targetImage.LockBits(new Rectangle(0, 0, targetImage.Width, targetImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                //GL.ActiveTexture(GL.GL_TEXTURE0);
                GL.GenTextures(1, texture);
                GL.BindTexture(GL.GL_TEXTURE_2D, texture[0]);
                GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                    targetImage.Width, targetImage.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                    bitmapData.Scan0);
                //  Unlock the image.
                targetImage.UnlockBits(bitmapData);
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                /* Clamping to edges is important to prevent artifacts when scaling */
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);
                /* Linear filtering usually looks best for text */
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            }

            // step 7: release images
            {
                targetImage.Save("PointSpriteFontElement-TargetImage.png");
                if (targetImage != contentBitmap)
                {
                    targetImage.Dispose();
                }

                contentBitmap.Dispose();
            }
        }

        private void InitVAO()
        {
            primitiveMode = PrimitiveModes.Points;

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                UnmanagedArray<vec3> in_Position = new UnmanagedArray<vec3>(1);
                in_Position[0] = this.position;

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, in_Position, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(attributeIndexPosition, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(attributeIndexPosition);
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        private void InitShaderProgram()
        {
            //  Create the shader program.
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointSpriteFontElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointSpriteFontElement.frag");
            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
            this.attributeIndexPosition = shaderProgram.GetAttributeLocation("in_Position");
            shaderProgram.AssertValid();
            this.shaderProgram = shaderProgram;
        }

        protected override void DoRender(RenderModes renderMode)
        {
            // 用VAO+EBO进行渲染。
            //  Bind the out vertex array.
            GL.BindVertexArray(vao[0]);
            //int size = this.fontSize * this.textureWidth;
            int size = this.textureWidth / 8;
            //if (size > maxTextureWidth) { size = maxTextureWidth; }
            GL.PointSize(size);

            GL.DrawArrays((uint)this.primitiveMode, 0, 1);

            //  Unbind our vertex array and shader.
            GL.BindVertexArray(0);

            GL.PointSize(1);
        }
    }

}
