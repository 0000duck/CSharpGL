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
    public class ShaderField : ICloneable
    {
        const string strQualifier = "Qualifier";
        public FieldQualifier Qualider { get; set; }

        const string strFieldType = "FieldType";
        public string FieldType { get; set; }

        const string strFieldName = "FieldName";
        public string FieldName { get; set; }

        const string strPropertyType = "PropertyType";
        public PropertyType PropertyType { get; set; }

        public ShaderField()
        {
            this.PropertyType = CSSLGenetator.PropertyType.Other;
        }

        public override string ToString()
        {
            return string.Format("{3}{0} {1} {2};", Qualider.GetString(), FieldType, FieldName,
                PropertyType == CSSLGenetator.PropertyType.Other ? "" : "(" + PropertyType + ")");
        }

        public static ShaderField Parse(XElement element)
        {
            if (element.Name != typeof(ShaderField).Name) { throw new NotImplementedException(); }

            ShaderField result = new ShaderField();
            result.Qualider = (FieldQualifier)Enum.Parse(typeof(FieldQualifier), element.Attribute(strQualifier).Value);
            result.FieldType = element.Attribute(strFieldType).Value;
            result.FieldName = element.Attribute(strFieldName).Value;
            result.PropertyType = (PropertyType)Enum.Parse(typeof(PropertyType), element.Attribute(strPropertyType).Value);

            return result;
        }
        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                new XAttribute(strPropertyType, PropertyType),
                new XAttribute(strQualifier, Qualider),
                new XAttribute(strFieldType, FieldType),
                new XAttribute(strFieldName, FieldName)
                );
        }

        public object Clone()
        {
            ShaderField result = new ShaderField();
            result.Qualider = this.Qualider;
            result.FieldType = this.FieldType;
            result.FieldName = this.FieldName;
            result.PropertyType = this.PropertyType;

            return result;
        }

    }

    public static class QualifierHelper
    {
        public static string GetString(this FieldQualifier qualifier)
        {
            string result = string.Empty;
            switch (qualifier)
            {
                case FieldQualifier.In:
                    result = "in";
                    break;
                case FieldQualifier.Out:
                    result = "out";
                    break;
                case FieldQualifier.Uniform:
                    result = "uniform";
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }

    public enum FieldQualifier
    {
        In,
        Out,
        Uniform,
    }

    public enum PropertyType
    {
        Position,
        Color,
        Normal,
        Other,
    }
}
