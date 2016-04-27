﻿using GLM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexModernRenderer : PickableModernRenderer
    {

        public override PickedGeometry Pick(RenderEventArgs e, uint stageVertexId,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            uint lastVertexId;
            PickedGeometry pickedGeometry = null;
            if (this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            {
                pickedGeometry = new PickedGeometry();
                switch (e.RenderMode)
                {
                    case RenderModes.Render:
                        pickedGeometry.GeometryType = this.indexBufferPtr.Mode.ToPrimitiveMode().ToGeometryType();
                        break;
                    case RenderModes.ColorCodedPicking:
                        pickedGeometry.GeometryType = this.indexBufferPtr.Mode.ToPrimitiveMode().ToGeometryType();
                        break;
                    case RenderModes.ColorCodedPickingPoints:
                        pickedGeometry.GeometryType = GeometryTypes.Point;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                pickedGeometry.StageVertexId = stageVertexId;
                pickedGeometry.From = this;
                // Fill primitive's position information.
                int vertexCount = pickedGeometry.GeometryType.GetVertexCount();
                if (vertexCount == -1) { vertexCount = this.positionBufferPtr.Length; }
                if (lastVertexId == 0 && vertexCount == 2)
                {
                    // This is when mode is GL_LINE_LOOP and picked last line(the loop back one)
                    PickingLastLineInLineLoop(pickedGeometry);
                }
                else
                {
                    // Other conditions
                    ContinuousBufferRange(lastVertexId, vertexCount, pickedGeometry);
                }
            }

            return pickedGeometry;
        }
        private void PickingLastLineInLineLoop(PickedGeometry pickedGeometry)
        {
            //const int lastVertexId = 0;
            const int vertexCount = 2;
            var offsets = new int[vertexCount] { (this.positionBufferPtr.Length - 1) * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength, 0, };
            pickedGeometry.Positions = new vec3[vertexCount];
            pickedGeometry.Indexes = new uint[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                    offsets[i],
                    1 * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                    MapBufferRangeAccess.MapReadBit);
                if (pointer.ToInt32() != 0)
                {
                    unsafe
                    {
                        var array = (vec3*)pointer.ToPointer();
                        pickedGeometry.Positions[i] = array[0];
                    }
                }
                else
                {
                    ErrorCode error = (ErrorCode)GL.GetError();
                    Debug.WriteLine("Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId);
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
                pickedGeometry.Indexes[i] = (uint)offsets[i] / (uint)(this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
            }
        }

        private void ContinuousBufferRange(uint lastVertexId, int vertexCount, PickedGeometry pickedGeometry)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            int offset = (int)((lastVertexId - (vertexCount - 1)) * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
            IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                offset,
                vertexCount * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                MapBufferRangeAccess.MapReadBit);
            pickedGeometry.Positions = new vec3[vertexCount];
            pickedGeometry.Indexes = new uint[vertexCount];
            if (pointer.ToInt32() != 0)
            {
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (uint i = 0; i < vertexCount; i++)
                    {
                        pickedGeometry.Positions[i] = array[i];
                        pickedGeometry.Indexes[i] = lastVertexId - ((uint)vertexCount - 1) + i;
                    }
                }
            }
            else
            {
                ErrorCode error = (ErrorCode)GL.GetError();
                Debug.WriteLine("Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId);
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
        }

    }
}
