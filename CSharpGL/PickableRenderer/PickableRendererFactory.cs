﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 根据<see cref="IndexBufferPtr"/>的具体类型获取一个<see cref="PickableRenderer"/>
    /// </summary>
    public static class PickableRendererFactory
    {
        /// <summary>
        /// 根据<see cref="IndexBufferPtr"/>的具体类型获取一个<see cref="PickableRenderer"/>
        /// </summary>
        /// <param name="bufferable"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        /// <returns></returns>
        public static PickableRenderer GetRenderer(
            this IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (bufferable == null || shaderCodes == null || propertyNameMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();
            if (indexBufferPtr is ZeroIndexBufferPtr)
            {
                return new ZeroIndexRenderer(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches);
            }
            else if (indexBufferPtr is OneIndexBufferPtr)
            {
                return new OneIndexRenderer(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches);
            }
            else
            { throw new NotImplementedException(); }
        }
    }
}
