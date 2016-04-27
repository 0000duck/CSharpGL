﻿using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableModernRenderer : IColorCodedPicking
    {
        // Color Coded Picking
        protected VertexArrayObject vertexArrayObject4Picking;

        protected UniformMat4 pickingMVP = new UniformMat4("MVP");

        protected ShaderProgram pickingShaderProgram;
        protected ShaderProgram PickingShaderProgram
        {
            get
            {
                if (pickingShaderProgram == null)
                { pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram(); }

                return pickingShaderProgram;
            }
        }

        public mat4 MVP
        {
            get { return pickingMVP.Value; }
            set { pickingMVP.Value = value; }
        }

        public uint PickingBaseID { get; private set; }

        public void SetPickingBaseID(uint value)
        {
            this.PickingBaseID = value;
        }

        public uint GetVertexCount()
        {
            PropertyBufferPtr positionBufferPtr = this.positionBufferPtr;
            if (positionBufferPtr == null) { return 0; }
            int byteLength = positionBufferPtr.ByteLength;
            int vertexLength = positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength;
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        public abstract PickedGeometry Pick(RenderEventArgs e, uint stageVertexId,
            int x, int y, int canvasWidth, int canvasHeight);

    }
}
