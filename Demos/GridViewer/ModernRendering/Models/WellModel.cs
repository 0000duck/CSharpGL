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
        private VertexAttributeBufferPtr positionBufferPtr = null;
        public const string strBrightness = "brightness";
        private VertexAttributeBufferPtr brightnessBufferPtr = null;

        private IndexBufferPtr indexBufferPtr = null;

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

        public unsafe VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr != null) { return positionBufferPtr; }

                using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                {
                    int vertexCount = (faceCount * 2 + 2) * (pipeline.Count - 1);
                    buffer.Create(vertexCount);
                    var array = (vec3*)buffer.Header.ToPointer();
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
                    this.Lengths = max - min;

                    positionBufferPtr = buffer.GetBufferPtr();
                }

                return positionBufferPtr;
            }
            else if (bufferName == strBrightness)
            {
                if (brightnessBufferPtr != null) { return brightnessBufferPtr; }

                using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                {
                    int vertexCount = (faceCount * 2 + 2) * (pipeline.Count - 1);
                    buffer.Create(vertexCount);
                    var array = (vec3*)buffer.Header.ToPointer();
                    var random = new Random();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        var x = (float)(random.NextDouble() * 0.5 + 0.5);
                        array[i] = new vec3(x, x, x);
                    }

                    brightnessBufferPtr = buffer.GetBufferPtr();
                }

                return brightnessBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public unsafe IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr != null) { return this.indexBufferPtr; }

            int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.QuadStrip, BufferUsage.StaticDraw))
            {
                buffer.Create(vertexCount + (this.pipeline.Count - 1));
                var array = (uint*)buffer.Header.ToPointer();
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

                this.indexBufferPtr = buffer.GetBufferPtr();
            }

            return this.indexBufferPtr;
        }
        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        public vec3 FirstNode { get; private set; }

        public vec3 Lengths { get; set; }

        public vec3 WorldPosition { get; set; }

        public float RotationAngle { get; set; }

        public vec3 RotationAxis { get; set; }

        public vec3 Scale { get; set; }
    }
}