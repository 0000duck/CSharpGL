﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    partial class FormIListEditor<T> : Form
    {

        IList<T> list;

        public FormIListEditor(IList<T> list)
        {
            InitializeComponent();

            if (list != null)
            {
                foreach (var item in list)
                {
                    this.lstMember.Items.Add(item);
                }

                this.list = list;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmSelectType = new FormSelectType(typeof(T));
            if (frmSelectType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Type type = frmSelectType.SelectedType;
                T obj = (T)Activator.CreateInstance(type);
                this.lstMember.Items.Add(obj);
                this.list.Add(obj);
                this.propertyGrid.SelectedObject = obj;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = this.lstMember.SelectedIndex;
            if (index >= 0)
            {
                this.lstMember.Items.RemoveAt(index);
                this.list.RemoveAt(index);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lstMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.lstMember.SelectedItem;
            this.propertyGrid.SelectedObject = obj;
            this.lblProperty.Text = string.Format("{0}", obj);
        }

    }
}
