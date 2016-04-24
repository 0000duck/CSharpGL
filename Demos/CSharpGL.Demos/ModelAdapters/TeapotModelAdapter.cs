﻿using CSharpGL.Models;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ModelAdapters
{
    /// <summary>
    /// 经典的茶壶模型
    /// <para>使用<see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class TeapotModelAdapter : IBufferable
    {

        public TeapotModelAdapter(TeapotModel model)
        {
            this.model = model;
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        public const string strNormal = "normal";
        private TeapotModel model;
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.positions.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.positions.Count; i++)
                            {
                                array[i] = model.positions[i];
                            }
                        }
                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == strColor)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.normals.Count; i++)
                            {
                                array[i] = model.normals[i];
                            }
                        }
                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == strNormal)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < model.normals.Count; i++)
                            {
                                array[i] = model.normals[i];
                            }
                        }
                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer<uint>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Alloc(model.faces.Count * 3);
                    unsafe
                    {
                        uint* array = (uint*)buffer.FirstElement();
                        for (int i = 0; i < model.faces.Count; i++)
                        {
                            //TODO: 用ushort类型的IndexBuffer就会引发系统错误，为什么？
                            //array[i * 3 + 0] = (ushort)(faces[i].Item1 - 1);
                            //array[i * 3 + 1] = (ushort)(faces[i].Item2 - 1);
                            //array[i * 3 + 2] = (ushort)(faces[i].Item3 - 1);

                            array[i * 3 + 0] = (uint)(model.faces[i].Item1 - 1);
                            array[i * 3 + 1] = (uint)(model.faces[i].Item2 - 1);
                            array[i * 3 + 2] = (uint)(model.faces[i].Item3 - 1);
                        }
                    }

                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }
        IndexBufferPtr indexBufferPtr = null;
    }

}
