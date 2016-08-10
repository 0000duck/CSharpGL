﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    /// <summary>
    /// data structure of Renderer.
    /// </summary>
    class DataStructure
    {
        private List<VertexProperty> propertyList = new List<VertexProperty>();

        public string TargetName { get; set; }

        public DataStructure(string targetName)
        {
            this.TargetName = targetName;
        }

        internal List<VertexProperty> PropertyList
        {
            get { return propertyList; }
        }


    }
}
