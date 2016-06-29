﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Manipulate a camera in first-persppective's view.
    /// </summary>
    public class FirstPerspectiveManipulater :
        CameraManipulater, IMouseHandler, IKeyboardHandler
    {
        private ICamera camera;
        private Control canvas;

        private KeyPressEventHandler keyPressEvent;
        private MouseEventHandler mouseDownEvent;
        private MouseEventHandler mouseMoveEvent;
        private MouseEventHandler mouseUpEvent;
        private MouseEventHandler mouseWheelEvent;

        private bool mouseDownFlag = false;
        private Point lastPosition;

        private char upcaseFrontKey;
        private char upcaseBackKey;
        private char upcaseLeftKey;
        private char upcaseRightKey;
        private char upcaseUpKey;
        private char upcaseDownKey;
        private char frontKey;
        private char backKey;
        private char leftKey;
        private char rightKey;
        private char upKey;
        private char downKey;

        public char FrontKey
        {
            get { return frontKey; }
            set
            {
                frontKey = value.ToString().ToLower()[0];
                upcaseFrontKey = value.ToString().ToUpper()[0];
            }
        }

        public char BackKey
        {
            get { return backKey; }
            set
            {
                backKey = value.ToString().ToLower()[0];
                upcaseBackKey = value.ToString().ToUpper()[0];
            }
        }

        public char LeftKey
        {
            get { return leftKey; }
            set
            {
                leftKey = value.ToString().ToLower()[0];
                upcaseLeftKey = value.ToString().ToUpper()[0];
            }
        }

        public char RightKey
        {
            get { return rightKey; }
            set
            {
                rightKey = value.ToString().ToLower()[0];
                upcaseRightKey = value.ToString().ToUpper()[0];
            }
        }

        public char UpKey
        {
            get { return upKey; }
            set
            {
                upKey = value.ToString().ToLower()[0];
                upcaseUpKey = value.ToString().ToUpper()[0];
            }
        }

        public char DownKey
        {
            get { return downKey; }
            set
            {
                downKey = value.ToString().ToLower()[0];
                upcaseDownKey = value.ToString().ToUpper()[0];
            }
        }

        public float StepLength { get; set; }
        public float HorizontalRotationSpeed { get; set; }
        public float VerticalRotationSpeed { get; set; }
        public MouseButtons BindingMouseButtons { get; set; }

        public FirstPerspectiveManipulater()
        {
            this.FrontKey = 'w';
            this.BackKey = 's';
            this.LeftKey = 'a';
            this.RightKey = 'd';
            this.UpKey = 'q';
            this.DownKey = 'e';

            this.StepLength = 0.1f;

            this.keyPressEvent = new KeyPressEventHandler(((IKeyboardHandler)this).canvas_KeyPress);
            this.mouseDownEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseDown);
            this.mouseMoveEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseMove);
            this.mouseUpEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseUp);
            this.mouseWheelEvent = new MouseEventHandler(((IMouseHandler)this).canvas_MouseWheel);
        }

        public override void Bind(ICamera camera, System.Windows.Forms.Control canvas)
        {
            if (camera == null || canvas == null) { throw new ArgumentNullException(); }

            this.camera = camera;
            this.canvas = canvas;

            this.HorizontalRotationSpeed = 0.002f;
            this.VerticalRotationSpeed = 0.002f;

            canvas.KeyPress += this.keyPressEvent;
            canvas.MouseDown += this.mouseDownEvent;
            canvas.MouseMove += this.mouseMoveEvent;
            canvas.MouseUp += this.mouseUpEvent;
            canvas.MouseWheel += this.mouseWheelEvent;
        }

        public override void Unbind()
        {
            this.camera = null;
            if (this.canvas != null && (!this.canvas.IsDisposed))
            {
                this.canvas.KeyPress -= this.keyPressEvent;
                this.canvas.MouseDown -= this.mouseDownEvent;
                this.canvas.MouseMove -= this.mouseMoveEvent;
                this.canvas.MouseUp -= this.mouseUpEvent;
                this.canvas.MouseWheel -= this.mouseWheelEvent;
            }
        }

        void IMouseHandler.canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        void IMouseHandler.canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == this.BindingMouseButtons)
            {
                this.mouseDownFlag = true;
                this.lastPosition = e.Location;
            }
        }

        void IMouseHandler.canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownFlag && e.Button == this.BindingMouseButtons
                && (e.X != this.lastPosition.X || e.Y != this.lastPosition.Y))
            {
                mat4 rotationMatrix = glm.rotate(this.HorizontalRotationSpeed * (e.X - this.lastPosition.X), -this.camera.UpVector);
                var front = new vec4(this.camera.GetFront(), 1.0f);
                vec4 front1 = rotationMatrix * front;
                rotationMatrix = glm.rotate(this.VerticalRotationSpeed * (this.lastPosition.Y - e.Y), this.camera.GetRight());
                vec4 front2 = rotationMatrix * front1;
                front2 = front2.normalize();
                this.camera.Target = this.camera.Position + new vec3(front2);

                this.lastPosition = e.Location;
            }
        }

        void IMouseHandler.canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == this.BindingMouseButtons)
            {
                this.mouseDownFlag = false;
            }
        }

        void IKeyboardHandler.canvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == frontKey || e.KeyChar == upcaseFrontKey)
            {
                vec3 right = this.camera.GetRight();
                vec3 standardFront = this.camera.UpVector.cross(right).normalize();
                this.camera.Position += standardFront * this.StepLength;
                this.camera.Target += standardFront * this.StepLength;
            }
            else if (e.KeyChar == backKey || e.KeyChar == upcaseBackKey)
            {
                vec3 right = this.camera.GetRight();
                vec3 standardBack = right.cross(this.camera.UpVector).normalize();
                this.camera.Position += standardBack * this.StepLength;
                this.camera.Target += standardBack * this.StepLength;
            }
            else if (e.KeyChar == leftKey || e.KeyChar == upcaseLeftKey)
            {
                vec3 right = this.camera.GetRight();
                vec3 left = (-right).normalize();
                this.camera.Position += left * this.StepLength;
                this.camera.Target += left * this.StepLength;
            }
            else if (e.KeyChar == rightKey || e.KeyChar == upcaseRightKey)
            {
                vec3 right = this.camera.GetRight().normalize();
                this.camera.Position += right * this.StepLength;
                this.camera.Target += right * this.StepLength;
            }
            else if (e.KeyChar == upKey || e.KeyChar == upcaseUpKey)
            {
                vec3 up = this.camera.UpVector.normalize();
                this.camera.Position += up * this.StepLength;
                this.camera.Target += up * this.StepLength;
            }
            else if (e.KeyChar == downKey || e.KeyChar == upcaseDownKey)
            {
                vec3 down = -this.camera.UpVector.normalize();
                this.camera.Position += down * this.StepLength;
                this.camera.Target += down * this.StepLength;
            }
        }
    }
}
