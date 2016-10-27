﻿namespace CSharpGL
{
    internal class ZeroIndexLineInPolygonSearcher : ZeroIndexLineSearcher
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
            ZeroIndexBufferPtr zeroIndexBufferPtr = modernRenderer.IndexBufferPtr;
            ZeroIndexBufferPtr indexBufferPtr = null;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            using (var buffer = new ZeroIndexBuffer(DrawMode.LineLoop,
                zeroIndexBufferPtr.FirstVertex, zeroIndexBufferPtr.RenderingVertexCount))
            {
                indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
            }
            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (id == zeroIndexBufferPtr.FirstVertex)
            { return new uint[] { (uint)(zeroIndexBufferPtr.FirstVertex + zeroIndexBufferPtr.RenderingVertexCount - 1), id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}