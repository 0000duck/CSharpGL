﻿using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                int dimSize = this.dataSource.DimenSize;
                buffer.Alloc(dimSize);
                unsafe
                {
                    var array = (HexahedronPosition*)buffer.Header.ToPointer();
                    int I, J, K;
                    for (int gridIndex = 0; gridIndex < dimSize; gridIndex++)
                    {
                        this.dataSource.InvertIJK(gridIndex, out I, out J, out K);
                        array[gridIndex].FLT = this.dataSource.TranslateMatrix + this.dataSource.PointFLT(I, J, K);
                        array[gridIndex].FRT = this.dataSource.TranslateMatrix + this.dataSource.PointFRT(I, J, K);
                        array[gridIndex].BRT = this.dataSource.TranslateMatrix + this.dataSource.PointBRT(I, J, K);
                        array[gridIndex].BLT = this.dataSource.TranslateMatrix + this.dataSource.PointBLT(I, J, K);
                        array[gridIndex].FLB = this.dataSource.TranslateMatrix + this.dataSource.PointFLB(I, J, K);
                        array[gridIndex].FRB = this.dataSource.TranslateMatrix + this.dataSource.PointFRB(I, J, K);
                        array[gridIndex].BRB = this.dataSource.TranslateMatrix + this.dataSource.PointBRB(I, J, K);
                        array[gridIndex].BLB = this.dataSource.TranslateMatrix + this.dataSource.PointBLB(I, J, K);
                    }
                }
                ptr = buffer.GetBufferPtr() as PropertyBufferPtr;
            }

            return ptr;
        }

    }
}
