﻿using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region ITreeNode

        public SceneObject Self { get { return this; } }

        public SceneObject Parent { get; set; }

        public IList<SceneObject> Children { get; private set; }

        #endregion ITreeNode

    }
}
