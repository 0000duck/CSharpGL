﻿using CSharpGL.Models;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ModelAdapters
{
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

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strColor)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else if (bufferName == strNormal)
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

                    return buffer.GetBufferPtr() as PropertyBufferPtr;
                }
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndex()
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

                return buffer.GetBufferPtr() as IndexBufferPtr;
            }
        }
    }

}
