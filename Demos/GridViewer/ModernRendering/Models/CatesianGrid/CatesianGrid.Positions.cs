﻿using CSharpGL;
using System;
using System.Runtime.InteropServices;

namespace GridViewer
{
    public partial class CatesianGrid
    {
        public const string strPosition = "position";
        private VertexAttributeBufferPtr propertyBufferPtr;

        private VertexAttributeBufferPtr GetPositionBufferPtr(string varNameInShader)
        {
            int dimSize = this.DataSource.DimenSize;
            int length = dimSize;
            VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(HexahedronPosition), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
            unsafe
            {
                IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (HexahedronPosition*)pointer;
                int I, J, K;
                for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                {
                    this.DataSource.InvertIJK(gridIndex, out I, out J, out K);
                    array[gridIndex].FLT = this.DataSource.Position + this.DataSource.PointFLT(I, J, K);
                    array[gridIndex].FRT = this.DataSource.Position + this.DataSource.PointFRT(I, J, K);
                    array[gridIndex].BRT = this.DataSource.Position + this.DataSource.PointBRT(I, J, K);
                    array[gridIndex].BLT = this.DataSource.Position + this.DataSource.PointBLT(I, J, K);
                    array[gridIndex].FLB = this.DataSource.Position + this.DataSource.PointFLB(I, J, K);
                    array[gridIndex].FRB = this.DataSource.Position + this.DataSource.PointFRB(I, J, K);
                    array[gridIndex].BRB = this.DataSource.Position + this.DataSource.PointBRB(I, J, K);
                    array[gridIndex].BLB = this.DataSource.Position + this.DataSource.PointBLB(I, J, K);
                }
                bufferPtr.UnmapBuffer();
            }

            return bufferPtr;
        }
    }

    /// <summary>
    /// map to opengl buffer
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HexahedronPosition
    {
        /// <summary>
        ///  front left top p0
        /// </summary>
        public vec3 FLT;

        /// <summary>
        /// front right top p1
        /// </summary>
        public vec3 FRT;

        /// <summary>
        /// back right top p2
        /// </summary>
        public vec3 BRT;

        /// <summary>
        /// back left top p4
        /// </summary>
        public vec3 BLT;

        /// <summary>
        ///
        /// </summary>
        public vec3 FLB;

        public vec3 FRB;
        public vec3 BRB;
        public vec3 BLB;
    }
}