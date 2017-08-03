﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpGL.Demos
{
    internal class DemoRendererFactory
    {
        public static RendererBase Create(Type rendererType)
        {
            RendererBase renderer = null;
            if (rendererType == typeof(AnalyzedPointSpriteRenderer))
            {
                int particleCount = 10000;
                renderer = AnalyzedPointSpriteRenderer.Create(particleCount);
            }
            else if (rendererType == typeof(BufferBlockRenderer))
            {
                renderer = BufferBlockRenderer.Create();
            }
            else if (rendererType == typeof(ConditionalRenderer))
            {
                renderer = ConditionalRenderer.Create();
            }
            else if (rendererType == typeof(ImageProcessingRenderer))
            {
                renderer = new ImageProcessingRenderer();
            }
            else if (rendererType == typeof(KleinBottleRenderer))
            {
                renderer = KleinBottleRenderer.Create(new KleinBottleModel());
            }
            else if (rendererType == typeof(ParticleSimulatorRenderer))
            {
                renderer = new ParticleSimulatorRenderer();
            }
            else if (rendererType == typeof(PointCloudRenderer))
            {
                var list = new List<vec3>();

                using (var reader = new StreamReader(@"Resources\data\19PointCloud.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        list.Add(new vec3(x, y, z));
                    }
                }
                renderer = PointCloudRenderer.Create(new PointCloudModel(list));
            }
            else if (rendererType == typeof(PointSpriteRenderer))
            {
                const int particleCount = 10000;
                renderer = PointSpriteRenderer.Create(particleCount);
            }
            else if (rendererType == typeof(RaycastVolumeRenderer))
            {
                renderer = new RaycastVolumeRenderer();
            }
            else if (rendererType == typeof(ShaderToyRenderer))
            {
                renderer = ShaderToyRenderer.Create();
            }
            else if (rendererType == typeof(SimpleComputeRenderer))
            {
                renderer = SimpleComputeRenderer.Create();
            }
            else if (rendererType == typeof(SimplexNoiseRenderer))
            {
                renderer = SimplexNoiseRenderer.Create();
            }
            else if (rendererType == typeof(TrefoilKnotRenderer))
            {
                renderer = TrefoilKnotRenderer.Create(new TrefoilKnotModel());
            }
            else if (rendererType == typeof(UniformArrayRenderer))
            {
                renderer = UniformArrayRenderer.Create();
            }
            else if (rendererType == typeof(UniformBlockRenderer))
            {
                renderer = UniformBlockRenderer.Create();
            }
            else if (rendererType == typeof(UniformStructRenderer))
            {
                renderer = UniformStructRenderer.Create();
            }
            else if (rendererType == typeof(WaterRenderer))
            {
                renderer = WaterRenderer.Create(waterPlaneLength: 4);
            }
            else if (rendererType == typeof(ZeroAttributeRenderer))
            {
                renderer = ZeroAttributeRenderer.Create();
            }

            return renderer;
        }
    }
}