﻿using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal class InnerImageProcessingRenderer : PickableRenderer
    {
        private string textureFilename;
        private Texture inputTexture;

        public Texture InputTexture
        {
            get { return inputTexture; }
        }
        private Texture intermediateTexture;

        public Texture IntermediateTexture
        {
            get { return intermediateTexture; }
        }
        private Texture outputTexture;

        public Texture OutputTexture
        {
            get { return outputTexture; }
        }

        public static InnerImageProcessingRenderer Create(string textureFilename = @"Textures\edgeDetection.bmp")
        {
            var model = new ImageProcessingModel();
            ShaderCode[] simpleShader = new ShaderCode[2];
            simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessingRenderer\ImageProcessing.vert"), ShaderType.VertexShader);
            simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessingRenderer\ImageProcessing.frag"), ShaderType.FragmentShader);
            var propertyNameMap = new AttributeMap();
            propertyNameMap.Add("vert", "position");
            propertyNameMap.Add("uv", "uv");
            var renderer = new InnerImageProcessingRenderer(
                model, simpleShader, propertyNameMap, ImageProcessingModel.strposition);
            renderer.textureFilename = textureFilename;

            return renderer;
        }

        private InnerImageProcessingRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                Bitmap bitmap = new System.Drawing.Bitmap(this.textureFilename);
                if (bitmap.Width != 512 || bitmap.Height != 512)
                {
                    bitmap = (Bitmap)bitmap.GetThumbnailImage(512, 512, null, IntPtr.Zero);
                }
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                /* Clamping to edges is important to prevent artifacts when scaling */
                /* Linear filtering usually looks best for text */
                var texture = new Texture(TextureTarget.Texture2D,
                    new BitmapFiller(bitmap, 0, OpenGL.GL_RGBA32F, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE),
                    new SamplerParameters(
                        TextureWrapping.ClampToEdge,
                        TextureWrapping.ClampToEdge,
                        TextureWrapping.ClampToEdge,
                        TextureFilter.Linear,
                        TextureFilter.Linear));
                texture.Initialize();
                bitmap.Dispose();
                this.inputTexture = texture;
            }
            {
                var texture = new Texture(TextureTarget.Texture2D,
                    new TexStorage2DImageFiller(8, OpenGL.GL_RGBA32F, 512, 512),
                    new NullSampler());
                texture.Initialize();
                this.intermediateTexture = texture;
            }
            {
                // This is the texture that the compute program will write into
                var texture = new Texture(TextureTarget.Texture2D,
           new TexStorage2DImageFiller(8, OpenGL.GL_RGBA32F, 512, 512),
           new NullSampler());
                texture.Initialize();
                this.outputTexture = texture;
            }

            this.SetUniform("output_image", this.outputTexture);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            inputTexture.Dispose();
            intermediateTexture.Dispose();
            outputTexture.Dispose();
        }

        private class ImageProcessingModel : IBufferable
        {
            public const string strposition = "position";
            public const string struv = "uv";
            private VertexBuffer positionBuffer;
            private VertexBuffer uvBuffer;
            private IndexBuffer indexBuffer;

            public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBuffer == null)
                    {
                        int length = 4;
                        VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                        unsafe
                        {
                            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                            var array = (vec3*)pointer;
                            array[0] = new vec3(-1.0f, -1.0f, 0.5f);
                            array[1] = new vec3(1.0f, -1.0f, 0.5f);
                            array[2] = new vec3(1.0f, 1.0f, 0.5f);
                            array[3] = new vec3(-1.0f, 1.0f, 0.5f);
                            buffer.UnmapBuffer();
                        }

                        this.positionBuffer = buffer;
                    }
                    return positionBuffer;
                }
                else if (bufferName == struv)
                {
                    if (this.uvBuffer == null)
                    {
                        int length = 4;
                        VertexBuffer buffer = VertexBuffer.Create(typeof(vec2), length, VBOConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                        unsafe
                        {
                            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                            var array = (vec2*)pointer;
                            array[0] = new vec2(1, 1);
                            array[1] = new vec2(0, 1);
                            array[2] = new vec2(0, 0);
                            array[3] = new vec2(1, 0);
                            buffer.UnmapBuffer();
                        }
                        this.uvBuffer = buffer;
                    }
                    return this.uvBuffer;
                }
                else
                { throw new NotImplementedException(); }
            }

            public IndexBuffer GetIndexBuffer()
            {
                if (this.indexBuffer == null)
                {
                    ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.TriangleFan, 0, 4);
                    this.indexBuffer = buffer;
                }
                return indexBuffer;
            }

            /// <summary>
            /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }
        }

        internal void SwitchDisplayImage(bool forward)
        {
            if (forward)
            {
                switch (this.currentDisplay)
                {
                    case CurrentDisplayImage.Input:
                        this.SetUniform("output_image",
                            this.intermediateTexture);
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;

                    case CurrentDisplayImage.Intermediate:
                        this.SetUniform("output_image",
                            this.outputTexture);
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;

                    case CurrentDisplayImage.Output:
                        this.SetUniform("output_image",
                            this.inputTexture);
                        this.currentDisplay = CurrentDisplayImage.Input;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                switch (this.currentDisplay)
                {
                    case CurrentDisplayImage.Input:
                        this.SetUniform("output_image",
                            this.outputTexture);
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;

                    case CurrentDisplayImage.Intermediate:
                        this.SetUniform("output_image",
                            this.inputTexture);
                        this.currentDisplay = CurrentDisplayImage.Input;
                        break;

                    case CurrentDisplayImage.Output:
                        this.SetUniform("output_image",
                            this.intermediateTexture);
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private CurrentDisplayImage currentDisplay = CurrentDisplayImage.Output;

        private enum CurrentDisplayImage
        {
            Input,
            Intermediate,
            Output,
        }
    }
}