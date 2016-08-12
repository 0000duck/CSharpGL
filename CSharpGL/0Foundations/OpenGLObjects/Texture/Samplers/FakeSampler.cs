﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// texture's settings.
    /// </summary>
    public class FakeSampler : SamplerBase
    {

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="wrapping"></param>
        public void SetWrapping(TextureWrapping wrapping)
        {
            this.wrapping = wrapping;
        }

        /// <summary>
        /// 组成纹理的图片数据和其要贴上去的形状的大小往往是不一样的。两种情况，纹理图片小，贴图区域大，需要放大纹理称为：magnification；或者反过来，缩小纹理显示出来，称为 minification.在做放大喝缩小的操作的时候的具体的策略如下
        /// </summary>
        public void SetTextureFilter(TextureFilter textureFilter)
        {
            this.textureFilter = textureFilter;
        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public FakeSampler(TextureWrapping wrapping, TextureFilter textureFiltering, MipmapFilter mipmapFiltering)
            : base(wrapping, textureFiltering, mipmapFiltering)
        {
        }

        /// <summary>
        /// texture's settings.
        /// </summary>
        /// <param name="target"></param>
        public override void Bind(uint unit, BindTextureTarget target)
        {
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_S, (int)this.Wrapping);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_WRAP_T, (int)this.Wrapping);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MIN_FILTER, (int)this.TextureFilter);
            OpenGL.TexParameteri((uint)target, OpenGL.GL_TEXTURE_MAG_FILTER, (int)this.TextureFilter);

            // TODO: mipmap filter not working yet.
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="unit"></param>
        ///// <param name="target"></param>
        //public override void Unbind(uint unit, BindTextureTarget target)
        //{
        //    // nothing to do.
        //}
    }
}
