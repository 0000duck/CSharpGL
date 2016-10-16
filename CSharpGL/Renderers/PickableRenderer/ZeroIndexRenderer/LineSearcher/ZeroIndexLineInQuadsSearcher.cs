﻿namespace CSharpGL
{
    internal class ZeroIndexLineInQuadSearcher : ZeroIndexLineSearcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Alloc(8);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = lastVertexId - 1; array[1] = lastVertexId - 0;
                    array[2] = lastVertexId - 2; array[3] = lastVertexId - 1;
                    array[4] = lastVertexId - 3; array[5] = lastVertexId - 2;
                    array[6] = lastVertexId - 0; array[7] = lastVertexId - 3;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (id + 3 == lastVertexId)
            { return new uint[] { id + 3, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}