﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    abstract class ZeroIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArg arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer);
        
    }
}
