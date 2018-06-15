using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CraftTheWorldEditor.PropGridEditors
{
    public partial class CollectionEditor : Form
    {
        #region Fields

        private SortedDictionary<string, object> m_items;

        #endregion

        #region Constructor

        public CollectionEditor(ICollection collection)
        {
            InitializeComponent();

            m_items = new SortedDictionary<string, object>();
            foreach (var item in collection)
            {
                m_items.Add(item.ToString(), item);
            }

            RefreshFilter();
        }

        #endregion

        #region Helper

        private void RefreshFilter()
        {
            propertyGrid1.SelectedObject = null;

            lbxItems.BeginUpdate();
            lbxItems.Items.Clear();

            foreach (var item in m_items)
            {
                if (string.IsNullOrEmpty(tbxFilter.Text)
                    || item.Key.IndexOf(tbxFilter.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    lbxItems.Items.Add(item.Value);
                }
            }

            lbxItems.EndUpdate();
        }

        #endregion

        #region Control events

        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = lbxItems.SelectedItem;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
