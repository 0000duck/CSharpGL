﻿using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal class ParticleSimulatorRenderer : RendererBase
    {
        private ParticleRenderer particleRenderer;
        private ParticleComputeRenderer particleComputeRenderer;

        public ParticleSimulatorRenderer()
        {
            this.Size = new vec3(5, 5, 5);
        }

        protected override void DoInitialize()
        {
            {
                IBufferable model = new ParticleModel();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ParticleSimulatorRenderer\particleSimulator.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ParticleSimulatorRenderer\particleSimulator.frag"), ShaderType.FragmentShader);
                var map = new AttributeMap();
                map.Add("position", ParticleModel.strPosition);
                var particleRenderer = new ParticleRenderer(model, shaderCodes, map, new DepthTestSwitch(false), new BlendSwitch(BlendingSourceFactor.One, BlendingDestinationFactor.One));
                particleRenderer.Initialize();
                this.particleRenderer = particleRenderer;
            }
            {
                var particleComputeRenderer = new ParticleComputeRenderer(
                    this.particleRenderer.PositionBufferPtr,
                    this.particleRenderer.VelocityBufferPtr);
                particleComputeRenderer.Initialize();
                this.particleComputeRenderer = particleComputeRenderer;
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.particleComputeRenderer.Render(arg);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            // Clear, select the rendering program and draw a full screen quad
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.particleRenderer.SetUniform("mvp", projection * view);
            this.particleRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.particleRenderer.Dispose();
            this.particleComputeRenderer.Dispose();
        }
    }
}