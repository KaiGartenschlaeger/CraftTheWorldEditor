using System;
using System.Windows.Forms;

namespace CraftTheWorldEditor.PropGridEditors
{
    public partial class MultilineTextEditor : Form
    {
        public MultilineTextEditor()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}