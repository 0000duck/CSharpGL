﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class PropertyTreeNode : TreeNode
    {
        private ScientificModelScriptComponent scriptComponent;
        public PropertyTreeNode(ScientificModelScriptComponent scriptComponent)
        {
            this.scriptComponent = scriptComponent;
        }

        public void Select()
        {
            this.scriptComponent.Show();
        }
    }
}
