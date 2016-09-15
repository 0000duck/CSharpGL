﻿using System;
using System.Collections.Generic;

namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderCodes.CreateProgram();

            VertexAttributeBufferPtr positionBufferPtr = null;
            IBufferable bufferable = this.model;
            VertexAttributeBufferPtr[] propertyBufferPtrs;
            {
                var list = new List<VertexAttributeBufferPtr>();
                foreach (var item in propertyNameMap)
                {
                    VertexAttributeBufferPtr bufferPtr = bufferable.GetProperty(
                     item.NameInIBufferable, item.VarNameInShader);
                    if (bufferPtr == null) { throw new Exception(string.Format("[{0}] returns null buffer pointer!", bufferable)); }

                    if (item.NameInIBufferable == positionNameInIBufferable)
                    {
                        positionBufferPtr = new VertexAttributeBufferPtr(
                            "in_Position",// in_Postion same with in the PickingShader.vert shader
                            bufferPtr.BufferId,
                            bufferPtr.Config,
                            bufferPtr.Length,
                            bufferPtr.ByteLength,
                            0);
                        break;
                    }
                    list.Add(bufferPtr);
                }
                propertyBufferPtrs = list.ToArray();
            }

            // 由于picking.vert/frag只支持vec3的position buffer，所以有此硬性规定。
            if (positionBufferPtr == null || positionBufferPtr.Config != VertexAttributeConfig.Vec3)
            { throw new Exception(string.Format("Position buffer must use a type composed of 3 float as PropertyBuffer<T>'s T!")); }

            // init index buffer.
            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();

            // RULE: Renderer takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care this rule when designing a model's index buffer.
            var ptr = indexBufferPtr as OneIndexBufferPtr;
            if (ptr != null)
            {
                GLSwitch glSwitch = new PrimitiveRestartSwitch(ptr);
                this.switchList.Add(glSwitch);
            }

            // init VAO.
            var vertexArrayObject = new VertexArrayObject(indexBufferPtr, positionBufferPtr);
            vertexArrayObject.Create(program);

            // sets fields.
            this.Program = program;
            this.propertyBufferPtrs = new VertexAttributeBufferPtr[] { positionBufferPtr };
            this.indexBufferPtr = indexBufferPtr;
            this.vertexArrayObject = vertexArrayObject;
        }
    }
}