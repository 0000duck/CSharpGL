﻿using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.UI.SimpleUI
{
    public static class IUILayoutHelper
    {

        /// <summary>
        /// 获取此UI元素的投影矩阵、视图矩阵和模型矩阵
        /// </summary>
        /// <param name="uiElement"></param>
        /// <param name="projectionMatrix"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="modelMatrix"></param>
        /// <param name="camera">如果为null，会以glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0))计算默认值。</param>
        /// <param name="maxDepth">UI元素能接触到的最大深度。</param>
        public static void GetMatrix(this IUILayout uiElement,
            out mat4 projectionMatrix, out mat4 viewMatrix, out mat4 modelMatrix,
            IViewCamera camera = null, float maxDepth = 1.0f)
        {
            IUILayoutArgs args = uiElement.GetArgs();
            float max = (float)Math.Max(args.UIWidth, args.UIHeight);

            {
                projectionMatrix = glm.ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top,
                    uiElement.Param.zNear, uiElement.Param.zFar);

                // 把UI元素移到ortho长方体的最靠近camera的地方，这样就可以把UI元素放到OpenGL最前方。
                projectionMatrix = glm.translate(projectionMatrix, new vec3(0, 0, uiElement.Param.zFar - max / 2 * maxDepth));
            }
            {
                if (camera == null)
                {
                    viewMatrix = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
                }
                else
                {
                    vec3 position = camera.Position - camera.Target;
                    position.Normalize();
                    viewMatrix = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                }
            }
            {
                //modelMatrix = glm.scale(mat4.identity(), new vec3(max / 2, max / 2, max / 2));
                modelMatrix = glm.scale(mat4.identity(), new vec3(args.UIWidth / 2, args.UIHeight / 2, max / 2));
            }
        }


        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        public static IUILayoutArgs GetArgs(this IUILayout uiElement)
        {
            var args = new IUILayoutArgs();

            CalculateViewport(args);

            CalculateCoords(uiElement, args.viewportWidth, args.viewportHeight, args);

            return args;
        }

        static void CalculateViewport(IUILayoutArgs args)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            args.viewportWidth = viewport[2];
            args.viewportHeight = viewport[3];
        }

        static void CalculateCoords(IUILayout uiElement, int viewportWidth, int viewportHeight, IUILayoutArgs args)
        {
            IUILayoutParam param = uiElement.Param;

            if ((param.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.UIWidth = viewportWidth - param.Margin.Left - param.Margin.Right;
                if (args.UIWidth < 0) { args.UIWidth = 0; }
            }
            else
            {
                args.UIWidth = param.Size.Width;
            }

            if ((param.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.UIHeight = viewportHeight - param.Margin.Top - param.Margin.Bottom;
                if (args.UIHeight < 0) { args.UIHeight = 0; }
            }
            else
            {
                args.UIHeight = param.Size.Height;
            }

            if ((param.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                args.left = -(args.UIWidth / 2
                    + (viewportWidth - args.UIWidth)
                        * ((double)param.Margin.Left / (double)(param.Margin.Left + param.Margin.Right)));
            }
            else if ((param.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                args.left = -(args.UIWidth / 2 + param.Margin.Left);
            }
            else if ((param.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                args.left = -(viewportWidth - args.UIWidth / 2 - param.Margin.Right);
            }
            else // if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.left = -(args.UIWidth / 2 + param.Margin.Left);
            }

            if ((param.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                args.bottom = -viewportHeight / 2;
                args.bottom = -(args.UIHeight / 2
                    + (viewportHeight - args.UIHeight) 
                        * ((double)param.Margin.Bottom / (double)(param.Margin.Bottom + param.Margin.Top)));
            }
            else if ((param.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                args.bottom = -(args.UIHeight / 2 + param.Margin.Bottom);
            }
            else if ((param.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                args.bottom = -(viewportHeight - args.UIHeight / 2 - param.Margin.Top);
            }
            else // if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.bottom = -(args.UIHeight / 2 + param.Margin.Bottom);
            }
        }
    }
}
