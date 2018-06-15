using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace CraftTheWorldEditor.PropGridEditors
{
    internal class CollectionUITypeEditor<TItem> : UITypeEditor
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

            ICollection collection = (ICollection)value;
            using (CollectionEditor dialog = new CollectionEditor(collection))
            {
                dialog.Text = context.PropertyDescriptor.DisplayName ?? context.PropertyDescriptor.Name;
                m_editorService.ShowDialog(dialog);
            }

            return value;
        }

        #endregion
    }
}