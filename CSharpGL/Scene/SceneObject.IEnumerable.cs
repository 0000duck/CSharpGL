﻿using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region IEnumerable<SceneObject>

        public IEnumerator<SceneObject> GetEnumerator()
        {
            var enumerable = ITreeNodeHelper.EnumerateRecursively(this);
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion IEnumerable<SceneObject>

    }
}
