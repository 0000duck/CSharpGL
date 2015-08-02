﻿using CSharpGL.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.Cameras
{
    public static class CameraHelper
    {
        /// <summary>
        /// Adjusts camera's settings according to bounding box.
        /// <para>Use this when bounding box's size or positon is changed.</para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        /// <param name="openGL"></param>
        public static void AdjustCamera(this IPerspectiveViewCamera camera, IBoundingBox boundingBox)
        {
            float sizeX, sizeY, sizeZ;
            boundingBox.GetBoundDimensions(out sizeX, out sizeY, out sizeZ);
            float size = Math.Max(Math.Max(sizeX, sizeY), sizeZ);

            {
                float centerX, centerY, centerZ;
                boundingBox.GetCenter(out centerX, out centerY, out centerZ);
                vec3 target = new vec3(centerX, centerY, centerZ);

                vec3 target2Position = camera.Position - camera.Target;
                target2Position.Normalize();

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                //camera.UpVector = new vec3(0f, 1f, 0f);
            }

            {
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                camera.FieldOfView = 60;
                camera.AspectRatio = (double)width / (double)height;
                camera.Near = 0.01;
                camera.Far = size * 3 + 1;// double.MaxValue;
            }
        }

        /// <summary>
        /// Adjusts camera's settings according to bounding box.
        /// <para>Use this when bounding box's size or positon is changed.</para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        /// <param name="openGL"></param>
        public static void AdjustCamera(this IOrthoViewCamera camera, IBoundingBox boundingBox)
        {
            float sizeX, sizeY, sizeZ;
            boundingBox.GetBoundDimensions(out sizeX, out sizeY, out sizeZ);
            float size = Math.Max(Math.Max(sizeX, sizeY), sizeZ);

            {
                float centerX, centerY, centerZ;
                boundingBox.GetCenter(out centerX, out centerY, out centerZ);
                vec3 target = new vec3(centerX, centerY, centerZ);

                vec3 target2Position = camera.Position - camera.Target;
                target2Position.Normalize();

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                //camera.UpVector = new vec3(0f, 1f, 0f);
            }

            {
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                if (width > height)
                {
                    camera.Left = -size * width / height;
                    camera.Right = size * width / height;
                    camera.Bottom = -size;
                    camera.Top = size;
                }
                else
                {
                    camera.Left = -size;
                    camera.Right = size;
                    camera.Bottom = -size * height / width;
                    camera.Top = size * height / width;
                }
                camera.Near = 0;
                camera.Far = size * 3 + 1;// double.MaxValue;
            }
        }

        /// <summary>
        /// Apply specifed viewType to camera according to bounding box's size and position.
        /// <para>    +-------+    </para>
        /// <para>   /|      /|    </para>
        /// <para>  +-------+ |    </para>
        /// <para>  | |     | |    </para>
        /// <para>  | O-----|-+---X</para>
        /// <para>  |/      |/     </para>
        /// <para>  +-------+      </para>
        /// <para> /  |            </para>
        /// <para>Y   Z            </para>
        /// <para>其边长为(2 * Math.Sqrt(3)), 所在的坐标系如下</para>
        /// <para>   O---X</para>
        /// <para>  /|    </para>
        /// <para> Y |    </para>
        /// <para>   Z    </para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        /// <param name="openGL"></param>
        /// <param name="viewType"></param>
        public static void ApplyViewType(this IPerspectiveViewCamera camera, IBoundingBox boundingBox,
            ViewTypes viewType)
        {
            float sizeX, sizeY, sizeZ;
            boundingBox.GetBoundDimensions(out sizeX, out sizeY, out sizeZ);
            float size = Math.Max(Math.Max(sizeX, sizeY), sizeZ);

            {
                float centerX, centerY, centerZ;
                boundingBox.GetCenter(out centerX, out centerY, out centerZ);
                vec3 target = new vec3(centerX, centerY, centerZ);

                vec3 target2Position;
                vec3 upVector;
                GetBackAndUp(out target2Position, out upVector, viewType);

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                camera.UpVector = upVector;
            }

            {
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                IPerspectiveCamera perspectiveCamera = camera;
                perspectiveCamera.FieldOfView = 60;
                perspectiveCamera.AspectRatio = (double)width / (double)height;
                perspectiveCamera.Near = 0.01;
                perspectiveCamera.Far = size * 3 + 1;// double.MaxValue;
            }
        }

        /// <summary>
        /// Apply specifed viewType to camera according to bounding box's size and position.
        /// <para>    +-------+    </para>
        /// <para>   /|      /|    </para>
        /// <para>  +-------+ |    </para>
        /// <para>  | |     | |    </para>
        /// <para>  | O-----|-+---X</para>
        /// <para>  |/      |/     </para>
        /// <para>  +-------+      </para>
        /// <para> /  |            </para>
        /// <para>Y   Z            </para>
        /// <para>其边长为(2 * Math.Sqrt(3)), 所在的坐标系如下</para>
        /// <para>   O---X</para>
        /// <para>  /|    </para>
        /// <para> Y |    </para>
        /// <para>   Z    </para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        /// <param name="openGL"></param>
        /// <param name="viewType"></param>
        public static void ApplyViewType(this IOrthoViewCamera camera, IBoundingBox boundingBox,
             ViewTypes viewType)
        {
            float sizeX, sizeY, sizeZ;
            boundingBox.GetBoundDimensions(out sizeX, out sizeY, out sizeZ);
            float size = Math.Max(Math.Max(sizeX, sizeY), sizeZ);

            {
                float centerX, centerY, centerZ;
                boundingBox.GetCenter(out centerX, out centerY, out centerZ);
                vec3 target = new vec3(centerX, centerY, centerZ);

                vec3 target2Position;
                vec3 upVector;
                GetBackAndUp(out target2Position, out upVector, viewType);

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                camera.UpVector = upVector;
            }

            {
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                IOrthoCamera orthoCamera = camera;
                if (width > height)
                {
                    orthoCamera.Left = -size * width / height;
                    orthoCamera.Right = size * width / height;
                    orthoCamera.Bottom = -size;
                    orthoCamera.Top = size;
                }
                else
                {
                    orthoCamera.Left = -size;
                    orthoCamera.Right = size;
                    orthoCamera.Bottom = -size * height / width;
                    orthoCamera.Top = size * height / width;
                }
                orthoCamera.Near = 0.001;
                orthoCamera.Far = size * 3 + 1;// double.MaxValue;
            }
        }

        private static void GetBackAndUp(out vec3 target2Position, out vec3 upVector, ViewTypes viewType)
        {
            switch (viewType)
            {
                case ViewTypes.UserView:
                    //UserView 定义为从顶视图开始，绕X 轴旋转30 度，在绕Z 轴45 度，并且能看到整个模型的虚拟模型空间。
                    target2Position = new vec3((float)Math.Sqrt(3), (float)Math.Sqrt(3), -1);
                    target2Position.Normalize();
                    upVector = new vec3(0, 0, -1);
                    break;
                case ViewTypes.Top:
                    target2Position = new vec3(0, 0, -1);
                    upVector = new vec3(0, -1, 0);
                    break;
                case ViewTypes.Bottom:
                    target2Position = new vec3(0, 0, 1);
                    upVector = new vec3(0, -1, 0);
                    break;
                case ViewTypes.Left:
                    target2Position = new vec3(-1, 0, 0);
                    upVector = new vec3(0, 0, -1);
                    break;
                case ViewTypes.Right:
                    target2Position = new vec3(1, 0, 0);
                    upVector = new vec3(0, 0, -1);
                    break;
                case ViewTypes.Front:
                    target2Position = new vec3(0, 1, 0);
                    upVector = new vec3(0, 0, -1);
                    break;
                case ViewTypes.Back:
                    target2Position = new vec3(0, -1, 0);
                    upVector = new vec3(0, 0, -1);
                    break;
                default:
                    throw new NotImplementedException(string.Format("new value({0}) of EViewType is not implemented!", viewType));
                //break;
            }
        }

        /// <summary>
        /// 对摄像机执行一次缩放操作
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="delta"></param>
        public void Scale(this IScientificCamera camera, int delta)
        {
            //if (camera.CameraType == CameraTypes.Perspecitive)
            {
                var target2Position = camera.Position - camera.Target;
                if (target2Position.Magnitude() < 0.01)
                {
                    target2Position = target2Position.Normalize();
                    target2Position.x *= 0.01f;
                    target2Position.y *= 0.01f;
                    target2Position.z *= 0.01f;
                }
                var scaledTarget2Position = target2Position * (1 - delta * 0.001f);
                camera.Position = camera.Target + scaledTarget2Position;
                double lengthDiff = scaledTarget2Position.Magnitude() - target2Position.Magnitude();
                // Increase ortho camera's Near/Far property in case the camera's position changes too much.
                IPerspectiveCamera perspectiveCamera = camera;
                perspectiveCamera.Far += lengthDiff;
                //perspectiveCamera.Near += lengthDiff;
                IOrthoCamera orthoCamera = camera;
                orthoCamera.Far += lengthDiff;
                orthoCamera.Near += lengthDiff;
            }
            //else if (camera.CameraType == CameraTypes.Ortho)
            {
                IOrthoCamera orthoCamera = camera;
                double distanceX = orthoCamera.Right - orthoCamera.Left;
                double distanceY = orthoCamera.Top - orthoCamera.Bottom;
                double centerX = (orthoCamera.Left + orthoCamera.Right) / 2;
                double centerY = (orthoCamera.Bottom + orthoCamera.Top) / 2;
                orthoCamera.Left = centerX - distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Right = centerX + distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Bottom = centerY - distanceY * (1 - delta * 0.001) / 2;
                orthoCamera.Top = centerX + distanceY * (1 - delta * 0.001) / 2;
            }
        }

        /// <summary>
        /// 实施传统方式的投影
        /// </summary>
        /// <param name="camera"></param>
        public void LegacyGLProjection(this IScientificCamera camera)
        {
            //	Load the projection identity matrix.
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.LoadIdentity();

            //	Perform the projection.
            switch (camera.CameraType)
            {
                case CameraTypes.Perspecitive:
                    IPerspectiveCamera perspectiveCamera = camera;
                    GL.gluPerspective(perspectiveCamera.FieldOfView, perspectiveCamera.AspectRatio, perspectiveCamera.Near, perspectiveCamera.Far);
                    break;
                case CameraTypes.Ortho:
                    IOrthoCamera orthoCamera = camera;
                    GL.Ortho(orthoCamera.Left, orthoCamera.Right, orthoCamera.Bottom, orthoCamera.Top, orthoCamera.Near, orthoCamera.Far);
                    break;
                default:
                    break;
            }

            //  Perform the look at transformation.
            GL.gluLookAt((double)camera.Position.x, (double)camera.Position.y, (double)camera.Position.z,
                (double)camera.Target.x, (double)camera.Target.y, (double)camera.Target.z,
                (double)camera.UpVector.x, (double)camera.UpVector.y, (double)camera.UpVector.z);

            //	Back to the modelview matrix.
            GL.MatrixMode(GL.GL_MODELVIEW);
        }

        /// <summary>
        /// Extension method for <see cref="IPerspectiveCamera"/> to get projection matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMat4(this IPerspectiveCamera camera)
        {
            mat4 perspective = glm.perspective(
                (float)(camera.FieldOfView / 360.0 * Math.PI * 2),
                (float)camera.AspectRatio, (float)camera.Near, (float)camera.Far);
            return perspective;
        }

        /// <summary>
        /// Extension method for <see cref="IOrthoCamera"/> to get projection matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMat4(this IOrthoCamera camera)
        {
            mat4 ortho = glm.ortho((float)camera.Left, (float)camera.Right,
                (float)camera.Bottom, (float)camera.Top,
                (float)camera.Near, (float)camera.Far);
            return ortho;
        }

        /// <summary>
        /// Extension method for <see cref="IViewCamera"/> to get view matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetViewMat4(this IViewCamera camera)
        {
            mat4 lookAt = glm.lookAt(camera.Position, camera.Target, camera.UpVector);
            return lookAt;
        }

    }
}
