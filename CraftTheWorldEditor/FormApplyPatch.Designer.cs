namespace CraftTheWorldEditor
{
    partial class FormApplyPatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPatch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.btnPatchFile = new System.Windows.Forms.Button();
            this.lblPatchFile = new System.Windows.Forms.Label();
            this.btnDataFile = new System.Windows.Forms.Button();
            this.lblDataFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPatch
            // 
            this.btnPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatch.Location = new System.Drawing.Point(320, 296);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(80, 28);
            this.btnPatch.TabIndex = 0;
            this.btnPatch.Text = "Patch!";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.IntegralHeight = false;
            this.lbxLog.ItemHeight = 19;
            this.lbxLog.Location = new System.Drawing.Point(12, 114);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(474, 167);
            this.lbxLog.TabIndex = 1;
            // 
            // btnPatchFile
            // 
            this.btnPatchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatchFile.Location = new System.Drawing.Point(443, 25);
            this.btnPatchFile.Name = "btnPatchFile";
            this.btnPatchFile.Size = new System.Drawing.Size(43, 23);
            this.btnPatchFile.TabIndex = 2;
            this.btnPatchFile.Text = "...";
            this.btnPatchFile.UseVisualStyleBackColor = true;
            this.btnPatchFile.Click += new System.EventHandler(this.btnPatchFile_Click);
            // 
            // lblPatchFile
            // 
            this.lblPatchFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatchFile.AutoEllipsis = true;
            this.lblPatchFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPatchFile.Location = new System.Drawing.Point(12, 25);
            this.lblPatchFile.Name = "lblPatchFile";
            this.lblPatchFile.Size = new System.Drawing.Size(425, 23);
            this.lblPatchFile.TabIndex = 3;
            this.lblPatchFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDataFile
            // 
            this.btnDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataFile.Location = new System.Drawing.Point(443, 72);
            this.btnDataFile.Name = "btnDataFile";
            this.btnDataFile.Size = new System.Drawing.Size(43, 23);
            this.btnDataFile.TabIndex = 2;
            this.btnDataFile.Text = "...";
            this.btnDataFile.UseVisualStyleBackColor = true;
            this.btnDataFile.Click += new System.EventHandler(this.btnDataFile_Click);
            // 
            // lblDataFile
            // 
            this.lblDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataFile.AutoEllipsis = true;
            this.lblDataFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataFile.Location = new System.Drawing.Point(12, 72);
            this.lblDataFile.Name = "lblDataFile";
            this.lblDataFile.Size = new System.Drawing.Size(425, 23);
            this.lblDataFile.TabIndex = 3;
            this.lblDataFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Patch Datei";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Daten Datei";
            // 
            // FormApplyPatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(498, 336);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDataFile);
            this.Controls.Add(this.btnDataFile);
            this.Controls.Add(this.lblPatchFile);
            this.Controls.Add(this.btnPatchFile);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(514, 375);
            this.Name = "FormApplyPatch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patch anwenden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Button btnPatchFile;
        private System.Windows.Forms.Label lblPatchFile;
        private System.Windows.Forms.Button btnDataFile;
        private System.Windows.Forms.Label lblDataFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}