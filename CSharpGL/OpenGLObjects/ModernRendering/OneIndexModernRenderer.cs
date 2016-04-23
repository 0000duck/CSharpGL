﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexModernRenderer : ModernRenderer
    {
        protected OneIndexBufferPtr oneIndexBufferPtr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="VertexBufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal OneIndexModernRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
        }

        protected override void DoInitialize()
        {
            // init index buffer object's renderer
            this.oneIndexBufferPtr = this.bufferable.GetIndex() as OneIndexBufferPtr;
            if (this.oneIndexBufferPtr == null) { throw new Exception(); }

            base.DoInitialize();
        }

        protected override void DisposeUnmanagedResources()
        {
            if (this.oneIndexBufferPtr != null)
            {
                this.oneIndexBufferPtr.Dispose();
                this.oneIndexBufferPtr = null;
            }

            base.DisposeUnmanagedResources();
        }

        protected override IndexBufferPtr indexBufferPtr
        {
            get { return this.oneIndexBufferPtr; }
        }

        private int mapBufferRangeLength = 2 * 2 * 2 * 2 * 3 * 3 * 3 * 3 * 10;

        public int MapBufferRangeLength
        {
            get { return mapBufferRangeLength; }
            set
            {
                if (value < sizeof(uint) * 4)
                {
                    mapBufferRangeLength = sizeof(uint) * 4;
                }
                else
                {
                    mapBufferRangeLength = value;
                }
            }
        }
    }
}
