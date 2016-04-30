﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 用glDrarArrays进行渲染。
    /// </summary>
    public partial class ZeroIndexModernRenderer : PickableModernRenderer
    {
        protected ZeroIndexBufferPtr zeroIndexBufferPtr;

        /// <summary>
        /// 用glDrarArrays进行渲染。
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal ZeroIndexModernRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            this.Name = this.GetType().Name;

        }

        protected override void DoInitialize()
        {
            // init index buffer 
            this.zeroIndexBufferPtr = this.bufferable.GetIndex() as ZeroIndexBufferPtr;
            if (this.zeroIndexBufferPtr == null) { throw new Exception(); }

            base.DoInitialize();
        }

        protected override IndexBufferPtr GetIndexBufferPtr()
        {
            return this.zeroIndexBufferPtr;
        }
    }
}
