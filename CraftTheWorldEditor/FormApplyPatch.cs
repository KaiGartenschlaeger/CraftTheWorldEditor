using System;
using System.Windows.Forms;

namespace CraftTheWorldEditor
{
    public partial class FormApplyPatch : Form
    {
        #region Constructor

        public FormApplyPatch()
        {
            InitializeComponent();
            RefreshButton();
        }

        #endregion

        #region Helper

        private void ChoosePatch(Label pathControl, string title, string filter, string filePath)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = title;
                dialog.Filter = filter;

                if (!string.IsNullOrEmpty(filePath))
                {
                    dialog.FileName = filePath;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    pathControl.Text = dialog.FileName;
                    RefreshButton();
                }
            }
        }

        private void RefreshButton()
        {
            btnPatch.Enabled = !string.IsNullOrEmpty(lblPatchFile.Text) && !string.IsNullOrEmpty(lblDataFile.Text);
        }

        private void AddToLog(string message)
        {
            lbxLog.Items.Add(message);
            lbxLog.SelectedIndex = lbxLog.Items.Count - 1;
        }

        #endregion

        #region Control events

        private void btnPatchFile_Click(object sender, EventArgs e)
        {
            ChoosePatch(lblPatchFile, "Patch-Datei wählen", "Patch-Datei|*.xml", lblPatchFile.Text);
        }

        private void btnDataFile_Click(object sender, EventArgs e)
        {
            ChoosePatch(lblDataFile, "Daten-Datei wählen", "Daten-Datei|*.pak", lblDataFile.Text);
        }

        private async void btnPatch_Click(object sender, EventArgs e)
        {
            btnPatch.Enabled = false;
            lbxLog.Items.Clear();

            PatchProcess process = new PatchProcess(lblPatchFile.Text, lblDataFile.Text);
            var progress = new Progress<string>((message) =>
            {
                AddToLog(message);
            });

            await process.PatchAsync(progress);

            btnPatch.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}