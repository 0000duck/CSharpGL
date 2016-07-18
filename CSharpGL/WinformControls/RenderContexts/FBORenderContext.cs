﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A render context.
    /// </summary>
    public class FBORenderContext : HiddenWindowRenderContext
    {
        //static List<WeakReference<FBORenderContext>> renderContextList = new List<WeakReference<FBORenderContext>>();
        //public FBORenderContext()
        //{
        //    renderContextList.Add(new WeakReference<FBORenderContext>(this));
        //}

        //public override void Destroy()
        //{
        //    bool found = false;
        //    WeakReference<FBORenderContext> target = null;
        //    for (int index = 0; index < renderContextList.Count; index++)
        //    {
        //        target = renderContextList[index];
        //        FBORenderContext context;
        //        if (target.TryGetTarget(out context))
        //        {
        //            if (context == this)
        //            { break; }
        //        }
        //    }
        //    if (found)
        //    {
        //        renderContextList.Remove(target);
        //    }

        //    base.Destroy();
        //}
        //public static FBORenderContext GetCurrentRenderContext()
        //{
        //    IntPtr renderContext = Win32.wglGetCurrentContext();

        //}

        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitDepth"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool Create(GLVersion openGLVersion, int width, int height, int bitDepth, object parameter)
        {
            //  Call the base class.
            base.Create(openGLVersion, width, height, bitDepth, parameter);

            var framebuffer = new DefaultFramebuffer();
            framebuffer.Create(width, height);
            this.framebuffer = framebuffer;

            //  Create the DIB section.
            dibSection.Create(this.DeviceContextHandle, width, height, bitDepth);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            //  Delete the render buffers.
            this.framebuffer.Dispose();

            //  Destroy the internal dc.
            Win32.DeleteDC(this.dibSection.DibSectionDeviceContext);

            //	Call the base, which will delete the render context handle and window.
            base.DisposeUnmanagedResources();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public override void SetDimensions(int width, int height)
        {
            //  Call the base.
            base.SetDimensions(width, height);

            //	Resize dib section.
            this.dibSection.Resize(width, height, this.BitDepth);

            //  TODO: We should be able to just use the code below - however we
            //  get invalid dimension issues at the moment, so recreate for now.

            /*
            //  Resize the render buffer storage.
            GL.GetDelegateFor<GL.glBindRenderbufferEXT(GL.GL_RENDERBUFFER, colourRenderBufferId);
            GL.GetDelegateFor<GL.glRenderbufferStorageEXT(GL.GL_RENDERBUFFER, GL.GL_RGBA, width, height);
            GL.GetDelegateFor<GL.glBindRenderbufferEXT(GL.GL_RENDERBUFFER, depthRenderBufferId);
            GL.GetDelegateFor<GL.glRenderbufferStorageEXT(GL.GL_RENDERBUFFER, GL.GL_DEPTH_ATTACHMENT, width, height);
            var complete = GL.CheckFramebufferStatusEXT(GL.GL_FRAMEBUFFER_EXT);
            */
            this.framebuffer.Dispose();
            var framebuffer = new DefaultFramebuffer();
            framebuffer.Create(width, height);
            this.framebuffer = framebuffer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        public override void Blit(IntPtr hdc)
        {
            if (this.DeviceContextHandle != IntPtr.Zero)
            {
                //  Set the read buffer.
                OpenGL.ReadBuffer(OpenGL.GL_COLOR_ATTACHMENT0);

                //	Read the pixels into the DIB section.
                OpenGL.ReadPixels(0, 0, this.Width, this.Height, OpenGL.GL_BGRA,
                    OpenGL.GL_UNSIGNED_BYTE, this.dibSection.Bits);

                //	Blit the DC (containing the DIB section) to the target DC.
                Win32.BitBlt(hdc, 0, 0, this.Width, this.Height,
                    this.dibSection.DibSectionDeviceContext, 0, 0, Win32.SRCCOPY);
            }
        }

        private DefaultFramebuffer framebuffer;

        ///// <summary>
        ///// 
        ///// </summary>
        //private IntPtr dibSectionDeviceContext = IntPtr.Zero;
        /// <summary>
        /// 
        /// </summary>
        private DIBSection dibSection = new DIBSection();

        ///// <summary>
        ///// Gets the internal DIB section.
        ///// </summary>
        ///// <value>The internal DIB section.</value>
        //public DIBSection InternalDIBSection
        //{
        //    get { return dibSection; }
        //}
    }
}
