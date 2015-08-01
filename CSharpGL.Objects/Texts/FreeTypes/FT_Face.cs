﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts.FreeTypes
{
    /// <summary>
    /// 一个TTF文件里的字形会被转换为Face。Face就是一个TTF里字形的集合。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FT_Face
    {
        public int num_faces;
        public int face_index;
        public int face_flags;
        public int style_flags;
        public int num_glyphs;
        public string family_name;
        public string style_name;
        public int num_fixed_sizes;
        public System.IntPtr available_sizes;
        public int num_charmaps;
        public System.IntPtr charmaps;
        public Generic generic;
        public BBox box;
        public ushort units_per_EM;
        public short ascender;
        public short descender;
        public short height;
        public short max_advance_width;
        public short max_advance_height;
        public short underline_position;
        public short underline_tickness;
        public System.IntPtr glyphrec;
        public System.IntPtr size;
        public System.IntPtr charmap;
        public System.IntPtr driver;
        public System.IntPtr memory;
        public System.IntPtr stream;
        public ListRec sizes_list;
        public Generic autohint;
        public System.IntPtr extensions;
        public System.IntPtr internal_face;

    }
}
