﻿using System;

namespace CSharpGL
{
    internal class OneIndexLineInPolygonSearcher : OneIndexLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="primitiveInfo"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexRenderer modernRenderer)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.LineLoop, IndexElementType.UInt, indexList.Length);
            unsafe
            {
                var array = (uint*)bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                for (int i = 0; i < indexList.Length; i++)
                {
                    array[i] = indexList[i];
                }
                bufferPtr.UnmapBuffer();
            }
            modernRenderer.Render4InnerPicking(arg, bufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            bufferPtr.Dispose();

            if (id == indexList[0])
            { return new uint[] { indexList[indexList.Length - 1], id, }; }
            else
            {
                uint[] result = null;
                for (int i = 1; i < indexList.Length; i++)
                {
                    if (id == indexList[i])
                    {
                        result = new uint[] { indexList[i - 1], indexList[i], };
                        break;
                    }
                }

                if (result != null)
                { return result; }
                else
                { throw new Exception("This should not happen!"); }
            }
        }
    }
}