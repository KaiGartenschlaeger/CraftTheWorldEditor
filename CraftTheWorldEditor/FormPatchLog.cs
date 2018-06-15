using System.Windows.Forms;

namespace CraftTheWorldEditor
{
    public partial class FormPatchLog : Form
    {
        #region Constructor

        public FormPatchLog()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void Add(string message)
        {
            listBox1.Items.Add(message);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        #endregion

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public bool AllowClose
        {
            get { return btnClose.Enabled; }
            set { btnClose.Enabled = value; }
        }
    }
}