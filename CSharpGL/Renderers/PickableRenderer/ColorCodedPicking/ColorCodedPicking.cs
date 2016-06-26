﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public static class ColorCodedPicking
    {

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="arg></param>
        /// <param name="x">鼠标位置</param>
        /// <param name="y">鼠标位置</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static PickedGeometry Pick(
            RenderEventArg arg,
            int x, int y,
            params PickableRenderer[] pickableElements)
        {
            if (x < 0 || arg.CanvasRect.Width <= x || y < 0 || arg.CanvasRect.Height <= y) { return null; }

            Rectangle rect = new Rectangle(x, y, 1, 1);
            List<Tuple<Point, PickedGeometry>> list = Pick(arg,
                rect, pickableElements);
            if (list.Count > 0)
            { return list[0].Item2; }
            else
            { return null; }
        }

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="x">鼠标位置</param>
        /// <param name="y">鼠标位置</param>
        /// <param name="radius">以鼠标位置为中心，在半径为<paramref name="radius"/>的正方形范围内进行拾取</param>
        /// <param name="width">画布宽度</param>
        /// <param name="height">画布高度</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static List<Tuple<Point, PickedGeometry>> Pick(
            RenderEventArg arg,
            int x, int y, int radius,
            params PickableRenderer[] pickableElements)
        {
            if (x < 0 || arg.CanvasRect.Width <= x || y < 0 || arg.CanvasRect.Height <= y) { return null; }

            Rectangle rect = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            return Pick(arg, rect, pickableElements);
        }

        /// <summary>
        /// Color Coded Picking
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="rect">拾取范围</param>
        /// <param name="pickableElements">在哪些对象中执行拾取操作</param>
        /// <returns></returns>
        public static List<Tuple<Point, PickedGeometry>> Pick(
            RenderEventArg arg,
            Rectangle rect,
            params PickableRenderer[] pickableElements)
        {
            var result = new List<Tuple<Point, PickedGeometry>>();
            if (pickableElements.Length == 0) { return result; }

            Render4Picking(arg, pickableElements);
            List<Tuple<Point, uint>> stageVertexIdList = ReadPixels(rect, arg.CanvasRect.Height);
            foreach (var tuple in stageVertexIdList)
            {
                int x = tuple.Item1.X;
                int y = tuple.Item1.Y;
                if (x < 0 || arg.CanvasRect.Width <= x || y < 0 || arg.CanvasRect.Height <= y) { continue; }

                uint stageVertexId = tuple.Item2;
                PickedGeometry pickedGeometry = PickGeometry(arg,
                    x, y, stageVertexId, pickableElements);
                if (pickedGeometry != null)
                {
                    result.Add(new Tuple<Point, PickedGeometry>(new Point(x, y), pickedGeometry));
                }
            }

            return result;
        }

        /// <summary>
        /// 在多个buffer中拾取一个图元
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="pickableElements"></param>
        public static void Render4Picking(RenderEventArg arg, params PickableRenderer[] pickableElements)
        {
            if (arg.RenderMode != RenderModes.ColorCodedPicking)
            {
                throw new ArgumentException();
            }

            // record clear color
            var originalClearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            // 白色意味着没有拾取到任何对象
            // white color: nothing picked.
            OpenGL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            OpenGL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            uint renderedVertexCount = 0;
            foreach (var pickable in pickableElements)
            {
                if (pickable == null) { continue; }

                pickable.PickingBaseId = renderedVertexCount;

                //  render the element for picking.
                pickable.Render(arg);

                uint rendered = renderedVertexCount + pickable.GetVertexCount();
                if (renderedVertexCount <= rendered)
                {
                    renderedVertexCount = rendered;
                }
                else
                {
                    throw new Exception(string.Format(
                        "Too many geometries({0} + {1} > {2}) for color coded picking.",
                            renderedVertexCount, pickable.GetVertexCount(), uint.MaxValue));
                }
            }

            OpenGL.Flush();
        }


        /// <summary>
        /// get picked primitive
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="pickableElements"></param>
        /// <returns></returns>
        private static PickedGeometry PickGeometry(RenderEventArg arg,
            int x, int y,
            uint stageVertexId,
            params IColorCodedPicking[] pickableElements)
        {
            PickedGeometry pickedGeometry = null;
            foreach (var item in pickableElements)
            {
                pickedGeometry = item.Pick(arg, stageVertexId,
                    x, y);
                if (pickedGeometry != null)
                { break; }
            }

            return pickedGeometry;
        }

        /// <summary>
        /// 读取指定范围内的像素，获取其代表的VertexId
        /// <para>Read specified rect and get the VertexIds they represent.</para>
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="canvasHeight"></param>
        /// <returns></returns>
        public static unsafe List<Tuple<Point, uint>> ReadPixels(
            Rectangle rect, int canvasHeight)
        {
            var result = new List<Tuple<Point, uint>>();
            if (rect.Width <= 0 || rect.Height <= 0) { return result; }

            // get coded color.
            using (var codedColor = new UnmanagedArray<Pixel>(rect.Width * rect.Height))
            {
                OpenGL.ReadPixels(rect.X, canvasHeight - rect.Y - 1, rect.Width, rect.Height,
                    OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);

                var array = (Pixel*)codedColor.Header.ToPointer();
                int index = 0;
                var vertexIdList = new List<uint>();
                for (int yOffset = rect.Height - 1; yOffset >= 0; yOffset--)
                {
                    for (int xOffset = 0; xOffset < rect.Width; xOffset++)
                    {
                        Pixel pixel = array[index++];
                        if (!
                            // This is when (x, y) is on background and no primitive is picked.
                            (pixel.r == byte.MaxValue && pixel.g == byte.MaxValue
                            && pixel.b == byte.MaxValue && pixel.a == byte.MaxValue))
                        {
                            /* // This is how is vertexID coded into color in vertex shader.
                             * 	int objectID = gl_VertexID;
                                codedColor = vec4(
                                    float(objectID & 0xFF), 
                                    float((objectID >> 8) & 0xFF), 
                                    float((objectID >> 16) & 0xFF), 
                                    float((objectID >> 24) & 0xFF));
                             */
                            // get vertexID from coded color.
                            // the vertexID is the last vertex that constructs the primitive.
                            // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                            uint shiftedR = (uint)pixel.r;
                            uint shiftedG = (uint)pixel.g << 8;
                            uint shiftedB = (uint)pixel.b << 16;
                            uint shiftedA = (uint)pixel.a << 24;
                            var vertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                            if (!vertexIdList.Contains(vertexId))
                            {
                                result.Add(new Tuple<Point, uint>(
                                    new Point(rect.X + xOffset, rect.Y + yOffset), vertexId));
                                vertexIdList.Add(vertexId);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static unsafe uint ReadPixel(
            int x, int y, int canvasHeight)
        {
            uint stageVertexId = uint.MaxValue;
            // get coded color.
            using (var codedColor = new UnmanagedArray<byte>(4))
            {
                OpenGL.ReadPixels(x, canvasHeight - y - 1, 1, 1, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);
                var array = (Pixel*)codedColor.Header.ToPointer();
                Pixel pixel = array[0];
                if (!
                    // This is when (x, y) is on background and no primitive is picked.
                    (pixel.r == byte.MaxValue && pixel.g == byte.MaxValue
                    && pixel.b == byte.MaxValue && pixel.a == byte.MaxValue))
                {
                    /* // This is how is vertexID coded into color in vertex shader.
                     * 	int objectID = gl_VertexID;
                        codedColor = vec4(
                            float(objectID & 0xFF), 
                            float((objectID >> 8) & 0xFF), 
                            float((objectID >> 16) & 0xFF), 
                            float((objectID >> 24) & 0xFF));
                     */
                    // get vertexID from coded color.
                    // the vertexID is the last vertex that constructs the primitive.
                    // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                    uint shiftedR = (uint)pixel.r;
                    uint shiftedG = (uint)pixel.g << 8;
                    uint shiftedB = (uint)pixel.b << 16;
                    uint shiftedA = (uint)pixel.a << 24;
                    stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                }
            }

            return stageVertexId;
        }

    }

}
