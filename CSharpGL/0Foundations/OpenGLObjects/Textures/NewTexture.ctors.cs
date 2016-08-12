﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NewTexture
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="samplerBuilder"></param>
        public NewTexture(NewImageBuilder imageBuilder, NewSamplerBase samplerBuilder)
        {
            if (imageBuilder == null || samplerBuilder == null) { throw new ArgumentNullException(); }

            this.ImageBuilder = imageBuilder;
            this.SamplerBuilder = samplerBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="samplerBuilder"></param>
        public NewTexture(Bitmap bitmap, NewSamplerBase samplerBuilder)
            : this(new NewBitmapBuilder(bitmap), samplerBuilder)
        {
            this.Target = BindTextureTarget.Texture2D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBuilder"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewTexture(NewImageBuilder imageBuilder,
            TextureWrapping wrapping = TextureWrapping.ClampToEdge,
            TextureFilter textureFiltering = TextureFilter.Linear,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(imageBuilder, new NewFakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        public NewTexture(Bitmap bitmap,
            TextureWrapping wrapping = TextureWrapping.ClampToEdge,
            TextureFilter textureFiltering = TextureFilter.Linear,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
            : this(new NewBitmapBuilder(bitmap), new NewFakeSampler(wrapping, textureFiltering, mipmapFiltering))
        {
            this.Target = BindTextureTarget.Texture2D;
        }
    }
}
