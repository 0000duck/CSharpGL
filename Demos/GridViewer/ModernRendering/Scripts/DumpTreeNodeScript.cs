﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridViewer
{
    public class DumpTreeNodeScript : Script
    {

        public virtual TreeNode DumpTreeNode()
        {
            SceneObject obj = this.BindingObject;
            var node = new TreeNode(string.Format("{0}", obj));
            node.Tag = obj;
            return node;
        }
    }
}
