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
            renderer.Lengths = model.Lengths;

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
            mat4 model = this.GetModelMatrix();
            this.SetUniform("u_modelViewProjectionMatrix", projection * view * model);

            base.DoRender(arg);
        }

        private class GreyFilterModel : IBufferable
        {
            private static vec2[] positions = new vec2[] { new vec2(-1, -1), new vec2(1, -1), new vec2(-1, 1), new vec2(1, 1), };
            private static vec2[] texCoords = new vec2[] { new vec2(0, 0), new vec2(1, 0), new vec2(0, 1), new vec2(1, 1), };

            public const string strPosition = "position";
            private VertexAttributeBufferPtr positionBufferPtr = null;
            public const string strTexCoord = "texCoord";
            private VertexAttributeBufferPtr texCoordBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;

            public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec3>(
                            varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(positions.Length);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                for (int i = 0; i < positions.Length; i++)
                                {
                                    array[i] = new vec3(positions[i].x, positions[i].y, 0);
                                }
                            }

                            positionBufferPtr = buffer.GetBufferPtr();
                        }
                    }

                    return positionBufferPtr;
                }
                else if (bufferName == strTexCoord)
                {
                    if (texCoordBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec2>(
                            varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(texCoords.Length);
                            unsafe
                            {
                                var array = (vec2*)buffer.Header.ToPointer();
                                for (int i = 0; i < texCoords.Length; i++)
                                {
                                    array[i] = texCoords[i];
                                }
                            }

                            texCoordBufferPtr = buffer.GetBufferPtr();
                        }
                    }

                    return texCoordBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndexBufferPtr()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleStrip, 0, 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return indexBufferPtr;
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