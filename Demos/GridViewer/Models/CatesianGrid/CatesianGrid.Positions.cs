﻿using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace GridViewer
{
    public partial class CatesianGrid
    {
        public const string strPosition = "position";
        private PropertyBufferPtr propertyBufferPtr;

        private PropertyBufferPtr GetPositionBufferPtr(string varNameInShader)
        {
            PropertyBufferPtr ptr = null;
            using (var buffer = new PropertyBuffer<HexahedronPosition>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
            {
                int dimSize = this.DataSource.DimenSize;
                buffer.Create(dimSize);
                unsafe
                {
                    var array = (HexahedronPosition*)buffer.Header.ToPointer();
                    int I, J, K;
                    for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                    {
                        this.DataSource.InvertIJK(gridIndex, out I, out J, out K);
                        array[gridIndex].FLT = this.DataSource.TranslateMatrix + this.DataSource.PointFLT(I, J, K);
                        array[gridIndex].FRT = this.DataSource.TranslateMatrix + this.DataSource.PointFRT(I, J, K);
                        array[gridIndex].BRT = this.DataSource.TranslateMatrix + this.DataSource.PointBRT(I, J, K);
                        array[gridIndex].BLT = this.DataSource.TranslateMatrix + this.DataSource.PointBLT(I, J, K);
                        array[gridIndex].FLB = this.DataSource.TranslateMatrix + this.DataSource.PointFLB(I, J, K);
                        array[gridIndex].FRB = this.DataSource.TranslateMatrix + this.DataSource.PointFRB(I, J, K);
                        array[gridIndex].BRB = this.DataSource.TranslateMatrix + this.DataSource.PointBRB(I, J, K);
                        array[gridIndex].BLB = this.DataSource.TranslateMatrix + this.DataSource.PointBLB(I, J, K);
                    }
                }
                ptr = buffer.GetBufferPtr() as PropertyBufferPtr;
            }

            return ptr;
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
