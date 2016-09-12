﻿using System;

namespace CSharpGL
{
    /// <summary>
    /// A query object.
    /// <para>Occlusion Querys enable you to determine if a representative set of geometry will be visible after depth testing.</para>
    /// </summary>
    public partial class Query : IDisposable
    {
        private static OpenGL.glGenQueries glGenQueries;
        private static OpenGL.glDeleteQueries glDeleteQueries;
        private static OpenGL.glIsQuery glIsQuery;
        private static OpenGL.glBeginQuery glBeginQuery;
        private static OpenGL.glEndQuery glEndQuery;
        private static OpenGL.glGetQueryiv glGetQueryiv;
        private static OpenGL.glGetQueryObjectiv glGetQueryObjectiv;
        private static OpenGL.glGetQueryObjectuiv glGetQueryObjectuiv;

        /// <summary>
        /// texture's id/name.
        /// </summary>
        protected uint[] id = new uint[1];

        /// <summary>
        /// texture's id/name.
        /// 纹理名（用于标识一个纹理，由OpenGL指定），可在shader中用于指定uniform sampler2D纹理变量。
        /// </summary>
        public uint Id { get { return this.id[0]; } }

        ///// <summary>
        /////
        ///// </summary>
        //public bool UseMipmap { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public void Bind()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public void Unbind()
        {
        }

        private bool initialized = false;

        /// <summary>
        /// resources(bitmap etc.) can be disposed  after this initialization.
        /// </summary>
        public void Initialize()
        {
            if (!this.initialized)
            {
                if (glGenQueries == null)
                {
                    glGenQueries = OpenGL.GetDelegateFor<OpenGL.glGenQueries>();
                    glDeleteQueries = OpenGL.GetDelegateFor<OpenGL.glDeleteQueries>();
                    glIsQuery = OpenGL.GetDelegateFor<OpenGL.glIsQuery>();
                    glBeginQuery = OpenGL.GetDelegateFor<OpenGL.glBeginQuery>();
                    glEndQuery = OpenGL.GetDelegateFor<OpenGL.glEndQuery>();
                    glGetQueryiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryiv>();
                    glGetQueryObjectiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryObjectiv>();
                    glGetQueryObjectuiv = OpenGL.GetDelegateFor<OpenGL.glGetQueryObjectuiv>();
                }


                this.initialized = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Query, Id:{0}", this.Id);
        }
    }
}