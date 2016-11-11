﻿using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal class GreyFilterRenderer : Renderer
    {
        private Texture texture;

        public static GreyFilterRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\GreyFilterRenderer\GreyFilter.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\GreyFilterRenderer\GreyFilter.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("a_vertex", GreyFilterModel.strPosition);
            map.Add("a_texCoord", GreyFilterModel.strTexCoord);
            var model = new GreyFilterModel();
            var renderer = new GreyFilterRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private GreyFilterRenderer(
            IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
        }

        public void SetupTexture(Bitmap bitmap)
        {
            if (this.texture != null)
            {
                this.texture.Dispose();
            }

            var texture = new Texture(TextureTarget.Texture2D,
                bitmap, new SamplerParameters(
                    TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                    TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();
            this.SetUniform("u_texture", texture);
            this.texture = texture;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Red);
                g.DrawString("CSharpGL", new Font("宋体", 18F), new SolidBrush(Color.Gold), new PointF(0, 40));
            }
            this.SetupTexture(bitmap);
            bitmap.Dispose();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("u_modelViewProjectionMatrix", projection * view * model);

            base.DoRender(arg);
        }

        private class GreyFilterModel : IBufferable
        {
            private static vec2[] positions = new vec2[] { new vec2(-1, -1), new vec2(1, -1), new vec2(-1, 1), new vec2(1, 1), };
            private static vec2[] texCoords = new vec2[] { new vec2(0, 0), new vec2(1, 0), new vec2(0, 1), new vec2(1, 1), };

            public const string strPosition = "position";
            private VertexAttributeBuffer positionBufferPtr = null;
            public const string strTexCoord = "texCoord";
            private VertexAttributeBuffer texCoordBufferPtr = null;
            private IndexBuffer indexBufferPtr;

            public VertexAttributeBuffer GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (this.positionBufferPtr == null)
                    {
                        int length = positions.Length;
                        VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                        unsafe
                        {
                            IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                            var array = (vec3*)pointer;
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = new vec3(positions[i].x, positions[i].y, 0);
                            }
                            bufferPtr.UnmapBuffer();
                        }

                        this.positionBufferPtr = bufferPtr;
                    }

                    return this.positionBufferPtr;
                }
                else if (bufferName == strTexCoord)
                {
                    if (this.texCoordBufferPtr == null)
                    {
                        int length = texCoords.Length;
                        VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec2), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                        unsafe
                        {
                            IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                            var array = (vec2*)pointer;
                            for (int i = 0; i < texCoords.Length; i++)
                            {
                                array[i] = texCoords[i];
                            }
                            bufferPtr.UnmapBuffer();
                        }

                        this.texCoordBufferPtr = bufferPtr;
                    }

                    return this.texCoordBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBuffer GetIndexBufferPtr()
            {
                if (this.indexBufferPtr == null)
                {
                    ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.TriangleStrip, 0, 4);
                    this.indexBufferPtr = bufferPtr;
                }

                return this.indexBufferPtr;
            }

            /// <summary>
            /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }

            public vec3 Lengths { get { return new vec3(2.05f, 2.05f, 0.02f); } }
        }
    }
}