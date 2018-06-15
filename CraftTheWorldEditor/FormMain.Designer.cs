namespace CraftTheWorldEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvwCraftResources = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxItemSearch = new System.Windows.Forms.TextBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApplyPatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(606, 521);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 28);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Öffnen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(692, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvwCraftResources
            // 
            this.lvwCraftResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCraftResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwCraftResources.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCraftResources.FullRowSelect = true;
            this.lvwCraftResources.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCraftResources.HideSelection = false;
            this.lvwCraftResources.Location = new System.Drawing.Point(12, 24);
            this.lvwCraftResources.Name = "lvwCraftResources";
            this.lvwCraftResources.Size = new System.Drawing.Size(760, 300);
            this.lvwCraftResources.TabIndex = 2;
            this.lvwCraftResources.UseCompatibleStateImageBehavior = false;
            this.lvwCraftResources.View = System.Windows.Forms.View.Details;
            this.lvwCraftResources.VirtualMode = true;
            this.lvwCraftResources.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwCraftResources_RetrieveVirtualItem);
            this.lvwCraftResources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwCraftResources_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Gruppe";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Preis";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Anzahl";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Eigenschaften";
            this.columnHeader4.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gegenstände";
            // 
            // tbxItemSearch
            // 
            this.tbxItemSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxItemSearch.Location = new System.Drawing.Point(12, 330);
            this.tbxItemSearch.Name = "tbxItemSearch";
            this.tbxItemSearch.Size = new System.Drawing.Size(760, 20);
            this.tbxItemSearch.TabIndex = 4;
            this.tbxItemSearch.TextChanged += new System.EventHandler(this.tbxItemSearch_TextChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(12, 378);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(760, 129);
            this.propertyGrid1.TabIndex = 5;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Einstellungen";
            // 
            // btnApplyPatch
            // 
            this.btnApplyPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyPatch.Location = new System.Drawing.Point(12, 521);
            this.btnApplyPatch.Name = "btnApplyPatch";
            this.btnApplyPatch.Size = new System.Drawing.Size(80, 28);
            this.btnApplyPatch.TabIndex = 0;
            this.btnApplyPatch.Text = "Patch";
            this.btnApplyPatch.UseVisualStyleBackColor = true;
            this.btnApplyPatch.Click += new System.EventHandler(this.btnApplyPatch_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.tbxItemSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwCraftResources);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnApplyPatch);
            this.Controls.Add(this.btnOpen);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Craft the World - Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvwCraftResources;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tbxItemSearch;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApplyPatch;
    }
}

