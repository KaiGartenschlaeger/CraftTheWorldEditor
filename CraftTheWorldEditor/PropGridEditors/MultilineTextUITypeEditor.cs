using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CraftTheWorldEditor.PropGridEditors
{
    public class MultilineTextUITypeEditor : UITypeEditor
    {
        #region Fields

        private IWindowsFormsEditorService m_editorService;

        #endregion

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            m_editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            using (MultilineTextEditor dialog = new MultilineTextEditor())
            {
                dialog.Text = context.PropertyDescriptor.DisplayName ?? context.PropertyDescriptor.Name;
                dialog.tbxText.Text = value as string;

                if (m_editorService.ShowDialog(dialog) == DialogResult.OK)
                {
                    return dialog.tbxText.Text;
                }
            }

            return value;
        }

        #endregion
    }
}