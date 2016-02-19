﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    class FieldStructureList : List<FieldStructure>,ICloneable
    {

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name);
        }

        internal static FieldStructureList Parse(XElement xElement)
        {
            if (xElement.Name != typeof(FieldStructureList).Name) { throw new Exception(); }

            return new FieldStructureList();
        }

        public object Clone()
        {
            FieldStructureList list = new FieldStructureList();

            return list;
        }
    }
}
