﻿using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class CatesianGrid : IBufferable
    {
        private CatesianGridderSource dataSource;
        private List<GridBlockProperty> gridProps;
        private int defaultBlockPropertyIndex;

        public float MinColorCode { get; set; }

        public float MaxColorCode { get; set; }

        public CatesianGrid(CatesianGridderSource dataSource, List<GridBlockProperty> gridProps,
            float minColorCode, float maxColorCode, int defaultBlockPropertyIndex = 0)
        {
            this.dataSource = dataSource;
            this.gridProps = gridProps;
            this.MinColorCode = minColorCode;
            this.MaxColorCode = maxColorCode;
            this.defaultBlockPropertyIndex = defaultBlockPropertyIndex;
        }

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.propertyBufferPtr == null)
                {
                    this.propertyBufferPtr = this.GetPositionBufferPtr(varNameInShader);
                }
                return this.propertyBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    this.colorBufferPtr = this.GetColorBufferPtr(varNameInShader);
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                this.indexBufferPtr = this.GetIndexBufferPtr();
            }

            return this.indexBufferPtr;
        }

    }
}
