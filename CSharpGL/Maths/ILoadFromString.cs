﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Load an instance from string.
    /// </summary>
    public interface ILoadFromString
    {
        /// <summary>
        /// Load an instance from string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Load(string value);
    }
}
