﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Renderer
    {

        public DrawMode Mode
        {
            get
            {
                IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
                if (indexBufferPtr != null)
                {
                    return indexBufferPtr.Mode;
                }
                else
                {
                    throw new Exception("Index Buffer Not Initialized!");
                    //return CSharpGL.DrawMode.Points;
                }
            }
            set
            {
                IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
                if (indexBufferPtr != null)
                {
                    indexBufferPtr.Mode = value;
                }
                else
                {
                    throw new Exception("Index Buffer Not Initialized!");
                }
            }
        }

        public GLSwitchList SwitchList
        {
            get { return switchList; }
        }

        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        public List<UniformVariable> UniformVariables
        {
            get { return uniformVariables; }
        }

        public IndexBufferPtr IndexBufferPtr
        {
            get
            {
                return this.indexBufferPtr;
            }
        }

    }
}
