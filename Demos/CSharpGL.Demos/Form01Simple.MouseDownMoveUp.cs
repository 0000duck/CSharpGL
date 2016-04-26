﻿using CSharpGL.ModelAdapters;
using CSharpGL.Models;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form01Simple
    {

        DragParam dragParam;

        private FormBulletinBoard mouseDownBoard;
        private FormBulletinBoard mouseMoveBoard;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                PickedGeometry pickedGeometry = RunPicking(e.X, e.Y);
                if (pickedGeometry != null)
                {
                    var dragParam = new DragParam(camera, pickedGeometry);
                    dragParam.lastFarPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 1),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    //dragParam.lastNearPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 0),
                    //dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    this.dragParam = dragParam;

                    this.mouseDownBoard.SetContent(string.Format("MouseDown{0}{1}",
                        Environment.NewLine, dragParam));
                }
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseMove(e.X, e.Y);
                //this.cameraUpdated = true;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                if (this.dragParam != null)
                {
                    vec3 farPos = glm.unProject(new vec3(e.X, glCanvas1.Height - e.Y - 1, 1),
                        dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    vec3 farDifference = farPos - dragParam.lastFarPos;
                    dragParam.lastFarPos = farPos;
                    vec3[] differences = dragParam.GetDifferences(farDifference);
                    this.rendererDict[this.selectedModel].MovePositions(
                        differences, dragParam.pickedGeometry.Indexes);

                    this.mouseMoveBoard.SetContent(string.Format("MouseMove{0}{1}",
                        Environment.NewLine, dragParam));
                }
                else
                { this.mouseDownBoard.SetContent("Mouse Move: No action."); }
            }
            else
            {
                RunPicking(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // operate camera
                rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // move vertex
                //this.pickedGeometry = null;
                this.dragParam = null;

                this.mouseDownBoard.SetContent("Mouse Up: No action.");
            }
        }

        private PickedGeometry RunPicking(int x, int y)
        {
            lock (this.synObj)
            {
                {
                    this.glCanvas1_OpenGLDraw(selectedModel, null);
                    Color c = GL.ReadPixel(x, this.glCanvas1.Height - y - 1);
                    c = Color.FromArgb(255, c);
                    this.lblReadColor.BackColor = c;
                    this.lblReadColor.Text = string.Format("Color at mouse: {0}", c);
                }
                {
                    IColorCodedPicking pickable = this.rendererDict[this.SelectedModel];
                    pickable.MVP = this.camera.GetProjectionMat4() * this.camera.GetViewMat4();
                    PickedGeometry pickedGeometry = ColorCodedPicking.Pick(
                        this.camera, x, y, this.glCanvas1.Width, this.glCanvas1.Height, pickable);
                    if (pickedGeometry != null)
                    {
                        this.RunPickingBoard.SetContent(pickedGeometry.ToString(
                            camera.GetProjectionMat4(), camera.GetViewMat4()));
                    }
                    else
                    {
                        this.RunPickingBoard.SetContent("picked nothing.");
                    }

                    return pickedGeometry;
                }
            }
        }

        class DragParam
        {
            public DragParam(Camera camera, PickedGeometry pickedGeometry)
            {
                this.pickedGeometry = pickedGeometry;
                this.projectionMatrix = camera.GetProjectionMat4();
                this.viewMatrix = camera.GetViewMat4();
                var viewport = new int[4]; GL.GetInteger(GetTarget.Viewport, viewport);
                this.viewport = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);

                this.k = new float[pickedGeometry.Positions.Length];
                this.worldPos = new vec3[pickedGeometry.Positions.Length];
                this.windowPos = new vec3[pickedGeometry.Positions.Length];
                this.factors = new vec3[pickedGeometry.Positions.Length];
                for (int i = 0; i < pickedGeometry.Positions.Length; i++)
                {
                    var worldPos = new vec3(projectionMatrix * viewMatrix * new vec4(pickedGeometry.Positions[i], 1));
                    vec3 windowPos = glm.project(worldPos, viewMatrix, projectionMatrix, this.viewport);
                    vec3 win = new vec3(windowPos.x, windowPos.y, 1);
                    var farPos = glm.unProject(win, viewMatrix, projectionMatrix, this.viewport);
                    //win.z = 0;
                    //vec3 nearPos = glm.unProject(win,
                    //    dragParam.viewMatrix, dragParam.projectionMatrix, dragParam.viewport);
                    vec3 vTarget = worldPos - camera.Position;//nearPos;
                    vec3 vFar = farPos - camera.Position;// nearPos;
                    float x = vTarget.x / vFar.x;
                    float y = vTarget.y / vFar.y;
                    float z = vTarget.z / vFar.z;
                    this.k[i] = x / 3 + y / 3 + z / 3;

                    this.worldPos[i] = worldPos;
                    this.windowPos[i] = windowPos;
                    this.factors[i] = new vec3(x, y, z);
                }
            }

            public vec3 lastFarPos;
            //public vec3 lastNearPos;
            public float[] k;
            public vec3[] factors;
            public vec3[] worldPos;
            public vec3[] windowPos;
            public mat4 projectionMatrix;
            public mat4 viewMatrix;
            public vec4 viewport;
            public PickedGeometry pickedGeometry;

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < this.k.Length; i++)
                {
                    builder.AppendLine(string.Format("[{0}]: ", this.pickedGeometry.Indexes[i]));
                    builder.AppendLine(string.Format("far pos: [{0}]", lastFarPos[i]));
                    builder.AppendLine(string.Format("depth: [{0}]", this.k[i]));
                    builder.AppendLine(string.Format("factor: [{0}]", this.factors[i]));
                    builder.AppendLine(string.Format("worldPos: [{0}]", this.worldPos[i]));
                    builder.AppendLine(string.Format("windowPos: [{0}]", this.windowPos[i]));
                    builder.AppendLine();
                }
                builder.AppendLine("viewport: ");
                builder.AppendLine(this.viewport.ToString());
                builder.AppendLine("projection matrix: ");
                builder.AppendLine(this.projectionMatrix.ToString());
                builder.AppendLine("view matrix: ");
                builder.AppendLine(this.viewMatrix.ToString());

                return builder.ToString();
            }

            public vec3[] GetDifferences(vec3 farDifference)
            {
                mat4 inversed = glm.inverse(this.projectionMatrix * this.viewMatrix);
                var differences = new vec3[this.k.Length];
                for (int i = 0; i < differences.Length; i++)
                {
                    differences[i] = this.k[i] * farDifference;
                    differences[i] = new vec3(inversed * (new vec4(differences[i], 0)));
                }

                return differences;
            }
        }
    }
}
