﻿using CSharpGL.Models;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ModelAdapters
{
    class BigDipperAdapter : IBufferable
    {
        private BigDipper model;
        public BigDipperAdapter(BigDipper model)
        {
            this.model = model;
        }

        public const string position = "position";
        public const string color = "color";
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.Positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.Positions.Length; i++)
                            {
                                array[i] = model.Positions[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == color)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.Colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.Colors.Length; i++)
                            {
                                array[i] = model.Colors[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer<uint>(
                    DrawMode.LineStrip, BufferUsage.StaticDraw))
                {
                    buffer.Alloc(model.Indexes.Length);
                    unsafe
                    {
                        var array = (uint*)buffer.FirstElement();
                        for (int i = 0; i < model.Indexes.Length; i++)
                        {
                            array[i] = model.Indexes[i];
                        }
                    }

                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
    }
}
