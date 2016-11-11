﻿using System.Runtime.InteropServices;
namespace CSharpGL
{
    public partial class Texture
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="bufferPtr"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture CreateBufferTexture(uint internalFormat, Buffer bufferPtr, bool autoDispose)
        {
            return bufferPtr.DumpBufferTexture(internalFormat, autoDispose);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="internalFormat"></param>
        /// <param name="elementCount"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static Texture CreateBufferTexture<T>(uint internalFormat, int elementCount, BufferUsage usage) where T : struct
        {
            TextureBufferPtr bufferPtr = TextureBufferPtr.Create(typeof(T), usage, elementCount);
            return bufferPtr.DumpBufferTexture(internalFormat, autoDispose: true);
        }
    }
}