﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public class CharacterInfo
    {
        public static readonly CharacterInfo Default = new CharacterInfo(0, 0, 0, 0);

        /// <summary>
        /// 此字符的字形在纹理的横向偏移量（左上角）
        /// </summary>
        public int xoffset;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（左上角）
        /// </summary>
        public int yoffset;

        /// <summary>
        /// 此字符的字形宽度
        /// </summary>
        public int width;

        /// <summary>
        /// 此字符的字形高度
        /// </summary>
        public int height;

        public CharacterInfo(int xoffset, int yoffset, int width, int height)
        {
            this.xoffset = xoffset;
            this.yoffset = yoffset;
            this.width = width;
            this.height = height;
        }

        //public CharacterInfo() { }


        public override string ToString()
        {
            return string.Format("{0}offset:{1}, {2}; size:{3}, {4};",
                "", xoffset, yoffset, width, height);
        }
    }
}
