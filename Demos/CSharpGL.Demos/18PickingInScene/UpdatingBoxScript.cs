﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class UpdatingBoxScript : Script
    {
        private string boxName;
        public UpdatingBoxScript(string boxName)
        {
            this.boxName = boxName;
        }
        public void UpdateBoundingBox()
        {
            BoundingBox box = GetBoundingBox();
            vec3 max = new vec3(
                Math.Max(-box.MinPosition.x, box.MaxPosition.x),
                Math.Max(-box.MinPosition.y, box.MaxPosition.y),
                Math.Max(-box.MinPosition.z, box.MaxPosition.z)
                );
            var self = this.BindingObject.Renderer as IModelSpace;
            self.Lengths = max + max;

            var childBox = this.BindingObject.FindChild(boxName);
            var boxRenderer = childBox.Renderer;
            boxRenderer.Dispose();
            childBox.Renderer = self.GetBoundingBoxRenderer();
        }

        private BoundingBox GetBoundingBox()
        {
            BoundingBox box = null;
            var self = this.BindingObject.Renderer as PickableRenderer;
            PropertyBufferPtr positionPtr = self.PositionBufferPtr;
            positionPtr.Bind();
            IntPtr pointer = OpenGL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (vec3*)pointer;
                vec3 max = array[0], min = array[0];
                for (int i = 1; i < positionPtr.ByteLength / sizeof(vec3); i++)
                {
                    vec3 position = array[i];
                    position.UpdateMax(ref max);
                    position.UpdateMin(ref min);
                }
                box = new BoundingBox(min, max);
            }
            OpenGL.UnmapBuffer(BufferTarget.ArrayBuffer);

            return box;
        }
    }
}
