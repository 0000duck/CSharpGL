﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridViewer
{
    /// <summary>
    /// WellPipeline
    /// 蛇形管道（井）
    /// </summary>
    public partial class WellModel : IBufferable, IModelSpace
    {
        public const string strPosition = "position";
        private VertexAttributeBuffer positionBuffer = null;
        public const string strBrightness = "brightness";
        private VertexAttributeBuffer brightnessBuffer = null;

        private IndexBuffer indexBuffer = null;

        private List<vec3> pipeline;
        private float radius;
        private int faceCount;

        /// <summary>
        /// WellPipeline
        /// 蛇形管道（井）
        /// </summary>
        /// <param name="originalWorldPosition"></param>
        /// <param name="pipeline"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="faceCount"></param>
        public WellModel(List<vec3> pipeline, float radius, int faceCount = 18)
        {
            if (pipeline == null || pipeline.Count < 2 || radius <= 0.0f)
            { throw new ArgumentException(); }

            this.radius = radius;
            this.faceCount = faceCount;
            this.SetupPipeline(pipeline.ToList());
        }

        private void SetupPipeline(List<vec3> pipeline)
        {
            BoundingBox box = pipeline.Move2Center();
            this.WorldPosition = 0.5f * box.MaxPosition + 0.5f * box.MinPosition;
            this.FirstNode = pipeline[0];
            this.pipeline = pipeline;
        }

        public unsafe VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer != null) { return positionBuffer; }

                int length = (faceCount * 2 + 2) * (pipeline.Count - 1);
                VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (vec3*)pointer.ToPointer();
                    int index = 0;
                    var max = new vec3(float.MinValue, float.MinValue, float.MinValue);
                    var min = new vec3(float.MaxValue, float.MaxValue, float.MaxValue);
                    for (int i = 1; i < pipeline.Count; i++)
                    {
                        vec3 p1 = pipeline[i - 1];
                        vec3 p2 = pipeline[i];
                        vec3 vector = p2 - p1;// 从p1到p2的向量
                        // 找到互相垂直的三个向量：vector, orthogontalVector1和orthogontalVector2
                        vec3 orthogontalVector1 = new vec3(vector.y - vector.z, vector.z - vector.x, vector.x - vector.y);
                        vec3 orthogontalVector2 = vector.cross(orthogontalVector1);
                        orthogontalVector1 = orthogontalVector1.normalize() * (float)Math.Sqrt(this.radius);
                        orthogontalVector2 = orthogontalVector2.normalize() * (float)Math.Sqrt(this.radius);
                        for (int faceIndex = 0; faceIndex < faceCount + 1; faceIndex++)
                        {
                            double angle = (Math.PI * 2 * faceIndex) / faceCount;
                            vec3 delta = orthogontalVector1 * (float)Math.Cos(angle) + orthogontalVector2 * (float)Math.Sin(angle);
                            vec3 tmp1 = p1 + delta, tmp2 = p2 + delta;
                            tmp1.UpdateMax(ref max); tmp1.UpdateMin(ref min);
                            tmp2.UpdateMax(ref max); tmp2.UpdateMin(ref min);
                            array[index++] = tmp1;
                            array[index++] = tmp2;
                        }
                    }
                    buffer.UnmapBuffer();
                    this.ModelSize = max - min;
                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strBrightness)
            {
                if (brightnessBuffer != null) { return brightnessBuffer; }

                int length = (faceCount * 2 + 2) * (pipeline.Count - 1);
                VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (vec3*)pointer.ToPointer();
                    var random = new Random();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        var x = (float)(random.NextDouble() * 0.5 + 0.5);
                        array[i] = new vec3(x, x, x);
                    }
                    buffer.UnmapBuffer();
                }
                this.brightnessBuffer = buffer;

                return this.brightnessBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public unsafe IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer != null) { return this.indexBuffer; }

            int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
            int length = vertexCount + (this.pipeline.Count - 1);
            OneIndexBuffer buffer = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.QuadStrip, IndexElementType.UInt, length);
            unsafe
            {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (uint*)pointer.ToPointer();
                uint positionIndex = 0;
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i % (faceCount * 2 + 2 + 1) == (faceCount * 2 + 2))
                    {
                        array[i] = uint.MaxValue;//分割各个圆柱体
                    }
                    else
                    {
                        array[i] = positionIndex++;
                    }
                }
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }
        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        public vec3 FirstNode { get; private set; }

        public vec3 ModelSize { get; set; }

        public vec3 WorldPosition { get; set; }

        public float RotationAngleDegree { get; set; }

        public vec3 RotationAxis { get; set; }

        public vec3 Scale { get; set; }
    }
}