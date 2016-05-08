﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class SimpleComputeRenderer : Renderer
    {
        private ShaderProgram computeProgram;
        private uint[] output_image = new uint[1];
        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static SimpleComputeRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"Shaders\compute.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"Shaders\compute.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add(SimpleCompute.strPosition, "position");
        }
        public SimpleComputeRenderer()
            : base(new SimpleCompute(), staticShaderCodes, map, SimpleCompute.strPosition)
        { }

        protected override void DoInitialize()
        {
            {
                // Initialize our compute program
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"Shaders\compute.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                // This is the texture that the compute program will write into
                GL.GenTextures(1, output_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 256, 256);
            }

            base.DoInitialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, output_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glDispatchCompute>()(8, 16, 1);
            //computeProgram.Unbind();

            // Now bind the texture for rendering _from_
            GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);

            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.SetUniformValue("modelMatrix", model);
            this.SetUniformValue("viewMatrix", view);
            this.SetUniformValue("projectionMatrix", projection);

            base.DoRender(arg);

            //GL.BindTexture(GL.GL_TEXTURE_2D, 0);
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            GL.DeleteTextures(1, output_image);
        }

    }

    class SimpleCompute : IBufferable
    {

        static readonly vec3[] vertsData = new vec3[]
        {
            new vec3(-1.0f, -1.0f, 0.5f),
            new vec3(1.0f, -1.0f, 0.5f),
            new vec3(1.0f,  1.0f, 0.5f),
            new vec3(-1.0f,  1.0f, 0.5f),
        };

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(vertsData.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < vertsData.Length; i++)
                            {
                                array[i] = vertsData[i];
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
                  DrawMode.TriangleFan, 0, vertsData.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }
    }
}
