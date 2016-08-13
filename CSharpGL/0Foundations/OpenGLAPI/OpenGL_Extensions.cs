﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class OpenGL
    {

        #region OpenGL 1.2

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        ///// <param name="alpha"></param>
        //public delegate void glBlendColor(float red, float green, float blue, float alpha);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        //public delegate void glBlendEquation(uint mode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        public delegate void glDrawRangeElements(uint mode, uint start, uint end, int count, uint type, IntPtr indices);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="zoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glCopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glColorTable(uint target, uint internalformat, int width, uint format, uint type, IntPtr table);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyColorTable(uint target, uint internalformat, int x, int y, int width);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glGetColorTable(uint target, uint format, uint type, IntPtr table);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="start"></param>
        ///// <param name="count"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="data"></param>
        //public delegate void glColorSubTable(uint target, int start, int count, uint format, uint type, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="start"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyColorSubTable(uint target, int start, int x, int y, int width);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter1D(uint target, uint internalformat, int width, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterf(uint target, uint pname, float parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameteri(uint target, uint pname, int parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyConvolutionFilter1D(uint target, uint internalformat, int x, int y, int width);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glCopyConvolutionFilter2D(uint target, uint internalformat, int x, int y, int width, int height);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glGetConvolutionFilter(uint target, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="span"></param>
        //public delegate void glGetSeparableFilter(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        //public delegate void glSeparableFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetHistogram(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetMinmax(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="width"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glHistogram(uint target, int width, uint internalformat, bool sink);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glMinmax(uint target, uint internalformat, bool sink);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetHistogram(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetMinmax(uint target);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_3D = 0x806A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_SKIP_IMAGES = 0x806B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_IMAGE_HEIGHT = 0x806C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_SKIP_IMAGES = 0x806D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_IMAGE_HEIGHT = 0x806E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_3D = 0x806F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_3D = 0x8070;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_DEPTH = 0x8071;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_WRAP_R = 0x8072;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_3D_TEXTURE_SIZE = 0x8073;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BGR = 0x80E0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BGRA = 0x80E1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ELEMENTS_VERTICES = 0x80E8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ELEMENTS_INDICES = 0x80E9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLAMP_TO_EDGE = 0x812F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MIN_LOD = 0x813A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MAX_LOD = 0x813B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BASE_LEVEL = 0x813C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MAX_LEVEL = 0x813D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;

        #endregion

        #region OpenGL 1.3

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        public delegate void glActiveTexture(uint texture);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="invert"></param>
        //public delegate void glSampleCoverage(float value, bool invert);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="img"></param>
        //public delegate void glGetCompressedTexImage(uint target, int level, IntPtr img);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="texture"></param>
        //public delegate void glClientActiveTexture(uint texture);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1d(uint target, double s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1dv(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1f(uint target, float s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1fv(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1i(uint target, int s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1iv(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1s(uint target, short s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1sv(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2d(uint target, double s, double t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2dv(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2f(uint target, float s, float t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2fv(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2i(uint target, int s, int t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2iv(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2s(uint target, short s, short t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2sv(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3d(uint target, double s, double t, double r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3dv(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3f(uint target, float s, float t, float r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3fv(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3i(uint target, int s, int t, int r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3iv(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3s(uint target, short s, short t, short r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3sv(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4d(uint target, double s, double t, double r, double q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4dv(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4f(uint target, float s, float t, float r, float q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4fv(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4i(uint target, int s, int t, int r, int q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4iv(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4s(uint target, short s, short t, short r, short q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4sv(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixf(float[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixd(double[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixf(float[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixd(double[] m);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE0 = 0x84C0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE1 = 0x84C1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE2 = 0x84C2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE3 = 0x84C3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE4 = 0x84C4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE5 = 0x84C5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE6 = 0x84C6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE7 = 0x84C7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE8 = 0x84C8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE9 = 0x84C9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE10 = 0x84CA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE11 = 0x84CB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE12 = 0x84CC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE13 = 0x84CD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE14 = 0x84CE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE15 = 0x84CF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE16 = 0x84D0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE17 = 0x84D1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE18 = 0x84D2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE19 = 0x84D3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE20 = 0x84D4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE21 = 0x84D5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE22 = 0x84D6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE23 = 0x84D7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE24 = 0x84D8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE25 = 0x84D9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE26 = 0x84DA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE27 = 0x84DB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE28 = 0x84DC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE29 = 0x84DD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE30 = 0x84DE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE31 = 0x84DF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACTIVE_TEXTURE = 0x84E0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MULTISAMPLE = 0x809D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE = 0x80A0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_BUFFERS = 0x80A8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLES = 0x80A9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP = 0x8513;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPRESSED_RGB = 0x84ED;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPRESSED_RGBA = 0x84EE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED = 0x86A1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLAMP_TO_BORDER = 0x812D;

        #endregion

        #region OpenGL 1.4

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sfactorRGB"></param>
        ///// <param name="dfactorRGB"></param>
        ///// <param name="sfactorAlpha"></param>
        ///// <param name="dfactorAlpha"></param>
        //public delegate void glBlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="primcount"></param>
        public delegate void glMultiDrawArrays(uint mode, int[] first, int[] count, int primcount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="primcount"></param>
        public delegate void glMultiDrawElements(uint mode, int[] count, uint type, IntPtr indices, int primcount);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameter"></param>
        //public delegate void glPointParameterf(uint pname, float parameter);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glPointParameterfv(uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameter"></param>
        //public delegate void glPointParameteri(uint pname, int parameter);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glPointParameteriv(uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordf(float coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordfv(float[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordd(double coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoorddv(double[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glFogCoordPointer(uint type, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3b(sbyte red, sbyte green, sbyte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3bv(sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3d(double red, double green, double blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3f(float red, float green, float blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3i(int red, int green, int blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3s(short red, short green, short blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3sv(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3ub(byte red, byte green, byte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3ubv(byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3ui(uint red, uint green, uint blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3uiv(uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3us(ushort red, ushort green, ushort blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3usv(ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glSecondaryColorPointer(int size, uint type, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2d(double x, double y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2f(float x, float y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2i(int x, int y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2s(short x, short y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2sv(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3d(double x, double y, double z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3f(float x, float y, float z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3i(int x, int y, int z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3s(short x, short y, short z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3sv(short[] v);

        //  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_DST_RGB = 0x80C8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_SRC_RGB = 0x80C9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_DST_ALPHA = 0x80CA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_SRC_ALPHA = 0x80CB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT16 = 0x81A5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_COMPONENT24 = 0x81A6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT32 = 0x81A7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MIRRORED_REPEAT = 0x8370;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_LOD_BIAS = 0x8501;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INCR_WRAP = 0x8507;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DECR_WRAP = 0x8508;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_DEPTH_SIZE = 0x884A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_MODE = 0x884C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_FUNC = 0x884D;

        #endregion

        #region OpenGL 1.5

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //public delegate void glGenQueries(int n, uint[] ids);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //public delegate void glDeleteQueries(int n, uint[] ids);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public delegate bool glIsQuery(uint id);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="id"></param>
        //public delegate void glBeginQuery(uint target, uint id);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glEndQuery(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryObjectiv(uint id, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryObjectuiv(uint id, uint pname, uint[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="buffer"></param>
        public delegate void glBindBuffer(uint target, uint buffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buffers"></param>
        public delegate void glDeleteBuffers(int n, uint[] buffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buffers"></param>
        public delegate void glGenBuffers(int n, uint[] buffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public delegate bool glIsBuffer(uint buffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        public delegate void glBufferData(uint target, int size, IntPtr data, uint usage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public delegate void glBufferSubData(uint target, int offset, int size, IntPtr data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public delegate void glGetBufferSubData(uint target, int offset, int size, IntPtr data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public delegate IntPtr glMapBuffer(uint target, uint access);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public delegate IntPtr glMapBufferRange(uint target, int offset, int length, uint access);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public delegate bool glUnmapBuffer(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferPointerv(uint target, uint pname, IntPtr[] parameters);

        //  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_SIZE = 0x8764;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_USAGE = 0x8765;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_COUNTER_BITS = 0x8864;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_QUERY = 0x8865;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_RESULT = 0x8866;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_RESULT_AVAILABLE = 0x8867;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ARRAY_BUFFER = 0x8892;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ELEMENT_ARRAY_BUFFER = 0x8893;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ARRAY_BUFFER_BINDING = 0x8894;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_READ_ONLY = 0x88B8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_WRITE_ONLY = 0x88B9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_READ_WRITE = 0x88BA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BUFFER_ACCESS = 0x88BB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_MAPPED = 0x88BC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_MAP_POINTER = 0x88BD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STREAM_DRAW = 0x88E0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STREAM_READ = 0x88E1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STREAM_COPY = 0x88E2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STATIC_DRAW = 0x88E4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STATIC_READ = 0x88E5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STATIC_COPY = 0x88E6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DYNAMIC_DRAW = 0x88E8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DYNAMIC_READ = 0x88E9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DYNAMIC_COPY = 0x88EA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLES_PASSED = 0x8914;

        #endregion

        #region OpenGL 2.0

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modeRGB"></param>
        ///// <param name="modeAlpha"></param>
        //public delegate void glBlendEquationSeparate(uint modeRGB, uint modeAlpha);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="bufs"></param>
        public delegate void glDrawBuffers(int n, uint[] bufs);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="sfail"></param>
        ///// <param name="dpfail"></param>
        ///// <param name="dppass"></param>
        //public delegate void glStencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="func"></param>
        ///// <param name="reference"></param>
        ///// <param name="mask"></param>
        //public delegate void glStencilFuncSeparate(uint face, uint func, int reference, uint mask);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="mask"></param>
        //public delegate void glStencilMaskSeparate(uint face, uint mask);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="shader"></param>
        public delegate void glAttachShader(uint program, uint shader);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public delegate void glBindAttribLocation(uint program, uint index, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        public delegate void glCompileShader(uint shader);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public delegate uint glCreateProgram();
        /// <summary>
        /// create a shader object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public delegate uint glCreateShader(uint type);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public delegate void glDeleteProgram(uint program);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        public delegate void glDeleteShader(uint shader);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="shader"></param>
        public delegate void glDetachShader(uint program, uint shader);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public delegate void glDisableVertexAttribArray(uint index);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public delegate void glEnableVertexAttribArray(uint index);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out uint type, StringBuilder name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out uint type, StringBuilder name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="maxCount"></param>
        ///// <param name="count"></param>
        ///// <param name="obj"></param>
        //public delegate void glGetAttachedShaders(uint program, int maxCount, int[] count, uint[] obj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public delegate int glGetAttribLocation(uint program, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetProgramiv(uint program, uint pname, int[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="infoLog"></param>
        public delegate void glGetProgramInfoLog(uint program, int bufSize, IntPtr length, StringBuilder infoLog);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetShaderiv(uint shader, uint pname, int[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="infoLog"></param>
        public delegate void glGetShaderInfoLog(uint shader, int bufSize, IntPtr length, StringBuilder infoLog);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="source"></param>
        public delegate void glGetShaderSource(uint shader, int bufSize, IntPtr length, StringBuilder source);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public delegate int glGetUniformLocation(uint program, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="location"></param>
        /// <param name="parameters"></param>
        public delegate void glGetUniformfv(uint program, int location, float[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="location"></param>
        /// <param name="parameters"></param>
        public delegate void glGetUniformiv(uint program, int location, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribdv(uint index, uint pname, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribfv(uint index, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribiv(uint index, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="pointer"></param>
        //public delegate void glGetVertexAttribPointerv(uint index, uint pname, IntPtr pointer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public delegate bool glIsProgram(uint program);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <returns></returns>
        public delegate bool glIsShader(uint shader);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public delegate void glLinkProgram(uint program);
        //  By specifying 'ThrowOnUnmappableChar' we protect ourselves from inadvertantly using a unicode character
        //  in the source which the marshaller cannot map. Without this, it maps it to '?' leading to long and pointless
        //  sessions of trying to find bugs in the shader, which are most often just copied and pasted unicode characters!
        //  If you're getting exceptions here, remove all unicode crap from your input files (remember, some unicode
        //  characters you can't even see).
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="count"></param>
        /// <param name="source"></param>
        /// <param name="length"></param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, ThrowOnUnmappableChar = true)]
        public delegate void glShaderSource(uint shader, int count, string[] source, int[] length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public delegate void glUseProgram(uint program);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        public delegate void glUniform1f(int location, float v0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public delegate void glUniform2f(int location, float v0, float v1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public delegate void glUniform3f(int location, float v0, float v1, float v2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        public delegate void glUniform1i(int location, int v0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public delegate void glUniform2i(int location, int v0, int v1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public delegate void glUniform3i(int location, int v0, int v1, int v2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public delegate void glUniform4i(int location, int v0, int v1, int v2, int v3);
        // TODO: public delegate void glUniform1fv(int location, int count, IntPtr value); is also available.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform1fv(int location, int count, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform2fv(int location, int count, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform3fv(int location, int count, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform4fv(int location, int count, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform1iv(int location, int count, int[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform2iv(int location, int count, int[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform3iv(int location, int count, int[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform4iv(int location, int count, int[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        public delegate void glUniformMatrix2fv(int location, int count, bool transpose, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        public delegate void glUniformMatrix3fv(int location, int count, bool transpose, float[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        public delegate void glUniformMatrix4fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        //public delegate void glValidateProgram(uint program);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1d(uint index, double x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1dv(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1f(uint index, float x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1fv(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1s(uint index, short x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1sv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2d(uint index, double x, double y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2dv(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2f(uint index, float x, float y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2fv(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2s(uint index, short x, short y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2sv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3d(uint index, double x, double y, double z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3dv(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3f(uint index, float x, float y, float z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3fv(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3s(uint index, short x, short y, short z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3sv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nbv(uint index, sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Niv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nsv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nubv(uint index, byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nuiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nusv(uint index, ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4bv(uint index, sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4d(uint index, double x, double y, double z, double w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4dv(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4f(uint index, float x, float y, float z, float w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4fv(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4iv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4s(uint index, short x, short y, short z, short w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4sv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4ubv(uint index, byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4uiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4usv(uint index, ushort[] v);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="normalized"></param>
        /// <param name="stride"></param>
        /// <param name="pointer"></param>
        public delegate void glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);

        //  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_EQUATION_RGB = 0x8009;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_FUNC = 0x8800;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_FAIL = 0x8801;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_DRAW_BUFFERS = 0x8824;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER0 = 0x8825;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER1 = 0x8826;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER2 = 0x8827;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER3 = 0x8828;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER4 = 0x8829;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER5 = 0x882A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER6 = 0x882B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER7 = 0x882C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER8 = 0x882D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER9 = 0x882E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER10 = 0x882F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER11 = 0x8830;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER12 = 0x8831;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER13 = 0x8832;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER14 = 0x8833;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER15 = 0x8834;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_EQUATION_ALPHA = 0x883D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_ATTRIBS = 0x8869;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAGMENT_SHADER = 0x8B30;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_SHADER = 0x8B31;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TESS_CONTROL_SHADER = 0x8E88;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TESS_EVALUATION_SHADER = 0x8E87;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VARYING_FLOATS = 0x8B4B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_TYPE = 0x8B4F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC2 = 0x8B50;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC3 = 0x8B51;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC4 = 0x8B52;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC2 = 0x8B53;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC3 = 0x8B54;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC4 = 0x8B55;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL = 0x8B56;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC2 = 0x8B57;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC3 = 0x8B58;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC4 = 0x8B59;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT2 = 0x8B5A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT3 = 0x8B5B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT4 = 0x8B5C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_1D = 0x8B5D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D = 0x8B5E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_3D = 0x8B5F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_CUBE = 0x8B60;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_1D_SHADOW = 0x8B61;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D_SHADOW = 0x8B62;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DELETE_STATUS = 0x8B80;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPILE_STATUS = 0x8B81;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINK_STATUS = 0x8B82;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VALIDATE_STATUS = 0x8B83;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INFO_LOG_LENGTH = 0x8B84;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ATTACHED_SHADERS = 0x8B85;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_UNIFORMS = 0x8B86;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_SOURCE_LENGTH = 0x8B88;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_ATTRIBUTES = 0x8B89;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_PROGRAM = 0x8B8D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LOWER_LEFT = 0x8CA1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_UPPER_LEFT = 0x8CA2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_REF = 0x8CA3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;

        #endregion

        #region OpenGL 2.1

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix2x3fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix3x2fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix2x4fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix4x2fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix3x4fv(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix4x3fv(int location, int count, bool transpose, float[] value);

        //  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_PACK_BUFFER = 0x88EB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_UNPACK_BUFFER = 0x88EC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT2x3 = 0x8B65;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT2x4 = 0x8B66;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT3x2 = 0x8B67;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT3x4 = 0x8B68;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT4x2 = 0x8B69;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT4x3 = 0x8B6A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB = 0x8C40;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB8 = 0x8C41;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB_ALPHA = 0x8C42;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB8_ALPHA8 = 0x8C43;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB = 0x8C48;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_ALPHA = 0x8C49;

        #endregion

        #region OpenGL 3.0

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="r"></param>
        ///// <param name="g"></param>
        ///// <param name="b"></param>
        ///// <param name="a"></param>
        //public delegate void glColorMaski(uint index, bool r, bool g, bool b, bool a);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetBooleani_v(uint target, uint index, bool[] data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetIntegeri_v(uint target, uint index, int[] data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glEnablei(uint target, uint index);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glDisablei(uint target, uint index);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate bool glIsEnabledi(uint target, uint index);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primitiveMode"></param>
        public delegate void glBeginTransformFeedback(uint primitiveMode);
        ///// <summary>
        ///// 
        ///// </summary>
        //public delegate void glEndTransformFeedback();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public delegate void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        /// <param name="buffer"></param>
        public delegate void glBindBufferBase(uint target, uint index, uint buffer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="count"></param>
        ///// <param name="varyings"></param>
        ///// <param name="bufferMode"></param>
        //public delegate void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="clamp"></param>
        //public delegate void glClampColor(uint target, uint clamp);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="mode"></param>
        //public delegate void glBeginConditionalRender(uint id, uint mode);
        ///// <summary>
        ///// 
        ///// </summary>
        //public delegate void glEndConditionalRender();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glVertexAttribIPointer(uint index, int size, uint type, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIiv(uint index, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIuiv(uint index, uint pname, uint[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1i(uint index, int x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2i(uint index, int x, int y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3i(uint index, int x, int y, int z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4i(uint index, int x, int y, int z, int w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1ui(uint index, uint x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2ui(uint index, uint x, uint y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3ui(uint index, uint x, uint y, uint z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1iv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2iv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3iv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4iv(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1uiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2uiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3uiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4uiv(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4bv(uint index, sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4sv(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4ubv(uint index, byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4usv(uint index, ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="location"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetUniformuiv(uint program, int location, uint[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="color"></param>
        ///// <param name="name"></param>
        //public delegate void glBindFragDataLocation(uint program, uint color, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public delegate int glGetFragDataLocation(uint program, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        public delegate void glUniform1ui(int location, uint v0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public delegate void glUniform2ui(int location, uint v0, uint v1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public delegate void glUniform3ui(int location, uint v0, uint v1, uint v2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public delegate void glUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform1uiv(int location, int count, uint[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform2uiv(int location, int count, uint[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform3uiv(int location, int count, uint[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        public delegate void glUniform4uiv(int location, int count, uint[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIuiv(uint target, uint pname, uint[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIuiv(uint target, uint pname, uint[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferiv(uint buffer, int drawbuffer, int[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferuiv(uint buffer, int drawbuffer, uint[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferfv(uint buffer, int drawbuffer, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="depth"></param>
        ///// <param name="stencil"></param>
        //public delegate void glClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate string glGetStringi(uint name, uint index);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPARE_REF_TO_TEXTURE = 0x884E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE0 = 0x3000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE1 = 0x3001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE2 = 0x3002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE3 = 0x3003;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE4 = 0x3004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE5 = 0x3005;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE6 = 0x3006;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_DISTANCE7 = 0x3007;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_CLIP_DISTANCES = 0x0D32;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAJOR_VERSION = 0x821B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MINOR_VERSION = 0x821C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NUM_EXTENSIONS = 0x821D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_FLAGS = 0x821E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_BUFFER = 0x8223;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_BUFFER = 0x8224;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPRESSED_RED = 0x8225;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPRESSED_RG = 0x8226;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = 0x0001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA32F = 0x8814;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB32F = 0x8815;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA16F = 0x881A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB16F = 0x881B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLAMP_READ_COLOR = 0x891C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FIXED_ONLY = 0x891D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_VARYING_COMPONENTS = 0x8B4B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_1D_ARRAY = 0x8C18;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_2D_ARRAY = 0x8C1A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R11F_G11F_B10F = 0x8C3A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB9_E5 = 0x8C3D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_SHARED_SIZE = 0x8C3F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PRIMITIVES_GENERATED = 0x8C87;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RASTERIZER_DISCARD = 0x8C89;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTERLEAVED_ATTRIBS = 0x8C8C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SEPARATE_ATTRIBS = 0x8C8D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA32UI = 0x8D70;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB32UI = 0x8D71;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA16UI = 0x8D76;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB16UI = 0x8D77;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA8UI = 0x8D7C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB8UI = 0x8D7D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA32I = 0x8D82;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB32I = 0x8D83;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA16I = 0x8D88;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB16I = 0x8D89;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA8I = 0x8D8E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB8I = 0x8D8F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED_INTEGER = 0x8D94;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREEN_INTEGER = 0x8D95;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLUE_INTEGER = 0x8D96;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB_INTEGER = 0x8D98;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA_INTEGER = 0x8D99;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BGR_INTEGER = 0x8D9A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BGRA_INTEGER = 0x8D9B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_1D_ARRAY = 0x8DC0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_2D_ARRAY = 0x8DC1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_CUBE_SHADOW = 0x8DC5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC2 = 0x8DC6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC3 = 0x8DC7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_VEC4 = 0x8DC8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_1D = 0x8DC9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_2D = 0x8DCA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_3D = 0x8DCB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_CUBE = 0x8DCC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_1D_ARRAY = 0x8DCE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_2D_ARRAY = 0x8DCF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUERY_WAIT = 0x8E13;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUERY_NO_WAIT = 0x8E14;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUERY_BY_REGION_WAIT = 0x8E15;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUERY_BY_REGION_NO_WAIT = 0x8E16;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BUFFER_ACCESS_FLAGS = 0x911F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BUFFER_MAP_LENGTH = 0x9120;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BUFFER_MAP_OFFSET = 0x9121;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R8 = 0x8229;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R16 = 0x822A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG8 = 0x822B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG16 = 0x822C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R16F = 0x822D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R32F = 0x822E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG16F = 0x822F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG32F = 0x8230;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R8I = 0x8231;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R8UI = 0x8232;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R16I = 0x8233;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R16UI = 0x8234;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R32I = 0x8235;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R32UI = 0x8236;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG8I = 0x8237;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG8UI = 0x8238;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG16I = 0x8239;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG16UI = 0x823A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG32I = 0x823B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG32UI = 0x823C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG = 0x8227;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG_INTEGER = 0x8228;

        #endregion

        #region OpenGL 3.1

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="primcount"></param>
        public delegate void glDrawArraysInstanced(uint mode, int first, int count, int primcount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="primcount"></param>
        public delegate void glDrawElementsInstanced(uint mode, int count, uint type, IntPtr indices, int primcount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        public delegate void glDrawElementsBaseVertex(uint mode, int count, uint type, IntPtr indices, int baseVertex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalformat"></param>
        /// <param name="buffer"></param>
        public delegate void glTexBuffer(uint target, uint internalformat, uint buffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public delegate void glPrimitiveRestartIndex(uint index);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_2D_RECT = 0x8B63;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_2D_RECT_SHADOW = 0x8B64;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SAMPLER_BUFFER = 0x8DC2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_2D_RECT = 0x8DCD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT_SAMPLER_BUFFER = 0x8DD0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BUFFER = 0x8C2A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_BUFFER = 0x8C2C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BUFFER_FORMAT = 0x8C2E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_RECTANGLE = 0x84F5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_RECTANGLE = 0x84F6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_RECTANGLE = 0x84F7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED_SNORM = 0x8F90;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG_SNORM = 0x8F91;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB_SNORM = 0x8F92;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA_SNORM = 0x8F93;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R8_SNORM = 0x8F94;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG8_SNORM = 0x8F95;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB8_SNORM = 0x8F96;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA8_SNORM = 0x8F97;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R16_SNORM = 0x8F98;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RG16_SNORM = 0x8F99;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB16_SNORM = 0x8F9A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA16_SNORM = 0x8F9B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SIGNED_NORMALIZED = 0x8F9C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PRIMITIVE_RESTART = 0x8F9D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PRIMITIVE_RESTART_INDEX = 0x8F9E;

        #endregion

        #region OpenGL 3.2

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public delegate void glGetInteger64i_v(uint target, uint index, Int64[] data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetBufferParameteri64v(uint target, uint pname, Int64[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="texture"></param>
        /// <param name="level"></param>
        public delegate void glFramebufferTexture(uint target, uint attachment, uint texture, int level);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_CORE_PROFILE_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_COMPATIBILITY_PROFILE_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINES_ADJACENCY = 0x000A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_STRIP_ADJACENCY = 0x000B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRIANGLES_ADJACENCY = 0x000C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PATCHES = 0xE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROGRAM_POINT_SIZE = 0x8642;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_SHADER = 0x8DD9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_VERTICES_OUT = 0x8916;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_INPUT_TYPE = 0x8917;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEOMETRY_OUTPUT_TYPE = 0x8918;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONTEXT_PROFILE_MASK = 0x9126;

        #endregion

        #region OpenGL 3.3

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="divisor"></param>
        //public delegate void glVertexAttribDivisor(uint index, uint divisor);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;

        #endregion

        #region OpenGL 4.0

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        //public delegate void glMinSampleShading(float value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buf"></param>
        ///// <param name="mode"></param>
        //public delegate void glBlendEquationi(uint buf, uint mode);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buf"></param>
        ///// <param name="modeRGB"></param>
        ///// <param name="modeAlpha"></param>
        //public delegate void glBlendEquationSeparatei(uint buf, uint modeRGB, uint modeAlpha);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buf"></param>
        ///// <param name="src"></param>
        ///// <param name="dst"></param>
        //public delegate void glBlendFunci(uint buf, uint src, uint dst);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buf"></param>
        ///// <param name="srcRGB"></param>
        ///// <param name="dstRGB"></param>
        ///// <param name="srcAlpha"></param>
        ///// <param name="dstAlpha"></param>
        //public delegate void glBlendFuncSeparatei(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_SHADING = 0x8C36;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MIN_SAMPLE_SHADING_VALUE = 0x8C37;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARRAY = 0x900A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_CUBE_MAP_ARRAY = 0x900C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW = 0x900D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900F;

        #endregion

        #region GL_EXT_texture3D

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="border"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="pixels"></param>
        //public delegate void glTexImage3DEXT(uint target, int level, uint internalformat, uint width,
        //    uint height, uint depth, int border, uint format, uint type, IntPtr pixels);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="pixels"></param>
        //public delegate void glTexSubImage3DEXT(uint target, int level, int xoffset, int yoffset, int zoffset,
        //    uint width, uint height, uint depth, uint format, uint type, IntPtr pixels);

        #endregion

        #region GL_EXT_rescale_normal

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RESCALE_NORMAL = 0x803A;

        #endregion

        #region GL_EXT_separate_specular_color

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LIGHT_MODEL_COLOR_CONTROL = 0x81F8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SINGLE_COLOR = 0x81F9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SEPARATE_SPECULAR_COLOR = 0x81FA;

        #endregion

        #region GL_SGIS_texture_edge_clamp

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CLAMP_TO_EDGE_SGIS = 0x812F;

        #endregion

        #region GL_SGIS_texture_lod

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_MIN_LOD_SGIS = 0x813A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_MAX_LOD_SGIS = 0x813B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D;

        #endregion

        #region GL_EXT_draw_range_elements

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="start"></param>
        ///// <param name="end"></param>
        ///// <param name="count"></param>
        ///// <param name="type"></param>
        ///// <param name="indices"></param>
        //public delegate void glDrawRangeElementsEXT(uint mode, uint start, uint end, uint count, uint type, IntPtr indices);


        #endregion

        #region GL_SGI_color_table

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glColorTableSGI(uint target, uint internalformat, uint width, uint format, uint type, IntPtr table);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameterfvSGI(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameterivSGI(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyColorTableSGI(uint target, uint internalformat, int x, int y, uint width);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glGetColorTableSGI(uint target, uint format, uint type, IntPtr table);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameterfvSGI(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameterivSGI(uint target, uint pname, int[] parameters);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_SGI = 0x80D0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROXY_COLOR_TABLE_SGI = 0x80D3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_SCALE_SGI = 0x80D6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_BIAS_SGI = 0x80D7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_FORMAT_SGI = 0x80D8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_WIDTH_SGI = 0x80D9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_RED_SIZE_SGI = 0x80DA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_GREEN_SIZE_SGI = 0x80DB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_BLUE_SIZE_SGI = 0x80DC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_ALPHA_SIZE_SGI = 0x80DD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_LUMINANCE_SIZE_SGI = 0x80DE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_TABLE_INTENSITY_SIZE_SGI = 0x80DF;

        #endregion

        #region GL_EXT_convolution

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter1DEXT(uint target, uint internalformat, int width, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter2DEXT(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterfEXT(uint target, uint pname, float parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterfvEXT(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameter"></param>
        //public delegate void glConvolutionParameteriEXT(uint target, uint pname, int parameter);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterivEXT(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyConvolutionFilter1DEXT(uint target, uint internalformat, int x, int y, int width);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glCopyConvolutionFilter2DEXT(uint target, uint internalformat, int x, int y, int width, int height);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glGetConvolutionFilterEXT(uint target, uint format, uint type, IntPtr image);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameterfvEXT(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameterivEXT(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="span"></param>
        //public delegate void glGetSeparableFilterEXT(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        //public delegate void glSeparableFilter2DEXT(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_1D = 0x8010;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_2D = 0x8011;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_SEPARABLE_2D = 0x8012;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_BORDER_MODE = 0x8013;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_FILTER_SCALE = 0x8014;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_FILTER_BIAS = 0x8015;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_REDUCE = 0x8016;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_FORMAT = 0x8017;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_WIDTH = 0x8018;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_CONVOLUTION_HEIGHT = 0x8019;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_MAX_CONVOLUTION_WIDTH = 0x801A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_MAX_CONVOLUTION_HEIGHT = 0x801B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_RED_SCALE = 0x801C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_GREEN_SCALE = 0x801D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_BLUE_SCALE = 0x801E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_ALPHA_SCALE = 0x801F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_RED_BIAS = 0x8020;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_GREEN_BIAS = 0x8021;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_BLUE_BIAS = 0x8022;
        ///// <summary>
        ///// 
        ///// </summary>
        //public static uint GL_POST_CONVOLUTION_ALPHA_BIAS = 0x8023;

        #endregion

        //#region GL_SGI_color_matrix

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_MATRIX_SGI = 0x80B1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_RED_SCALE_SGI = 0x80B4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_GREEN_SCALE_SGI = 0x80B5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_BLUE_SCALE_SGI = 0x80B6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_ALPHA_SCALE_SGI = 0x80B7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_RED_BIAS_SGI = 0x80B8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_GREEN_BIAS_SGI = 0x80B9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_BLUE_BIAS_SGI = 0x80BA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POST_COLOR_MATRIX_ALPHA_BIAS_SGI = 0x80BB;

        //#endregion

        //#region GL_EXT_histogram

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetHistogramEXT(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameterfvEXT(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameterivEXT(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetMinmaxEXT(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameterfvEXT(uint target, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameterivEXT(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="width"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glHistogramEXT(uint target, int width, uint internalformat, bool sink);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glMinmaxEXT(uint target, uint internalformat, bool sink);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetHistogramEXT(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetMinmaxEXT(uint target);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM = 0x8024;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROXY_HISTOGRAM = 0x8025;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_WIDTH = 0x8026;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_FORMAT = 0x8027;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_RED_SIZE = 0x8028;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_GREEN_SIZE = 0x8029;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_BLUE_SIZE = 0x802A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_ALPHA_SIZE = 0x802B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_LUMINANCE_SIZE = 0x802C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HISTOGRAM_SINK = 0x802D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MINMAX = 0x802E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MINMAX_FORMAT = 0x802F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MINMAX_SINK = 0x8030;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TABLE_TOO_LARGE = 0x8031;

        //#endregion

        //#region GL_EXT_blend_color

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        ///// <param name="alpha"></param>
        //public delegate void glBlendColorEXT(float red, float green, float blue, float alpha);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_COLOR = 0x8005;

        //#endregion

        //#region GL_EXT_blend_minmax

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        //public delegate void glBlendEquationEXT(uint mode);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FUNC_ADD = 0x8006;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MIN = 0x8007;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX = 0x8008;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FUNC_SUBTRACT = 0x800A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FUNC_REVERSE_SUBTRACT = 0x800B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_EQUATION = 0x8009;

        //#endregion

        //#region GL_ARB_multitexture

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="texture"></param>
        //public delegate void glActiveTextureARB(uint texture);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="texture"></param>
        //public delegate void glClientActiveTextureARB(uint texture);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1dARB(uint target, double s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1dvARB(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1fARB(uint target, float s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1fvARB(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1iARB(uint target, int s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1ivARB(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1sARB(uint target, short s);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1svARB(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2dARB(uint target, double s, double t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2dvARB(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2fARB(uint target, float s, float t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2fvARB(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2iARB(uint target, int s, int t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2ivARB(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2sARB(uint target, short s, short t);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2svARB(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3dARB(uint target, double s, double t, double r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3dvARB(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3fARB(uint target, float s, float t, float r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3fvARB(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3iARB(uint target, int s, int t, int r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3ivARB(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3sARB(uint target, short s, short t, short r);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3svARB(uint target, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4dARB(uint target, double s, double t, double r, double q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4dvARB(uint target, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4fARB(uint target, float s, float t, float r, float q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4fvARB(uint target, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4iARB(uint target, int s, int t, int r, int q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4ivARB(uint target, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4sARB(uint target, short s, short t, short r, short q);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4svARB(uint target, short[] v);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE0_ARB = 0x84C0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE1_ARB = 0x84C1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE2_ARB = 0x84C2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE3_ARB = 0x84C3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE4_ARB = 0x84C4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE5_ARB = 0x84C5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE6_ARB = 0x84C6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE7_ARB = 0x84C7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE8_ARB = 0x84C8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE9_ARB = 0x84C9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE10_ARB = 0x84CA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE11_ARB = 0x84CB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE12_ARB = 0x84CC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE13_ARB = 0x84CD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE14_ARB = 0x84CE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE15_ARB = 0x84CF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE16_ARB = 0x84D0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE17_ARB = 0x84D1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE18_ARB = 0x84D2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE19_ARB = 0x84D3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE20_ARB = 0x84D4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE21_ARB = 0x84D5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE22_ARB = 0x84D6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE23_ARB = 0x84D7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE24_ARB = 0x84D8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE25_ARB = 0x84D9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE26_ARB = 0x84DA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE27_ARB = 0x84DB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE28_ARB = 0x84DC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE29_ARB = 0x84DD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE30_ARB = 0x84DE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE31_ARB = 0x84DF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_TEXTURE_ARB = 0x84E0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CLIENT_ACTIVE_TEXTURE_ARB = 0x84E1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TEXTURE_UNITS_ARB = 0x84E2;

        //#endregion

        //#region GL_ARB_texture_compression

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage3DARB(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage2DARB(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage1DARB(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage3DARB(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage2DARB(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage1DARB(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="img"></param>
        //public delegate void glGetCompressedTexImageARB(uint target, int level, IntPtr img);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_ALPHA_ARB = 0x84E9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_LUMINANCE_ARB = 0x84EA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_LUMINANCE_ALPHA_ARB = 0x84EB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_INTENSITY_ARB = 0x84EC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGB_ARB = 0x84ED;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGBA_ARB = 0x84EE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSION_HINT_ARB = 0x84EF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = 0x86A0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSED_ARB = 0x86A1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A3;

        //#endregion

        //#region GL_EXT_texture_cube_map

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_NORMAL_MAP = 0x8511;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_REFLECTION_MAP = 0x8512;

        //#endregion

        //#region GL_ARB_multisample

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="invert"></param>
        //public delegate void glSampleCoverageARB(float value, bool invert);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MULTISAMPLE_ARB = 0x809D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_ALPHA_TO_COVERAGE_ARB = 0x809E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_ALPHA_TO_ONE_ARB = 0x809F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_COVERAGE_ARB = 0x80A0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_BUFFERS_ARB = 0x80A8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLES_ARB = 0x80A9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_COVERAGE_VALUE_ARB = 0x80AA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLE_COVERAGE_INVERT_ARB = 0x80AB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MULTISAMPLE_BIT_ARB = 0x20000000;

        //#endregion

        //#region GL_ARB_texture_env_add

        ////  Appears to not have any functionality

        //#endregion

        //#region GL_ARB_texture_env_combine

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMBINE_ARB = 0x8570;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMBINE_RGB_ARB = 0x8571;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMBINE_ALPHA_ARB = 0x8572;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE0_RGB_ARB = 0x8580;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE1_RGB_ARB = 0x8581;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE2_RGB_ARB = 0x8582;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE0_ALPHA_ARB = 0x8588;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE1_ALPHA_ARB = 0x8589;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SOURCE2_ALPHA_ARB = 0x858A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND0_RGB_ARB = 0x8590;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND1_RGB_ARB = 0x8591;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND2_RGB_ARB = 0x8592;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND0_ALPHA_ARB = 0x8598;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND1_ALPHA_ARB = 0x8599;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OPERAND2_ALPHA_ARB = 0x859A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGB_SCALE_ARB = 0x8573;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ADD_SIGNED_ARB = 0x8574;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERPOLATE_ARB = 0x8575;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SUBTRACT_ARB = 0x84E7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CONSTANT_ARB = 0x8576;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PRIMARY_COLOR_ARB = 0x8577;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PREVIOUS_ARB = 0x8578;

        //#endregion

        //#region GL_ARB_texture_env_dot3

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DOT3_RGB_ARB = 0x86AE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DOT3_RGBA_ARB = 0x86AF;

        //#endregion

        //#region GL_ARB_texture_border_clamp

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CLAMP_TO_BORDER_ARB = 0x812D;

        //#endregion

        //#region GL_ARB_transpose_matrix

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixfARB(float[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixdARB(double[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixfARB(float[] m);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixdARB(double[] m);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TRANSPOSE_MODELVIEW_MATRIX_ARB = 0x84E3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TRANSPOSE_PROJECTION_MATRIX_ARB = 0x84E4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TRANSPOSE_TEXTURE_MATRIX_ARB = 0x84E5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TRANSPOSE_COLOR_MATRIX_ARB = 0x84E6;

        //#endregion

        //#region GL_SGIS_generate_mipmap

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_GENERATE_MIPMAP_SGIS = 0x8191;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_GENERATE_MIPMAP_HINT_SGIS = 0x8192;

        //#endregion

        //#region GL_NV_blend_square

        ////  Appears to be empty.

        //#endregion

        //#region GL_ARB_depth_texture

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT16_ARB = 0x81A5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT24_ARB = 0x81A6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT32_ARB = 0x81A7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_DEPTH_SIZE_ARB = 0x884A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_TEXTURE_MODE_ARB = 0x884B;

        //#endregion

        //#region GL_ARB_shadow

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_MODE_ARB = 0x884C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_FUNC_ARB = 0x884D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPARE_R_TO_TEXTURE_ARB = 0x884E;

        //#endregion

        //#region GL_EXT_fog_coord

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordfEXT(float coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordfvEXT(float[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoorddEXT(double coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoorddvEXT(double[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glFogCoordPointerEXT(uint type, int stride, IntPtr pointer);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_SOURCE = 0x8450;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE = 0x8451;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAGMENT_DEPTH = 0x8452;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_FOG_COORDINATE = 0x8453;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_ARRAY_TYPE = 0x8454;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_ARRAY_STRIDE = 0x8455;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_ARRAY_POINTER = 0x8456;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_ARRAY = 0x8457;

        //#endregion

        //#region GL_EXT_multi_draw_arrays

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="first"></param>
        ///// <param name="count"></param>
        ///// <param name="primcount"></param>
        //public delegate void glMultiDrawArraysEXT(uint mode, int[] first, int[] count, int primcount);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="count"></param>
        ///// <param name="type"></param>
        ///// <param name="indices"></param>
        ///// <param name="primcount"></param>
        //public delegate void glMultiDrawElementsEXT(uint mode, int[] count, uint type, IntPtr indices, int primcount);

        //#endregion

        //#region GL_ARB_point_parameters

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="param"></param>
        //public delegate void glPointParameterfARB(uint pname, float param);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glPointParameterfvARB(uint pname, float[] parameters);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_SIZE_MIN_ARB = 0x8126;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_SIZE_MAX_ARB = 0x8127;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_FADE_THRESHOLD_SIZE_ARB = 0x8128;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_DISTANCE_ATTENUATION_ARB = 0x8129;

        //#endregion

        //#region GL_EXT_secondary_color

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3bEXT(sbyte red, sbyte green, sbyte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3bvEXT(sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3dEXT(double red, double green, double blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3dvEXT(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3fEXT(float red, float green, float blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3fvEXT(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3iEXT(int red, int green, int blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3ivEXT(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3sEXT(short red, short green, short blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3svEXT(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3ubEXT(byte red, byte green, byte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3ubvEXT(byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3uiEXT(uint red, uint green, uint blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3uivEXT(uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3usEXT(ushort red, ushort green, ushort blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3usvEXT(ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glSecondaryColorPointerEXT(int size, uint type, int stride, IntPtr pointer);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_SUM = 0x8458;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_SECONDARY_COLOR = 0x8459;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY_SIZE = 0x845A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY_TYPE = 0x845B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY_STRIDE = 0x845C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY_POINTER = 0x845D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY = 0x845E;

        //#endregion

        //#region  GL_EXT_blend_func_separate

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sfactorRGB"></param>
        ///// <param name="dfactorRGB"></param>
        ///// <param name="sfactorAlpha"></param>
        ///// <param name="dfactorAlpha"></param>
        //public delegate void glBlendFuncSeparateEXT(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);

        ////  Constants

        //#endregion

        //#region GL_EXT_stencil_wrap

        ////  Constants

        //#endregion

        //#region GL_ARB_texture_env_crossbar

        ////  No methods or constants.

        //#endregion

        //#region GL_EXT_texture_lod_bias

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_FILTER_CONTROL = 0x8500;

        //#endregion

        //#region GL_ARB_texture_mirrored_repeat

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MIRRORED_REPEAT_ARB = 0x8370;

        //#endregion

        //#region GL_ARB_window_pos

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2dARB(double x, double y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2dvARB(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2fARB(float x, float y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2fvARB(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2iARB(int x, int y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2ivARB(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2sARB(short x, short y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2svARB(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3dARB(double x, double y, double z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3dvARB(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3fARB(float x, float y, float z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3fvARB(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3iARB(int x, int y, int z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3ivARB(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3sARB(short x, short y, short z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3svARB(short[] v);

        //#endregion

        //#region GL_ARB_vertex_buffer_object

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="buffer"></param>
        //public delegate void glBindBufferARB(uint target, uint buffer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="buffers"></param>
        //public delegate void glDeleteBuffersARB(int n, uint[] buffers);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="buffers"></param>
        //public delegate void glGenBuffersARB(int n, uint[] buffers);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <returns></returns>
        //public delegate bool glIsBufferARB(uint buffer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        ///// <param name="usage"></param>
        //public delegate void glBufferDataARB(uint target, uint size, IntPtr data, uint usage);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        //public delegate void glBufferSubDataARB(uint target, uint offset, uint size, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        //public delegate void glGetBufferSubDataARB(uint target, uint offset, uint size, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="access"></param>
        ///// <returns></returns>
        //public delegate IntPtr glMapBufferARB(uint target, uint access);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //public delegate bool glUnmapBufferARB(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferParameterivARB(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferPointervARB(uint target, uint pname, IntPtr parameters);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_SIZE_ARB = 0x8764;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_USAGE_ARB = 0x8765;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ARRAY_BUFFER_ARB = 0x8892;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ELEMENT_ARRAY_BUFFER_ARB = 0x8893;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ARRAY_BUFFER_BINDING_ARB = 0x8894;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING_ARB = 0x8895;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ARRAY_BUFFER_BINDING_ARB = 0x8896;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_NORMAL_ARRAY_BUFFER_BINDING_ARB = 0x8897;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x8898;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INDEX_ARRAY_BUFFER_BINDING_ARB = 0x8899;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = 0x889A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = 0x889B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x889C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = 0x889D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_WEIGHT_ARRAY_BUFFER_BINDING_ARB = 0x889E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = 0x889F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_READ_ONLY_ARB = 0x88B8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_WRITE_ONLY_ARB = 0x88B9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_READ_WRITE_ARB = 0x88BA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_ACCESS_ARB = 0x88BB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_MAPPED_ARB = 0x88BC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BUFFER_MAP_POINTER_ARB = 0x88BD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STREAM_DRAW_ARB = 0x88E0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STREAM_READ_ARB = 0x88E1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STREAM_COPY_ARB = 0x88E2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STATIC_DRAW_ARB = 0x88E4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STATIC_READ_ARB = 0x88E5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STATIC_COPY_ARB = 0x88E6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DYNAMIC_DRAW_ARB = 0x88E8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DYNAMIC_READ_ARB = 0x88E9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DYNAMIC_COPY_ARB = 0x88EA;
        //#endregion

        //#region GL_ARB_occlusion_query

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //public delegate void glGenQueriesARB(int n, uint[] ids);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //public delegate void glDeleteQueriesARB(int n, uint[] ids);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public delegate bool glIsQueryARB(uint id);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="id"></param>
        //public delegate void glBeginQueryARB(uint target, uint id);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glEndQueryARB(uint target);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryivARB(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryObjectivARB(uint id, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetQueryObjectuivARB(uint id, uint pname, uint[] parameters);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_COUNTER_BITS_ARB = 0x8864;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_QUERY_ARB = 0x8865;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_RESULT_ARB = 0x8866;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_QUERY_RESULT_AVAILABLE_ARB = 0x8867;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLES_PASSED_ARB = 0x8914;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ANY_SAMPLES_PASSED = 0x8C2F;

        //#endregion

        //#region GL_ARB_shader_objects

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        //public delegate void glDeleteObjectARB(uint obj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <returns></returns>
        //public delegate uint glGetHandleARB(uint pname);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="containerObj"></param>
        ///// <param name="attachedObj"></param>
        //public delegate void glDetachObjectARB(uint containerObj, uint attachedObj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="shaderType"></param>
        ///// <returns></returns>
        //public delegate uint glCreateShaderObjectARB(uint shaderType);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="shaderObj"></param>
        ///// <param name="count"></param>
        ///// <param name="source"></param>
        ///// <param name="length"></param>
        //public delegate void glShaderSourceARB(uint shaderObj, int count, string[] source, ref int length);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="shaderObj"></param>
        //public delegate void glCompileShaderARB(uint shaderObj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public delegate uint glCreateProgramObjectARB();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="containerObj"></param>
        ///// <param name="obj"></param>
        //public delegate void glAttachObjectARB(uint containerObj, uint obj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        //public delegate void glLinkProgramARB(uint programObj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        //public delegate void glUseProgramObjectARB(uint programObj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        //public delegate void glValidateProgramARB(uint programObj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        //public delegate void glUniform1fARB(int location, float v0);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        //public delegate void glUniform2fARB(int location, float v0, float v1);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        //public delegate void glUniform3fARB(int location, float v0, float v1, float v2);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        ///// <param name="v3"></param>
        //public delegate void glUniform4fARB(int location, float v0, float v1, float v2, float v3);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        //public delegate void glUniform1iARB(int location, int v0);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        //public delegate void glUniform2iARB(int location, int v0, int v1);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        //public delegate void glUniform3iARB(int location, int v0, int v1, int v2);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        ///// <param name="v3"></param>
        //public delegate void glUniform4iARB(int location, int v0, int v1, int v2, int v3);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform1fvARB(int location, int count, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform2fvARB(int location, int count, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform3fvARB(int location, int count, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform4fvARB(int location, int count, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform1ivARB(int location, int count, int[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform2ivARB(int location, int count, int[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform3ivARB(int location, int count, int[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //public delegate void glUniform4ivARB(int location, int count, int[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix2fvARB(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix3fvARB(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="transpose"></param>
        ///// <param name="value"></param>
        //public delegate void glUniformMatrix4fvARB(int location, int count, bool transpose, float[] value);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetObjectParameterfvARB(uint obj, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetObjectParameterivARB(uint obj, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="maxLength"></param>
        ///// <param name="length"></param>
        ///// <param name="infoLog"></param>
        //public delegate void glGetInfoLogARB(uint obj, int maxLength, ref int length, string infoLog);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="containerObj"></param>
        ///// <param name="maxCount"></param>
        ///// <param name="count"></param>
        ///// <param name="obj"></param>
        //public delegate void glGetAttachedObjectsARB(uint containerObj, int maxCount, ref int count, ref uint obj);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public delegate int glGetUniformLocationARB(uint programObj, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="index"></param>
        ///// <param name="maxLength"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveUniformARB(uint programObj, uint index, int maxLength, ref int length, ref int size, ref uint type, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="location"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetUniformfvARB(uint programObj, int location, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="location"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetUniformivARB(uint programObj, int location, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="maxLength"></param>
        ///// <param name="length"></param>
        ///// <param name="source"></param>
        //public delegate void glGetShaderSourceARB(uint obj, int maxLength, ref int length, string source);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_OBJECT_ARB = 0x8B40;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_OBJECT_ARB = 0x8B48;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_TYPE_ARB = 0x8B4E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_SUBTYPE_ARB = 0x8B4F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC2_ARB = 0x8B50;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC3_ARB = 0x8B51;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_VEC4_ARB = 0x8B52;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC2_ARB = 0x8B53;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC3_ARB = 0x8B54;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INT_VEC4_ARB = 0x8B55;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_ARB = 0x8B56;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC2_ARB = 0x8B57;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC3_ARB = 0x8B58;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BOOL_VEC4_ARB = 0x8B59;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT2_ARB = 0x8B5A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT3_ARB = 0x8B5B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_MAT4_ARB = 0x8B5C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_1D_ARB = 0x8B5D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D_ARB = 0x8B5E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_3D_ARB = 0x8B5F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_CUBE_ARB = 0x8B60;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_1D_SHADOW_ARB = 0x8B61;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D_SHADOW_ARB = 0x8B62;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D_RECT_ARB = 0x8B63;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SAMPLER_2D_RECT_SHADOW_ARB = 0x8B64;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_DELETE_STATUS_ARB = 0x8B80;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_COMPILE_STATUS_ARB = 0x8B81;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_LINK_STATUS_ARB = 0x8B82;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_VALIDATE_STATUS_ARB = 0x8B83;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_INFO_LOG_LENGTH_ARB = 0x8B84;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_ATTACHED_OBJECTS_ARB = 0x8B85;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_ACTIVE_UNIFORMS_ARB = 0x8B86;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = 0x8B87;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_SHADER_SOURCE_LENGTH_ARB = 0x8B88;

        //#endregion

        //#region GL_ARB_vertex_program

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1dARB(uint index, double x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1dvARB(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1fARB(uint index, float x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1fvARB(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1sARB(uint index, short x);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1svARB(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2dARB(uint index, double x, double y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2dvARB(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2fARB(uint index, float x, float y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2fvARB(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2sARB(uint index, short x, short y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2svARB(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3dARB(uint index, double x, double y, double z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3dvARB(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3fARB(uint index, float x, float y, float z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3fvARB(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3sARB(uint index, short x, short y, short z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3svARB(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NbvARB(uint index, sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NivARB(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NsvARB(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4NubARB(uint index, byte x, byte y, byte z, byte w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NubvARB(uint index, byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NuivARB(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4NusvARB(uint index, ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4bvARB(uint index, sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4dARB(uint index, double x, double y, double z, double w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4dvARB(uint index, double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4fARB(uint index, float x, float y, float z, float w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4fvARB(uint index, float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4ivARB(uint index, int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4sARB(uint index, short x, short y, short z, short w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4svARB(uint index, short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4ubvARB(uint index, byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4uivARB(uint index, uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4usvARB(uint index, ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="normalized"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glVertexAttribPointerARB(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        //public delegate void glEnableVertexAttribArrayARB(uint index);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        //public delegate void glDisableVertexAttribArrayARB(uint index);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="len"></param>
        ///// <param name="str"></param>
        //public delegate void glProgramStringARB(uint target, uint format, int len, IntPtr str);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="program"></param>
        //public delegate void glBindProgramARB(uint target, uint program);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="programs"></param>
        //public delegate void glDeleteProgramsARB(int n, uint[] programs);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="programs"></param>
        //public delegate void glGenProgramsARB(int n, uint[] programs);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glProgramEnvParameter4dARB(uint target, uint index, double x, double y, double z, double w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glProgramEnvParameter4dvARB(uint target, uint index, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glProgramEnvParameter4fARB(uint target, uint index, float x, float y, float z, float w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glProgramEnvParameter4fvARB(uint target, uint index, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glProgramLocalParameter4dARB(uint target, uint index, double x, double y, double z, double w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glProgramLocalParameter4dvARB(uint target, uint index, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glProgramLocalParameter4fARB(uint target, uint index, float x, float y, float z, float w);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glProgramLocalParameter4fvARB(uint target, uint index, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetProgramEnvParameterdvARB(uint target, uint index, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetProgramEnvParameterfvARB(uint target, uint index, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetProgramLocalParameterdvARB(uint target, uint index, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetProgramLocalParameterfvARB(uint target, uint index, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetProgramivARB(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="str"></param>
        //public delegate void glGetProgramStringARB(uint target, uint pname, IntPtr str);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribdvARB(uint index, uint pname, double[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribfvARB(uint index, uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribivARB(uint index, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="pointer"></param>
        //public delegate void glGetVertexAttribPointervARB(uint index, uint pname, IntPtr pointer);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_SUM_ARB = 0x8458;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_PROGRAM_ARB = 0x8620;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 0x8622;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE_ARB = 0x8623;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 0x8624;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE_ARB = 0x8625;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_VERTEX_ATTRIB_ARB = 0x8626;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_LENGTH_ARB = 0x8627;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_STRING_ARB = 0x8628;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = 0x862E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_MATRICES_ARB = 0x862F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_MATRIX_STACK_DEPTH_ARB = 0x8640;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CURRENT_MATRIX_ARB = 0x8641;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_PROGRAM_POINT_SIZE_ARB = 0x8642;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_PROGRAM_TWO_SIDE_ARB = 0x8643;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER_ARB = 0x8645;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_ERROR_POSITION_ARB = 0x864B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_BINDING_ARB = 0x8677;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_ATTRIBS_ARB = 0x8869;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 0x886A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_ERROR_STRING_ARB = 0x8874;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_FORMAT_ASCII_ARB = 0x8875;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_FORMAT_ARB = 0x8876;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_INSTRUCTIONS_ARB = 0x88A0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_INSTRUCTIONS_ARB = 0x88A1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_TEMPORARIES_ARB = 0x88A4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_TEMPORARIES_ARB = 0x88A5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_PARAMETERS_ARB = 0x88A8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_PARAMETERS_ARB = 0x88A9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_ATTRIBS_ARB = 0x88AC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_ATTRIBS_ARB = 0x88AD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_LOCAL_PARAMETERS_ARB = 0x88B4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_PROGRAM_ENV_PARAMETERS_ARB = 0x88B5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROGRAM_UNDER_NATIVE_LIMITS_ARB = 0x88B6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TRANSPOSE_CURRENT_MATRIX_ARB = 0x88B7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX0_ARB = 0x88C0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX1_ARB = 0x88C1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX2_ARB = 0x88C2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX3_ARB = 0x88C3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX4_ARB = 0x88C4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX5_ARB = 0x88C5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX6_ARB = 0x88C6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX7_ARB = 0x88C7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX8_ARB = 0x88C8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX9_ARB = 0x88C9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX10_ARB = 0x88CA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX11_ARB = 0x88CB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX12_ARB = 0x88CC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX13_ARB = 0x88CD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX14_ARB = 0x88CE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX15_ARB = 0x88CF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX16_ARB = 0x88D0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX17_ARB = 0x88D1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX18_ARB = 0x88D2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX19_ARB = 0x88D3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX20_ARB = 0x88D4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX21_ARB = 0x88D5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX22_ARB = 0x88D6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX23_ARB = 0x88D7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX24_ARB = 0x88D8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX25_ARB = 0x88D9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX26_ARB = 0x88DA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX27_ARB = 0x88DB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX28_ARB = 0x88DC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX29_ARB = 0x88DD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX30_ARB = 0x88DE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MATRIX31_ARB = 0x88DF;

        //#endregion

        //#region GL_ARB_vertex_shader

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="index"></param>
        ///// <param name="name"></param>
        //public delegate void glBindAttribLocationARB(uint programObj, uint index, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="index"></param>
        ///// <param name="maxLength"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveAttribARB(uint programObj, uint index, int maxLength, int[] length, int[] size, uint[] type, string name);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="programObj"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public delegate uint glGetAttribLocationARB(uint programObj, string name);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_SHADER_ARB = 0x8B31;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS_ARB = 0x8B4A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VARYING_FLOATS_ARB = 0x8B4B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = 0x8B4C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = 0x8B4D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_ACTIVE_ATTRIBUTES_ARB = 0x8B89;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = 0x8B8A;

        //#endregion

        //#region GL_ARB_fragment_shader

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAGMENT_SHADER_ARB = 0x8B30;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = 0x8B49;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = 0x8B8B;

        //#endregion

        //#region GL_ARB_draw_buffers

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="bufs"></param>
        //public delegate void glDrawBuffersARB(int n, uint[] bufs);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_DRAW_BUFFERS_ARB = 0x8824;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER0_ARB = 0x8825;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER1_ARB = 0x8826;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER2_ARB = 0x8827;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER3_ARB = 0x8828;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER4_ARB = 0x8829;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER5_ARB = 0x882A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER6_ARB = 0x882B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER7_ARB = 0x882C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER8_ARB = 0x882D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER9_ARB = 0x882E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER10_ARB = 0x882F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER11_ARB = 0x8830;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER12_ARB = 0x8831;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER13_ARB = 0x8832;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER14_ARB = 0x8833;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DRAW_BUFFER15_ARB = 0x8834;

        //#endregion

        //#region GL_ARB_texture_non_power_of_two

        ////  No methods or constants

        //#endregion

        //#region GL_ARB_texture_rectangle

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_RECTANGLE_ARB = 0x84F5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_BINDING_RECTANGLE_ARB = 0x84F6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PROXY_TEXTURE_RECTANGLE_ARB = 0x84F7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE_ARB = 0x84F8;

        //#endregion

        //#region GL_ARB_point_sprite

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SPRITE_ARB = 0x8861;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COORD_REPLACE_ARB = 0x8862;

        //#endregion

        //#region GL_ARB_texture_float

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_RED_TYPE_ARB = 0x8C10;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_GREEN_TYPE_ARB = 0x8C11;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_BLUE_TYPE_ARB = 0x8C12;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_ALPHA_TYPE_ARB = 0x8C13;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_LUMINANCE_TYPE_ARB = 0x8C14;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_INTENSITY_TYPE_ARB = 0x8C15;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_DEPTH_TYPE_ARB = 0x8C16;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_UNSIGNED_NORMALIZED_ARB = 0x8C17;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGBA32F_ARB = 0x8814;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGB32F_ARB = 0x8815;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ALPHA32F_ARB = 0x8816;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTENSITY32F_ARB = 0x8817;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LUMINANCE32F_ARB = 0x8818;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LUMINANCE_ALPHA32F_ARB = 0x8819;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGBA16F_ARB = 0x881A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGB16F_ARB = 0x881B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ALPHA16F_ARB = 0x881C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTENSITY16F_ARB = 0x881D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LUMINANCE16F_ARB = 0x881E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_LUMINANCE_ALPHA16F_ARB = 0x881F;

        //#endregion

        //#region GL_EXT_blend_equation_separate

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modeRGB"></param>
        ///// <param name="modeAlpha"></param>
        //public delegate void glBlendEquationSeparateEXT(uint modeRGB, uint modeAlpha);

        ////  Constants

        //#endregion

        //#region GL_EXT_stencil_two_side

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="face"></param>
        //public delegate void glActiveStencilFaceEXT(uint face);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_TEST_TWO_SIDE = 0x8009;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ACTIVE_STENCIL_FACE = 0x883D;

        //#endregion

        //#region GL_ARB_pixel_buffer_object

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_PACK_BUFFER_ARB = 0x88EB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_UNPACK_BUFFER_ARB = 0x88EC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_PACK_BUFFER_BINDING_ARB = 0x88ED;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PIXEL_UNPACK_BUFFER_BINDING_ARB = 0x88EF;

        //#endregion

        //#region GL_EXT_texture_sRGB

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SLUMINANCE_ALPHA = 0x8C44;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SLUMINANCE8_ALPHA8 = 0x8C45;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SLUMINANCE = 0x8C46;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SLUMINANCE8 = 0x8C47;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SLUMINANCE = 0x8C4A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_S3TC_DXT1 = 0x8C4C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = 0x8C4D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = 0x8C4E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = 0x8C4F;

        //#endregion

        #region GL_EXT_framebuffer_object

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderbuffer"></param>
        /// <returns></returns>
        public delegate bool glIsRenderbufferEXT(uint renderbuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="renderbuffer"></param>
        public delegate void glBindRenderbufferEXT(uint target, uint renderbuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="renderbuffers"></param>
        public delegate void glDeleteRenderbuffersEXT(uint n, uint[] renderbuffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="renderbuffers"></param>
        public delegate void glGenRenderbuffersEXT(uint n, uint[] renderbuffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public delegate void glRenderbufferStorageEXT(uint target, uint internalformat, int width, int height);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetRenderbufferParameterivEXT(uint target, uint pname, int[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="framebuffer"></param>
        /// <returns></returns>
        public delegate bool glIsFramebufferEXT(uint framebuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="framebuffer"></param>
        public delegate void glBindFramebufferEXT(uint target, uint framebuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="framebuffers"></param>
        public delegate void glDeleteFramebuffersEXT(uint n, uint[] framebuffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="framebuffers"></param>
        public delegate void glGenFramebuffersEXT(uint n, uint[] framebuffers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public delegate uint glCheckFramebufferStatusEXT(uint target);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="textarget"></param>
        /// <param name="texture"></param>
        /// <param name="level"></param>
        public delegate void glFramebufferTexture1DEXT(uint target, uint attachment, uint textarget, uint texture, int level);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="textarget"></param>
        /// <param name="texture"></param>
        /// <param name="level"></param>
        public delegate void glFramebufferTexture2DEXT(uint target, uint attachment, uint textarget, uint texture, int level);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="textarget"></param>
        /// <param name="texture"></param>
        /// <param name="level"></param>
        /// <param name="zoffset"></param>
        public delegate void glFramebufferTexture3DEXT(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="renderbuffertarget"></param>
        /// <param name="renderbuffer"></param>
        public delegate void glFramebufferRenderbufferEXT(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attachment"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetFramebufferAttachmentParameterivEXT(uint target, uint attachment, uint pname, int[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        private delegate void glGenerateMipmapEXT(uint target);
        private static glGenerateMipmapEXT glGenerateMipmapFunc;
        public static void GenerateMipmap(uint target)
        {
            if (glGenerateMipmapFunc == null)
            { glGenerateMipmapFunc = OpenGL.GetDelegateFor<OpenGL.glGenerateMipmapEXT>(); }
            glGenerateMipmapFunc(target);
        }
        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_RENDERBUFFER_SIZE = 0x84E8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_BINDING = 0x8CA6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_BINDING = 0x8CA7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_READ_FRAMEBUFFER = 0x8CA8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DRAW_FRAMEBUFFER = 0x8CA9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET = 0x8CD4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_COMPLETE = 0x8CD5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT1 = 0x8CE1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT2 = 0x8CE2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT3 = 0x8CE3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT4 = 0x8CE4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT5 = 0x8CE5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT6 = 0x8CE6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT7 = 0x8CE7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT8 = 0x8CE8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT9 = 0x8CE9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT10 = 0x8CEA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT11 = 0x8CEB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT12 = 0x8CEC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT13 = 0x8CED;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT14 = 0x8CEE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ATTACHMENT15 = 0x8CEF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_ATTACHMENT = 0x8D00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_ATTACHMENT = 0x8D20;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER = 0x8D40;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER = 0x8D41;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_WIDTH = 0x8D42;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_HEIGHT = 0x8D43;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_INDEX1 = 0x8D46;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_INDEX4 = 0x8D47;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_INDEX8 = 0x8D48;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_INDEX16 = 0x8D49;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_RED_SIZE = 0x8D50;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;

        #endregion

        //#region GL_EXT_framebuffer_multisample

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="samples"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glRenderbufferStorageMultisampleEXT(uint target, int samples, uint internalformat, int width, int height);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RENDERBUFFER_SAMPLES = 0x8CAB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_SAMPLES = 0x8D57;

        //#endregion

        //#region GL_EXT_draw_instanced

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="start"></param>
        ///// <param name="count"></param>
        ///// <param name="primcount"></param>
        //public delegate void glDrawArraysInstancedEXT(uint mode, int start, int count, int primcount);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="count"></param>
        ///// <param name="type"></param>
        ///// <param name="indices"></param>
        ///// <param name="primcount"></param>
        //public delegate void glDrawElementsInstancedEXT(uint mode, int count, uint type, IntPtr indices, int primcount);

        //#endregion

        #region GL_ARB_vertex_array_object

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public delegate void glBindVertexArray(uint array);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="arrays"></param>
        public delegate void glDeleteVertexArrays(int n, uint[] arrays);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="arrays"></param>
        public delegate void glGenVertexArrays(int n, uint[] arrays);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public delegate bool glIsVertexArray(uint array);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ARRAY_BINDING = 0x85B5;

        #endregion

        //#region GL_EXT_framebuffer_sRGB

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_SRGB = 0x8DB9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_SRGB_CAPABLE = 0x8DBA;

        //#endregion

        //#region GGL_EXT_transform_feedback

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="primitiveMode"></param>
        //public delegate void glBeginTransformFeedbackEXT(uint primitiveMode);
        ///// <summary>
        ///// 
        ///// </summary>
        //public delegate void glEndTransformFeedbackEXT();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="buffer"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        //public delegate void glBindBufferRangeEXT(uint target, uint index, uint buffer, int offset, int size);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="buffer"></param>
        ///// <param name="offset"></param>
        //public delegate void glBindBufferOffsetEXT(uint target, uint index, uint buffer, int offset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="buffer"></param>
        //public delegate void glBindBufferBaseEXT(uint target, uint index, uint buffer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="count"></param>
        ///// <param name="varyings"></param>
        ///// <param name="bufferMode"></param>
        //public delegate void glTransformFeedbackVaryingsEXT(uint program, int count, string[] varyings, uint bufferMode);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetTransformFeedbackVaryingEXT(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);

        ////  Constants

        //#endregion

        //#region WGL_ARB_extensions_string

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hdc"></param>
        ///// <returns></returns>
        //public delegate string wglGetExtensionsStringARB(IntPtr hdc);

        //#endregion

        #region WGL_ARB_create_context

        //  Delegates
        /// <summary>
        /// Creates a render context with the specified attributes.
        /// </summary>
        /// <param name="hDC">device context handle.</param>
        /// <param name="hShareContext">
        /// If is not null, then all shareable data (excluding
        /// OpenGL texture objects named 0) will be shared by <paramref name="hShareContext"/>,
        /// all other contexts <paramref name="hShareContext"/> already shares with, and the
        /// newly created context. An arbitrary number of contexts can share
        /// data in this fashion.</param>
        /// <param name="attribList">
        /// specifies a list of attributes for the context. The
        /// list consists of a sequence of &lt;name, value&gt; pairs terminated by the
        /// value 0. If an attribute is not specified in <paramref name="attribList"/>, then the
        /// default value specified below is used instead. If an attribute is
        /// specified more than once, then the last value specified is used.
        /// </param>
        /// <returns></returns>
        public delegate IntPtr wglCreateContextAttribsARB(IntPtr hDC, IntPtr hShareContext, int[] attribList);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_MAJOR_VERSION_ARB = 0x2091;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_MINOR_VERSION_ARB = 0x2092;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_LAYER_PLANE_ARB = 0x2093;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_FLAGS_ARB = 0x2094;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_PROFILE_MASK_ARB = 0x9126;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_DEBUG_BIT_ARB = 0x0001;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 0x0002;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_CORE_PROFILE_BIT_ARB = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const int WGL_CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const int ERROR_INVALID_VERSION_ARB = 0x2095;
        /// <summary>
        /// 
        /// </summary>
        public const int ERROR_INVALID_PROFILE_ARB = 0x2096;

        #endregion

        //#region GL_ARB_explicit_uniform_location

        ////  Constants

        ///// <summary>
        ///// The number of available pre-assigned uniform locations to that can default be
        ///// allocated in the default uniform block.
        ///// </summary>
        //public const int GL_MAX_UNIFORM_LOCATIONS = 0x826E;

        //#endregion

        //#region GL_ARB_clear_buffer_object

        ////  Delegates
        ///// <summary>
        ///// Fill a buffer object's data store with a fixed value
        ///// </summary>
        ///// <param name="target">Specifies the target buffer object. The symbolic constant must be GL_ARRAY_BUFFER​, GL_ATOMIC_COUNTER_BUFFER​, GL_COPY_READ_BUFFER​, GL_COPY_WRITE_BUFFER​, GL_DRAW_INDIRECT_BUFFER​, GL_DISPATCH_INDIRECT_BUFFER​, GL_ELEMENT_ARRAY_BUFFER​, GL_PIXEL_PACK_BUFFER​, GL_PIXEL_UNPACK_BUFFER​, GL_QUERY_BUFFER​, GL_SHADER_STORAGE_BUFFER​, GL_TEXTURE_BUFFER​, GL_TRANSFORM_FEEDBACK_BUFFER​, or GL_UNIFORM_BUFFER​.</param>
        ///// <param name="internalformat">The sized internal format with which the data will be stored in the buffer object.</param>
        ///// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        ///// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        ///// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be NULL.</param>
        //public delegate void glClearBufferData(uint target, uint internalformat, uint format, uint type, IntPtr data);
        ///// <summary>
        ///// Fill all or part of buffer object's data store with a fixed value
        ///// </summary>
        ///// <param name="target">Specifies the target buffer object. The symbolic constant must be GL_ARRAY_BUFFER​, GL_ATOMIC_COUNTER_BUFFER​, GL_COPY_READ_BUFFER​, GL_COPY_WRITE_BUFFER​, GL_DRAW_INDIRECT_BUFFER​, GL_DISPATCH_INDIRECT_BUFFER​, GL_ELEMENT_ARRAY_BUFFER​, GL_PIXEL_PACK_BUFFER​, GL_PIXEL_UNPACK_BUFFER​, GL_QUERY_BUFFER​, GL_SHADER_STORAGE_BUFFER​, GL_TEXTURE_BUFFER​, GL_TRANSFORM_FEEDBACK_BUFFER​, or GL_UNIFORM_BUFFER​.</param>
        ///// <param name="internalformat">The sized internal format with which the data will be stored in the buffer object.</param>
        ///// <param name="offset">The offset, in basic machine units into the buffer object's data store at which to start filling.</param>
        ///// <param name="size">The size, in basic machine units of the range of the data store to fill.</param>
        ///// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        ///// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        ///// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be NULL.</param>
        //public delegate void glClearBufferSubData(uint target, uint internalformat, IntPtr offset, uint size, uint format, uint type, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="data"></param>
        //public delegate void glClearNamedBufferDataEXT(uint buffer, uint internalformat, uint format, uint type, IntPtr data);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="data"></param>
        //public delegate void glClearNamedBufferSubDataEXT(uint buffer, uint internalformat, IntPtr offset, uint size, uint format, uint type, IntPtr data);

        //#endregion

        #region GL_ARB_compute_shader

        //  Delegates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num_groups_x"></param>
        /// <param name="num_groups_y"></param>
        /// <param name="num_groups_z"></param>
        public delegate void glDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="indirect"></param>
        //public delegate void glDispatchComputeIndirect(IntPtr indirect);

        // Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPUTE_SHADER = 0x91B9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_UNIFORM_BLOCKS = 0x91BB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_TEXTURE_IMAGE_UNITS = 0x91BC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_IMAGE_UNIFORMS = 0x91BD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_SHARED_MEMORY_SIZE = 0x8262;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_UNIFORM_COMPONENTS = 0x8263;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_ATOMIC_COUNTER_BUFFERS = 0x8264;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_ATOMIC_COUNTERS = 0x8265;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_COMPUTE_UNIFORM_COMPONENTS = 0x8266;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_WORK_GROUP_INVOCATIONS = 0x90EB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_WORK_GROUP_COUNT = 0x91BE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_WORK_GROUP_SIZE = 0x91BF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPUTE_WORK_GROUP_SIZE = 0x8267;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_COMPUTE_SHADER = 0x90EC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_COMPUTE_SHADER = 0x90ED;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DISPATCH_INDIRECT_BUFFER = 0x90EE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DISPATCH_INDIRECT_BUFFER_BINDING = 0x90EF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPUTE_SHADER_BIT = 0x00000020;

        #endregion

        //#region GL_ARB_copy_image

        ////  Delegates
        ///// <summary>
        ///// Perform a raw data copy between two images
        ///// </summary>
        ///// <param name="srcName">The name of a texture or renderbuffer object from which to copy.</param>
        ///// <param name="srcTarget">The target representing the namespace of the source name srcName​.</param>
        ///// <param name="srcLevel">The mipmap level to read from the source.</param>
        ///// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        ///// <param name="srcY">The Y coordinate of the top edge of the souce region to copy.</param>
        ///// <param name="srcZ">The Z coordinate of the near edge of the souce region to copy.</param>
        ///// <param name="dstName">The name of a texture or renderbuffer object to which to copy.</param>
        ///// <param name="dstTarget">The target representing the namespace of the destination name dstName​.</param>
        ///// <param name="dstLevel">The desination mipmap level.</param>
        ///// <param name="dstX">The X coordinate of the left edge of the destination region.</param>
        ///// <param name="dstY">The Y coordinate of the top edge of the destination region.</param>
        ///// <param name="dstZ">The Z coordinate of the near edge of the destination region.</param>
        ///// <param name="srcWidth">The width of the region to be copied.</param>
        ///// <param name="srcHeight">The height of the region to be copied.</param>
        ///// <param name="srcDepth">The depth of the region to be copied.</param>
        //public delegate void glCopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName,
        //    uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint srcWidth, uint srcHeight, uint srcDepth);

        //#endregion

        //#region GL_ARB_ES3_compatibility

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGB8_ETC2 = 0x9274;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB8_ETC2 = 0x9275;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9276;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9277;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGBA8_ETC2_EAC = 0x9278;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9279;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_R11_EAC = 0x9270;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SIGNED_R11_EAC = 0x9271;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RG11_EAC = 0x9272;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SIGNED_RG11_EAC = 0x9273;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_ELEMENT_INDEX = 0x8D6B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_IMMUTABLE_LEVELS = 0x82DF;

        //#endregion

        //#region GL_ARB_framebuffer_no_attachments

        ////  Delegates
        ///// <summary>
        ///// Set a named parameter of a framebuffer.
        ///// </summary>
        ///// <param name="target">The target of the operation, which must be GL_READ_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​ or GL_FRAMEBUFFER​.</param>
        ///// <param name="pname">A token indicating the parameter to be modified.</param>
        ///// <param name="param">The new value for the parameter named pname​.</param>
        //public delegate void glFramebufferParameteri(uint target, uint pname, int param);
        ///// <summary>
        ///// Retrieve a named parameter from a framebuffer
        ///// </summary>
        ///// <param name="target">The target of the operation, which must be GL_READ_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​ or GL_FRAMEBUFFER​.</param>
        ///// <param name="pname">A token indicating the parameter to be retrieved.</param>
        ///// <param name="parameters">The address of a variable to receive the value of the parameter named pname​.</param>
        //public delegate void glGetFramebufferParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="framebuffer"></param>
        ///// <param name="pname"></param>
        ///// <param name="param"></param>
        //public delegate void glNamedFramebufferParameteriEXT(uint framebuffer, uint pname, int param);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="framebuffer"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetNamedFramebufferParameterivEXT(uint framebuffer, uint pname, int[] parameters);

        //#endregion

        //#region GL_ARB_internalformat_query2

        ////  Delegates
        ///// <summary>
        ///// Retrieve information about implementation-dependent support for internal formats
        ///// </summary>
        ///// <param name="target">Indicates the usage of the internal format. target​ must be GL_TEXTURE_1D​, GL_TEXTURE_1D_ARRAY​, GL_TEXTURE_2D​, GL_TEXTURE_2D_ARRAY​, GL_TEXTURE_3D​, GL_TEXTURE_CUBE_MAP​, GL_TEXTURE_CUBE_MAP_ARRAY​, GL_TEXTURE_RECTANGLE​, GL_TEXTURE_BUFFER​, GL_RENDERBUFFER​, GL_TEXTURE_2D_MULTISAMPLE​ or GL_TEXTURE_2D_MULTISAMPLE_ARRAY​.</param>
        ///// <param name="internalformat">Specifies the internal format about which to retrieve information.</param>
        ///// <param name="pname">Specifies the type of information to query.</param>
        ///// <param name="bufSize">Specifies the maximum number of basic machine units that may be written to params​ by the function.</param>
        ///// <param name="parameters">Specifies the address of a variable into which to write the retrieved information.</param>
        //public delegate void glGetInternalformativ(uint target, uint internalformat, uint pname, uint bufSize, int[] parameters);
        ///// <summary>
        ///// Retrieve information about implementation-dependent support for internal formats
        ///// </summary>
        ///// <param name="target">Indicates the usage of the internal format. target​ must be GL_TEXTURE_1D​, GL_TEXTURE_1D_ARRAY​, GL_TEXTURE_2D​, GL_TEXTURE_2D_ARRAY​, GL_TEXTURE_3D​, GL_TEXTURE_CUBE_MAP​, GL_TEXTURE_CUBE_MAP_ARRAY​, GL_TEXTURE_RECTANGLE​, GL_TEXTURE_BUFFER​, GL_RENDERBUFFER​, GL_TEXTURE_2D_MULTISAMPLE​ or GL_TEXTURE_2D_MULTISAMPLE_ARRAY​.</param>
        ///// <param name="internalformat">Specifies the internal format about which to retrieve information.</param>
        ///// <param name="pname">Specifies the type of information to query.</param>
        ///// <param name="bufSize">Specifies the maximum number of basic machine units that may be written to params​ by the function.</param>
        ///// <param name="parameters">Specifies the address of a variable into which to write the retrieved information.</param>
        //public delegate void glGetInternalformati64v(uint target, uint internalformat, uint pname, uint bufSize, Int64[] parameters);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_2D_MULTISAMPLE = 0x9100;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_NUM_SAMPLE_COUNTS = 0x9380;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_SUPPORTED = 0x826F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_PREFERRED = 0x8270;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_RED_SIZE = 0x8271;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_GREEN_SIZE = 0x8272;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_BLUE_SIZE = 0x8273;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_ALPHA_SIZE = 0x8274;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_DEPTH_SIZE = 0x8275;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_STENCIL_SIZE = 0x8276;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_SHARED_SIZE = 0x8277;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_RED_TYPE = 0x8278;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_GREEN_TYPE = 0x8279;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_BLUE_TYPE = 0x827A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_ALPHA_TYPE = 0x827B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_DEPTH_TYPE = 0x827C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INTERNALFORMAT_STENCIL_TYPE = 0x827D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_WIDTH = 0x827E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_HEIGHT = 0x827F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_DEPTH = 0x8280;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_LAYERS = 0x8281;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_DIMENSIONS = 0x8282;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_COMPONENTS = 0x8283;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENTS = 0x8284;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_COMPONENTS = 0x8285;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_RENDERABLE = 0x8286;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_RENDERABLE = 0x8287;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_STENCIL_RENDERABLE = 0x8288;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_RENDERABLE = 0x8289;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_RENDERABLE_LAYERED = 0x828A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAMEBUFFER_BLEND = 0x828B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_READ_PIXELS = 0x828C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_READ_PIXELS_FORMAT = 0x828D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_READ_PIXELS_TYPE = 0x828E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_IMAGE_FORMAT = 0x828F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_IMAGE_TYPE = 0x8290;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_GET_TEXTURE_IMAGE_FORMAT = 0x8291;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_GET_TEXTURE_IMAGE_TYPE = 0x8292;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MIPMAP = 0x8293;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MANUAL_GENERATE_MIPMAP = 0x8294;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_AUTO_GENERATE_MIPMAP = 0x8295;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COLOR_ENCODING = 0x8296;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB_READ = 0x8297;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB_WRITE = 0x8298;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SRGB_DECODE_ARB = 0x8299;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FILTER = 0x829A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_TEXTURE = 0x829B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TESS_CONTROL_TEXTURE = 0x829C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TESS_EVALUATION_TEXTURE = 0x829D;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_GEOMETRY_TEXTURE = 0x829E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FRAGMENT_TEXTURE = 0x829F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPUTE_TEXTURE = 0x82A0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SHADOW = 0x82A1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_GATHER = 0x82A2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_GATHER_SHADOW = 0x82A3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_IMAGE_LOAD = 0x82A4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_IMAGE_STORE = 0x82A5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_IMAGE_ATOMIC = 0x82A6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_TEXEL_SIZE = 0x82A7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_COMPATIBILITY_CLASS = 0x82A8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_PIXEL_FORMAT = 0x82A9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_PIXEL_TYPE = 0x82AA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_FORMAT_COMPATIBILITY_TYPE = 0x90C7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_TEST = 0x82AC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_TEST = 0x82AD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_WRITE = 0x82AE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_WRITE = 0x82AF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSED_BLOCK_WIDTH = 0x82B1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSED_BLOCK_HEIGHT = 0x82B2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPRESSED_BLOCK_SIZE = 0x82B3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CLEAR_BUFFER = 0x82B4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_VIEW = 0x82B5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_COMPATIBILITY_CLASS = 0x82B6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FULL_SUPPORT = 0x82B7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_CAVEAT_SUPPORT = 0x82B8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_4_X_32 = 0x82B9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_2_X_32 = 0x82BA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_1_X_32 = 0x82BB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_4_X_16 = 0x82BC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_2_X_16 = 0x82BD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_1_X_16 = 0x82BE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_4_X_8 = 0x82BF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_2_X_8 = 0x82C0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_1_X_8 = 0x82C1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_11_11_10 = 0x82C2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_IMAGE_CLASS_10_10_10_2 = 0x82C3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_128_BITS = 0x82C4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_96_BITS = 0x82C5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_64_BITS = 0x82C6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_48_BITS = 0x82C7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_32_BITS = 0x82C8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_24_BITS = 0x82C9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_16_BITS = 0x82CA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_8_BITS = 0x82CB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_S3TC_DXT1_RGB = 0x82CC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_S3TC_DXT1_RGBA = 0x82CD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_S3TC_DXT3_RGBA = 0x82CE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_S3TC_DXT5_RGBA = 0x82CF;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_RGTC1_RED = 0x82D0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_RGTC2_RG = 0x82D1;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_BPTC_UNORM = 0x82D2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VIEW_CLASS_BPTC_FLOAT = 0x82D3;

        //#endregion

        //#region GL_ARB_invalidate_subdata

        ////  Delegates
        ///// <summary>
        ///// Invalidate a region of a texture image
        ///// </summary>
        ///// <param name="texture">The name of a texture object a subregion of which to invalidate.</param>
        ///// <param name="level">The level of detail of the texture object within which the region resides.</param>
        ///// <param name="xoffset">The X offset of the region to be invalidated.</param>
        ///// <param name="yoffset">The Y offset of the region to be invalidated.</param>
        ///// <param name="zoffset">The Z offset of the region to be invalidated.</param>
        ///// <param name="width">The width of the region to be invalidated.</param>
        ///// <param name="height">The height of the region to be invalidated.</param>
        ///// <param name="depth">The depth of the region to be invalidated.</param>
        //public delegate void glInvalidateTexSubImage(uint texture, int level, int xoffset,
        //    int yoffset, int zoffset, uint width, uint height, uint depth);
        ///// <summary>
        ///// Invalidate the entirety a texture image
        ///// </summary>
        ///// <param name="texture">The name of a texture object to invalidate.</param>
        ///// <param name="level">The level of detail of the texture object to invalidate.</param>
        //public delegate void glInvalidateTexImage(uint texture, int level);
        ///// <summary>
        ///// Invalidate a region of a buffer object's data store
        ///// </summary>
        ///// <param name="buffer">The name of a buffer object, a subrange of whose data store to invalidate.</param>
        ///// <param name="offset">The offset within the buffer's data store of the start of the range to be invalidated.</param>
        ///// <param name="length">The length of the range within the buffer's data store to be invalidated.</param>
        //public delegate void glInvalidateBufferSubData(uint buffer, IntPtr offset, IntPtr length);
        ///// <summary>
        ///// Invalidate the content of a buffer object's data store
        ///// </summary>
        ///// <param name="buffer">The name of a buffer object whose data store to invalidate.</param>
        //public delegate void glInvalidateBufferData(uint buffer);
        ///// <summary>
        ///// Invalidate the content some or all of a framebuffer object's attachments
        ///// </summary>
        ///// <param name="target">The target to which the framebuffer is attached. target​ must be GL_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​, or GL_READ_FRAMEBUFFER​.</param>
        ///// <param name="numAttachments">The number of entries in the attachments​ array.</param>
        ///// <param name="attachments">The address of an array identifying the attachments to be invalidated.</param>
        //public delegate void glInvalidateFramebuffer(uint target, uint numAttachments, uint[] attachments);
        ///// <summary>
        ///// Invalidate the content of a region of some or all of a framebuffer object's attachments
        ///// </summary>
        ///// <param name="target">The target to which the framebuffer is attached. target​ must be GL_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​, or GL_READ_FRAMEBUFFER​.</param>
        ///// <param name="numAttachments">The number of entries in the attachments​ array.</param>
        ///// <param name="attachments">The address of an array identifying the attachments to be invalidated.</param>
        ///// <param name="x">The X offset of the region to be invalidated.</param>
        ///// <param name="y">The Y offset of the region to be invalidated.</param>
        ///// <param name="width">The width of the region to be invalidated.</param>
        ///// <param name="height">The height of the region to be invalidated.</param>
        //public delegate void glInvalidateSubFramebuffer(uint target, uint numAttachments, uint[] attachments,
        //    int x, int y, uint width, uint height);

        //#endregion

        //#region ARB_multi_draw_indirect

        ///// <summary>
        ///// Render multiple sets of primitives from array data, taking parameters from memory
        ///// </summary>
        ///// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL_POINTS​, GL_LINE_STRIP​, GL_LINE_LOOP​, GL_LINES​, GL_LINE_STRIP_ADJACENCY​, GL_LINES_ADJACENCY​, GL_TRIANGLE_STRIP​, GL_TRIANGLE_FAN​, GL_TRIANGLES​, GL_TRIANGLE_STRIP_ADJACENCY​, GL_TRIANGLES_ADJACENCY​, and GL_PATCHES​ are accepted.</param>
        ///// <param name="indirect">Specifies the address of an array of structures containing the draw parameters.</param>
        ///// <param name="primcount">Specifies the the number of elements in the array of draw parameter structures.</param>
        ///// <param name="stride">Specifies the distance in basic machine units between elements of the draw parameter array.</param>
        //public delegate void glMultiDrawArraysIndirect(uint mode, IntPtr indirect, uint primcount, uint stride);
        ///// <summary>
        ///// Render indexed primitives from array data, taking parameters from memory
        ///// </summary>
        ///// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL_POINTS​, GL_LINE_STRIP​, GL_LINE_LOOP​, GL_LINES​, GL_LINE_STRIP_ADJACENCY​, GL_LINES_ADJACENCY​, GL_TRIANGLE_STRIP​, GL_TRIANGLE_FAN​, GL_TRIANGLES​, GL_TRIANGLE_STRIP_ADJACENCY​, GL_TRIANGLES_ADJACENCY​, and GL_PATCHES​ are accepted.</param>
        ///// <param name="type">Specifies the type of data in the buffer bound to the GL_ELEMENT_ARRAY_BUFFER​ binding.</param>
        ///// <param name="indirect">Specifies a byte offset (cast to a pointer type) into the buffer bound to GL_DRAW_INDIRECT_BUFFER​, which designates the starting point of the structure containing the draw parameters.</param>
        ///// <param name="primcount">Specifies the number of elements in the array addressed by indirect​.</param>
        ///// <param name="stride">Specifies the distance in basic machine units between elements of the draw parameter array.</param>
        //public delegate void glMultiDrawElementsIndirect(uint mode, uint type, IntPtr indirect, uint primcount, uint stride);

        //#endregion

        //#region GL_ARB_program_interface_query

        ///// <summary>
        ///// Query a property of an interface in a program
        ///// </summary>
        ///// <param name="program">The name of a program object whose interface to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ to query.</param>
        ///// <param name="pname">The name of the parameter within programInterface​ to query.</param>
        ///// <param name="parameters">The address of a variable to retrieve the value of pname​ for the program interface..</param>
        //public delegate void glGetProgramInterfaceiv(uint program, uint programInterface, uint pname, int[] parameters);
        ///// <summary>
        ///// Query the index of a named resource within a program
        ///// </summary>
        ///// <param name="program">The name of a program object whose resources to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
        ///// <param name="name">The name of the resource to query the index of.</param>
        //public delegate uint glGetProgramResourceIndex(uint program, uint programInterface, string name);
        ///// <summary>
        ///// Query the name of an indexed resource within a program
        ///// </summary>
        ///// <param name="program">The name of a program object whose resources to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ containing the indexed resource.</param>
        ///// <param name="index">The index of the resource within programInterface​ of program​.</param>
        ///// <param name="bufSize">The size of the character array whose address is given by name​.</param>
        ///// <param name="length">The address of a variable which will receive the length of the resource name.</param>
        ///// <param name="name">The address of a character array into which will be written the name of the resource.</param>
        //public delegate void glGetProgramResourceName(uint program, uint programInterface, uint index, uint bufSize, uint[] length, string[] name);
        ///// <summary>
        ///// Retrieve values for multiple properties of a single active resource within a program object
        ///// </summary>
        ///// <param name="program">The name of a program object whose resources to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
        ///// <param name="index">The index within the programInterface​ to query information about.</param>
        ///// <param name="propCount">The number of properties being queried.</param>
        ///// <param name="props">An array of properties of length propCount​ to query.</param>
        ///// <param name="bufSize">The number of GLint values in the params​ array.</param>
        ///// <param name="length">If not NULL, then this value will be filled in with the number of actual parameters written to params​.</param>
        ///// <param name="parameters">The output array of parameters to write.</param>
        //public delegate void glGetProgramResourceiv(uint program, uint programInterface, uint index, uint propCount, uint[] props, uint bufSize, uint[] length, int[] parameters);
        ///// <summary>
        ///// Query the location of a named resource within a program.
        ///// </summary>
        ///// <param name="program">The name of a program object whose resources to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
        ///// <param name="name">The name of the resource to query the location of.</param>
        //public delegate int glGetProgramResourceLocation(uint program, uint programInterface, string name);
        ///// <summary>
        ///// Query the fragment color index of a named variable within a program.
        ///// </summary>
        ///// <param name="program">The name of a program object whose resources to query.</param>
        ///// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
        ///// <param name="name">The name of the resource to query the location of.</param>
        //public delegate int glGetProgramResourceLocationIndex(uint program, uint programInterface, string name);

        //#endregion

        //#region GL_ARB_shader_storage_buffer_object

        ///// <summary>
        ///// Change an active shader storage block binding.
        ///// </summary>
        ///// <param name="program">The name of the program containing the block whose binding to change.</param>
        ///// <param name="storageBlockIndex">The index storage block within the program.</param>
        ///// <param name="storageBlockBinding">The index storage block binding to associate with the specified storage block.</param>
        //public delegate void glShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);

        //  Constants
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHADER_STORAGE_BUFFER = 0x90D2;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_STORAGE_BUFFER_BINDING = 0x90D3;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_STORAGE_BUFFER_START = 0x90D4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_STORAGE_BUFFER_SIZE = 0x90D5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_SHADER_STORAGE_BLOCKS = 0x90D6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_GEOMETRY_SHADER_STORAGE_BLOCKS = 0x90D7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TESS_CONTROL_SHADER_STORAGE_BLOCKS = 0x90D8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TESS_EVALUATION_SHADER_STORAGE_BLOCKS = 0x90D9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_FRAGMENT_SHADER_STORAGE_BLOCKS = 0x90DA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMPUTE_SHADER_STORAGE_BLOCKS = 0x90DB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_SHADER_STORAGE_BLOCKS = 0x90DC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS = 0x90DD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_SHADER_STORAGE_BLOCK_SIZE = 0x90DE;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_SHADER_STORAGE_BUFFER_OFFSET_ALIGNMENT = 0x90DF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHADER_STORAGE_BARRIER_BIT = 0x2000;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_COMBINED_SHADER_OUTPUT_RESOURCES = 0x8F39;

        //#endregion

        //#region GL_ARB_stencil_texturing

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;

        //#endregion

        //#region GL_ARB_texture_buffer_range

        ///// <summary>
        ///// Bind a range of a buffer's data store to a buffer texture
        ///// </summary>
        ///// <param name="target">Specifies the target of the operation and must be GL_TEXTURE_BUFFER​.</param>
        ///// <param name="internalformat">Specifies the internal format of the data in the store belonging to buffer​.</param>
        ///// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
        ///// <param name="offset">Specifies the offset of the start of the range of the buffer's data store to attach.</param>
        ///// <param name="size">Specifies the size of the range of the buffer's data store to attach.</param>
        //public delegate void glTexBufferRange(uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size);
        ///// <summary>
        ///// Bind a range of a buffer's data store to a buffer texture
        ///// </summary>
        ///// <param name="texture">The texture.</param>
        ///// <param name="target">Specifies the target of the operation and must be GL_TEXTURE_BUFFER​.</param>
        ///// <param name="internalformat">Specifies the internal format of the data in the store belonging to buffer​.</param>
        ///// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
        ///// <param name="offset">Specifies the offset of the start of the range of the buffer's data store to attach.</param>
        ///// <param name="size">Specifies the size of the range of the buffer's data store to attach.</param>
        //public delegate void glTextureBufferRangeEXT(uint texture, uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size);

        //#endregion

        //#region GL_ARB_texture_storage_multisample

        ////  Delegates
        ///// <summary>
        ///// Specify storage for a two-dimensional multisample texture.
        ///// </summary>
        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_2D_MULTISAMPLE​ or GL_PROXY_TEXTURE_2D_MULTISAMPLE​.</param>
        ///// <param name="samples">Specify the number of samples in the texture.</param>
        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
        ///// <param name="width">Specifies the width of the texture, in texels.</param>
        ///// <param name="height">Specifies the height of the texture, in texels.</param>
        ///// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        //public delegate void glTexStorage2DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
        ///// <summary>
        ///// Specify storage for a three-dimensional multisample array texture
        ///// </summary>
        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_3D_MULTISAMPLE_ARRAY​ or GL_PROXY_TEXTURE_3D_MULTISAMPLE_ARRAY​.</param>
        ///// <param name="samples">Specify the number of samples in the texture.</param>
        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
        ///// <param name="width">Specifies the width of the texture, in texels.</param>
        ///// <param name="height">Specifies the height of the texture, in texels.</param>
        ///// <param name="depth">Specifies the depth of the texture, in layers.</param>
        ///// <param name="fixedsamplelocations">Specifies the depth of the texture, in layers.</param>
        //public delegate void glTexStorage3DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
        ///// <summary>
        ///// Specify storage for a two-dimensional multisample texture.
        ///// </summary>
        ///// <param name="texture">The texture.</param>
        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_2D_MULTISAMPLE​ or GL_PROXY_TEXTURE_2D_MULTISAMPLE​.</param>
        ///// <param name="samples">Specify the number of samples in the texture.</param>
        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
        ///// <param name="width">Specifies the width of the texture, in texels.</param>
        ///// <param name="height">Specifies the height of the texture, in texels.</param>
        ///// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        //public delegate void glTexStorage2DMultisampleEXT(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
        ///// <summary>
        ///// Specify storage for a three-dimensional multisample array texture
        ///// </summary>
        ///// <param name="texture">The texture.</param>
        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_3D_MULTISAMPLE_ARRAY​ or GL_PROXY_TEXTURE_3D_MULTISAMPLE_ARRAY​.</param>
        ///// <param name="samples">Specify the number of samples in the texture.</param>
        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
        ///// <param name="width">Specifies the width of the texture, in texels.</param>
        ///// <param name="height">Specifies the height of the texture, in texels.</param>
        ///// <param name="depth">Specifies the depth of the texture, in layers.</param>
        ///// <param name="fixedsamplelocations">Specifies the depth of the texture, in layers.</param>
        //public delegate void glTexStorage3DMultisampleEXT(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);

        //#endregion

        //#region GL_ARB_texture_view

        ////  Delegates
        ///// <summary>
        ///// Initialize a texture as a data alias of another texture's data store.
        ///// </summary>
        ///// <param name="texture">Specifies the texture object to be initialized as a view.</param>
        ///// <param name="target">Specifies the target to be used for the newly initialized texture.</param>
        ///// <param name="origtexture">Specifies the name of a texture object of which to make a view.</param>
        ///// <param name="internalformat">Specifies the internal format for the newly created view.</param>
        ///// <param name="minlevel">Specifies lowest level of detail of the view.</param>
        ///// <param name="numlevels">Specifies the number of levels of detail to include in the view.</param>
        ///// <param name="minlayer">Specifies the index of the first layer to include in the view.</param>
        ///// <param name="numlayers">Specifies the number of layers to include in the view.</param>
        //public delegate void glTextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_VIEW_MIN_LEVEL = 0x82DB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_VIEW_NUM_LEVELS = 0x82DC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_VIEW_MIN_LAYER = 0x82DD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_VIEW_NUM_LAYERS = 0x82DE;

        //#endregion

        //#region GL_ARB_vertex_attrib_binding

        ////  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bindingindex"></param>
        ///// <param name="buffer"></param>
        ///// <param name="offset"></param>
        ///// <param name="stride"></param>
        //public delegate void glBindVertexBuffer(uint bindingindex, uint buffer, IntPtr offset, uint stride);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="normalized"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexAttribFormat(uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="attribindex"></param>
        ///// <param name="bindingindex"></param>
        //public delegate void glVertexAttribBinding(uint attribindex, uint bindingindex);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bindingindex"></param>
        ///// <param name="divisor"></param>
        //public delegate void glVertexBindingDivisor(uint bindingindex, uint divisor);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="bindingindex"></param>
        ///// <param name="buffer"></param>
        ///// <param name="offset"></param>
        ///// <param name="stride"></param>
        //public delegate void glVertexArrayBindVertexBufferEXT(uint vaobj, uint bindingindex, uint buffer, IntPtr offset, uint stride);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="normalized"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexArrayVertexAttribFormatEXT(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexArrayVertexAttribIFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="attribindex"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="relativeoffset"></param>
        //public delegate void glVertexArrayVertexAttribLFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="attribindex"></param>
        ///// <param name="bindingindex"></param>
        //public delegate void glVertexArrayVertexAttribBindingEXT(uint vaobj, uint attribindex, uint bindingindex);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vaobj"></param>
        ///// <param name="bindingindex"></param>
        ///// <param name="divisor"></param>
        //public delegate void glVertexArrayVertexBindingDivisorEXT(uint vaobj, uint bindingindex, uint divisor);

        ////  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_BINDING = 0x82D4;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D5;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_BINDING_DIVISOR = 0x82D6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_BINDING_OFFSET = 0x82D7;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_BINDING_STRIDE = 0x82D8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_VERTEX_BINDING_BUFFER = 0x8F4F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_VERTEX_ATTRIB_BINDINGS = 0x82DA;

        //#endregion


        #region debugging and profiling

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_OUTPUT = 0x92E0;

        // https://www.opengl.org/registry/specs/ARB/debug_output.txt
        // https://www.opengl.org/wiki/Debug_Output
        /// <summary>
        /// 设置Debug模式的回调函数。
        /// </summary>
        /// <param name="callback">使用一个字段来持有
        /// <para>callback = new GL.DEBUGPROC(this.callbackProc);</para>
        /// 这样就可以避免垃圾回收的问题。
        /// </param>
        /// <param name="userParam">建议使用UnmanagedArray.Header</param>
        public delegate void glDebugMessageCallback(DEBUGPROC callback, IntPtr userParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length"></param>
        /// <param name="message"></param>
        /// <param name="userParam"></param>
        public delegate void DEBUGPROC(
            uint source, uint type, uint id, uint severity, int length, StringBuilder message, IntPtr userParam);

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB = 0x8242;

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_API_ARB = 0x8246;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_WINDOW_SYSTEM_ARB = 0x8247;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_SHADER_COMPILER_ARB = 0x8248;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_THIRD_PARTY_ARB = 0x8249;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_APPLICATION_ARB = 0x824A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SOURCE_OTHER_ARB = 0x824B;

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_ERROR_ARB = 0x824C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR_ARB = 0x824D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR_ARB = 0x824E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_PORTABILITY_ARB = 0x824F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_PERFORMANCE_ARB = 0x8250;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_TYPE_OTHER_ARB = 0x8251;

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SEVERITY_HIGH_ARB = 0x9146;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SEVERITY_MEDIUM_ARB = 0x9147;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEBUG_SEVERITY_LOW_ARB = 0x9148;
        //public const uint GL_DEBUG_SEVERITY_NOTIFICATION_ARB = 0x9149;

        /// <summary>
        /// 设置哪些属性的消息能够/不能被传入callback函数。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="severity"></param>
        /// <param name="count"></param>
        /// <param name="ids"></param>
        /// <param name="enabled"></param>
        public delegate void glDebugMessageControl(
            uint source, uint type, uint severity, int count, int[] ids, bool enabled);

        /// <summary>
        /// 用户App或工具用此函数可向Debug流写入一条消息。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="severity"></param>
        /// <param name="length">用-1即可。</param>
        /// <param name="buf"></param>
        public delegate void glDebugMessageInsert(
            uint source, uint type, uint id, uint severity, int length, StringBuilder buf);

        #endregion debugging and profiling



        #region transform feedbacks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="id"></param>
        public delegate void glBindTransformFeedback(uint target, uint id);

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK = 0x8E22;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BINDING = 0x8E25;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public delegate void glIsTransformFeedback(uint id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ids"></param>
        public delegate void glDeleteTransformFeedbacks(int n, uint[] ids);

        /// <summary>
        /// 
        /// </summary>
        public delegate void glPauseTransformFeedback();

        /// <summary>
        /// 
        /// </summary>
        public delegate void glResumeTransformFeedback();

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ATOMIC_COUNTER_BUFFER = 0x92C0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNIFORM_BUFFER = 0x8A11;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="uniformBlockIndex"></param>
        /// <param name="uniformBlockBinding"></param>
        public delegate void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="uniformBlockName"></param>
        /// <returns></returns>
        public delegate uint glGetUniformBlockIndex(uint program, string uniformBlockName);

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_READ_BIT = 0x0001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_WRITE_BIT = 0x0002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_INVALIDATE_RANGE_BIT = 0x0004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_INVALIDATE_BUFFER_BIT = 0x0008;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_FLUSH_EXPLICIT_BIT = 0x0010;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_UNSYNCHRONIZED_BIT = 0x0020;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="id"></param>
        public delegate void glDrawTransformFeedback(uint mode, uint id);

        #endregion transform feedbacks

        #region patch

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="value">Specifies the new value for the parameter given by <paramref name="pname"/>​.</param>
        public delegate void glPatchParameteri(uint pname, int value);

        /// <summary>
        /// specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">Specifies the name of the parameter to set.</param>
        /// <param name="values">Specifies the address of an array containing the new values for the parameter given by <paramref name="pname"/>​.</param>
        public delegate void glPatchParameterfv(uint pname, float[] values);

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PATCH_VERTICES = 0x8E72;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PATCH_DEFAULT_INNER_LEVEL = 0x8E73;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PATCH_DEFAULT_OUTER_LEVEL = 0x8E74;

        #endregion patch

        #region texture

        /// <summary>
        /// bind a level of a texture to an image unit.
        /// </summary>
        /// <param name="unit">Specifies the index of the image unit to which to bind the texture.</param>
        /// <param name="texture">Specifies the name of the texture to bind to the image unit.</param>
        /// <param name="level">Specifies the level of the texture that is to be bound.</param>
        /// <param name="layered">Specifies whether a layered texture binding is to be established.</param>
        /// <param name="layer">If <paramref name="layered"/>​ is false, specifies the layer of texture​ to be bound to the image unit. Ignored otherwise.</param>
        /// <param name="access">Specifies a token indicating the type of access that will be performed on the image.</param>
        /// <param name="format">Specifies the format that the elements of the image will be treated as for the purposes of formatted stores.</param>
        public delegate void glBindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        public delegate void glTexStorage1D(uint target, int levels, uint internalformat, int width);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public delegate void glTexStorage2D(uint target, int levels, uint internalformat, int width, int height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="levels"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        public delegate void glTexStorage3D(uint target, int levels, uint internalformat, int width, int height, int depth);

        #endregion texture

        /// <summary>
        /// defines a barrier ordering memory transactions
        /// </summary>
        /// <param name="barriers">Specifies the barriers to insert.</param>
        public delegate void glMemoryBarrier(uint barriers);

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ELEMENT_ARRAY_BARRIER_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNIFORM_BARRIER_BIT = 0x00000004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_FETCH_BARRIER_BIT = 0x00000008;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHADER_IMAGE_ACCESS_BARRIER_BIT = 0x00000020;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMMAND_BARRIER_BIT = 0x00000040;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_BUFFER_BARRIER_BIT = 0x00000080;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_UPDATE_BARRIER_BIT = 0x00000100;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BUFFER_UPDATE_BARRIER_BIT = 0x00000200;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRAMEBUFFER_BARRIER_BIT = 0x00000400;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_FEEDBACK_BARRIER_BIT = 0x00000800;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ATOMIC_COUNTER_BARRIER_BIT = 0x00001000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUERY_BUFFER_BARRIER_BIT = 0x00008000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT = 0x00004000;


        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F;


        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_HALF_FLOAT = 0x140B;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_STENCIL = 0x84F9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH32F_STENCIL8 = 0x8CAD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_RGB10_A2UI = 0x906F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT32F = 0x8CAC;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH24_STENCIL8 = 0x88F0;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB = 0x8E8F;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB = 0x8E8E;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_RGBA_BPTC_UNORM_ARB = 0x8E8C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB = 0x8E8D;

        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SWIZZLE_R = 0x8E42;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SWIZZLE_G = 0x8E43;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SWIZZLE_B = 0x8E44;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SWIZZLE_A = 0x8E45;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_SWIZZLE_RGBA = 0x8E46;

    }
}
