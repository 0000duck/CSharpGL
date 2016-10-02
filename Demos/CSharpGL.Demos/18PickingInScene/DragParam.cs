﻿using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL.Demos
{
    internal class DragParam
    {
        public List<uint> pickedVertexIds = new List<uint>();
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public Point lastMousePositionOnScreen;
        public vec4 viewport;

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen)
        {
            this.projectionMatrix = projectionMatrix;
            this.viewMatrix = viewMatrix;
            this.lastMousePositionOnScreen = lastMousePositionOnScreen;
            var viewport = new int[4]; OpenGL.GetInteger(GetTarget.Viewport, viewport);
            this.viewport = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen,
           IEnumerable<uint> indexes)
            : this(projectionMatrix, viewMatrix, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public DragParam(mat4 projectionMatrix, mat4 viewMatrix, Point lastMousePositionOnScreen,
            params uint[] indexes)
            : this(projectionMatrix, viewMatrix, lastMousePositionOnScreen)
        {
            this.pickedVertexIds.AddRange(indexes);
        }

        public override string ToString()
        {
            return string.Format("Last Mouse Position On Screen: [{0}]", this.lastMousePositionOnScreen);
        }
    }
}