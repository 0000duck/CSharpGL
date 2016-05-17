﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class BillboardRenderer : Renderer
    {

        private Color clearColor = Color.Black;
        public Color ClearColor
        {
            get { return clearColor; }
            set
            {
                if (value != clearColor)
                {
                    clearColor = value;
                    GL.ClearColor(value.R / 255.0f,value.G / 255.0f,value.B / 255.0f,value.A / 255.0f);
                }
            }
        }

        private uint[] sprite_texture = new uint[1];
        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static BillboardRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"Form07Billboard\Billboard.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"Form07Billboard\Billboard.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
        }
        public BillboardRenderer(int particleCount)
            : base(new BillboardModel(particleCount), staticShaderCodes, map, BillboardModel.strPosition)
        { }

        protected override void DoInitialize()
        {
            {
                // This is the texture that the compute program will write into
                GL.GenTextures(1, sprite_texture);
                GL.BindTexture(GL.GL_TEXTURE_2D, sprite_texture[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 256, 256);
                GL.BindTexture(GL.GL_TEXTURE_2D, 0);
                sampler2D texture = new sampler2D();
                var bitmap = new System.Drawing.Bitmap(@"Form07Billboard\star.png");
                texture.Initialize(bitmap);
                this.sprite_texture[0] = texture.Id;
                bitmap.Dispose();
            }
            base.DoInitialize();
            this.SetUniformValue("sprite_texture", new samplerValue(this.sprite_texture[0], GL.GL_TEXTURE0));
            this.SetUniformValue("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.SetUniformValue("mvp", projection * view * model);

            GL.Enable(GL.GL_POINT_SMOOTH);
            GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Enable(GL.GL_POINT_SPRITE_ARB);
            //GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);//TODO: test TexEnvi()
            GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
            //GL.Enable(GL.GL_POINT_SMOOTH);
            //GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
            GL.Enable(GL.GL_BLEND);
            GL.GetDelegateFor<GL.glBlendEquation>()(GL.GL_FUNC_ADD_EXT);
            GL.GetDelegateFor<GL.glBlendFuncSeparate>()(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

            base.DoRender(arg);

            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_POINT_SMOOTH);
        }

        protected override void DisposeUnmanagedResources()
        {
            GL.DeleteTextures(1, sprite_texture);
        }

        class BillboardModel : IBufferable
        {

            public BillboardModel(int particleCount)
            {
                this.particleCount = particleCount;
            }
            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            private int particleCount;
            private Random random = new Random();
            private float factor = 1;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(
                            varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(particleCount);
                            unsafe
                            {
                                var array = (vec3*)buffer.FirstElement();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    array[i] = new vec3(
                                        (float)(random.NextDouble() * 2 - 1) * factor,
                                        (float)(random.NextDouble() * 2 - 1) * factor,
                                        (float)(random.NextDouble() * 2 - 1) * factor);
                                }
                            }

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(
                      DrawMode.Points, 0, particleCount))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }

        internal void UpdateTexture(string filename)
        {
            // This is the texture that the compute program will write into
            GL.GenTextures(1, sprite_texture);
            GL.BindTexture(GL.GL_TEXTURE_2D, sprite_texture[0]);
            GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 256, 256);
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);
            sampler2D texture = new sampler2D();
            var bitmap = new System.Drawing.Bitmap(filename);
            texture.Initialize(bitmap);
            var old = new uint[1];
            old[0] = this.sprite_texture[0];
            this.sprite_texture[0] = texture.Id;
            this.SetUniformValue("sprite_texture", new samplerValue(this.sprite_texture[0], GL.GL_TEXTURE0));

            GL.DeleteTextures(1, old);
            bitmap.Dispose();
        }
    }
}