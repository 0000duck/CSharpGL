﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    /// <summary>
    /// Shader里的字段
    /// uniform vec3 modelMatrix;
    /// in vec3 in_Position;
    /// </summary>
    class ShaderField : ICloneable
    {

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name);
        }

        public object Clone()
        {
            ShaderField result = new ShaderField();

            return result;
        }
    }
}
