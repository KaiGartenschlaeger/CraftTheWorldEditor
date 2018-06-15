using System.Windows.Forms;

namespace CraftTheWorldEditor
{
    public partial class FormCraftResource : Form
    {
        public FormCraftResource(ResourceItem item)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = item;
        }
    }
}