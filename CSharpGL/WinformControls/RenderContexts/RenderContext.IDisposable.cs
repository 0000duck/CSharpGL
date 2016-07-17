﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class RenderContext
    {

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~RenderContext()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();
            }

            this.disposedValue = true;
        }

        protected virtual void DisposeUnmanagedResources()
        {
            // If we have a render context, destroy it.
            if (RenderContextHandle != IntPtr.Zero)
            {
                Win32.wglDeleteContext(RenderContextHandle);
                RenderContextHandle = IntPtr.Zero;
            }
        }

    }
}
