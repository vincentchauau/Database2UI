namespace Database2UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.scSplitter1 = new System.Windows.Forms.SplitContainer();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.dtgvTable = new System.Windows.Forms.DataGridView();
            this.scSplitter2 = new System.Windows.Forms.SplitContainer();
            this.tlpTable = new System.Windows.Forms.TableLayoutPanel();
            this.btPick = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btGet = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.btSet = new System.Windows.Forms.Button();
            this.dtgvPick = new System.Windows.Forms.DataGridView();
            this.cbPickTables = new System.Windows.Forms.ComboBox();
            this.btPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scSplitter1)).BeginInit();
            this.scSplitter1.Panel1.SuspendLayout();
            this.scSplitter1.Panel2.SuspendLayout();
            this.scSplitter1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scSplitter2)).BeginInit();
            this.scSplitter2.Panel1.SuspendLayout();
            this.scSplitter2.Panel2.SuspendLayout();
            this.scSplitter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPick)).BeginInit();
            this.SuspendLayout();
            // 
            // scSplitter1
            // 
            this.scSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSplitter1.Location = new System.Drawing.Point(0, 0);
            this.scSplitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scSplitter1.Name = "scSplitter1";
            // 
            // scSplitter1.Panel1
            // 
            this.scSplitter1.Panel1.Controls.Add(this.cbTables);
            this.scSplitter1.Panel1.Controls.Add(this.dtgvTable);
            // 
            // scSplitter1.Panel2
            // 
            this.scSplitter1.Panel2.Controls.Add(this.scSplitter2);
            this.scSplitter1.Size = new System.Drawing.Size(1260, 656);
            this.scSplitter1.SplitterDistance = 364;
            this.scSplitter1.SplitterWidth = 7;
            this.scSplitter1.TabIndex = 0;
            // 
            // cbTables
            // 
            this.cbTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(4, 3);
            this.cbTables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(356, 28);
            this.cbTables.TabIndex = 1;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // dtgvTable
            // 
            this.dtgvTable.AllowUserToAddRows = false;
            this.dtgvTable.AllowUserToDeleteRows = false;
            this.dtgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTable.Location = new System.Drawing.Point(4, 34);
            this.dtgvTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvTable.Name = "dtgvTable";
            this.dtgvTable.ReadOnly = true;
            this.dtgvTable.RowTemplate.Height = 24;
            this.dtgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTable.Size = new System.Drawing.Size(360, 617);
            this.dtgvTable.TabIndex = 0;
            this.dtgvTable.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgvTable_RowStateChanged);
            this.dtgvTable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgvTable_KeyUp);
            // 
            // scSplitter2
            // 
            this.scSplitter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSplitter2.Location = new System.Drawing.Point(0, 0);
            this.scSplitter2.Name = "scSplitter2";
            // 
            // scSplitter2.Panel1
            // 
            this.scSplitter2.Panel1.Controls.Add(this.btPrint);
            this.scSplitter2.Panel1.Controls.Add(this.tlpTable);
            this.scSplitter2.Panel1.Controls.Add(this.btPick);
            this.scSplitter2.Panel1.Controls.Add(this.btClear);
            this.scSplitter2.Panel1.Controls.Add(this.btGet);
            this.scSplitter2.Panel1.Controls.Add(this.btCreate);
            this.scSplitter2.Panel1.Controls.Add(this.btSet);
            // 
            // scSplitter2.Panel2
            // 
            this.scSplitter2.Panel2.Controls.Add(this.dtgvPick);
            this.scSplitter2.Panel2.Controls.Add(this.cbPickTables);
            this.scSplitter2.Size = new System.Drawing.Size(889, 656);
            this.scSplitter2.SplitterDistance = 440;
            this.scSplitter2.TabIndex = 6;
            // 
            // tlpTable
            // 
            this.tlpTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTable.ColumnCount = 2;
            this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTable.Location = new System.Drawing.Point(4, 34);
            this.tlpTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpTable.Name = "tlpTable";
            this.tlpTable.RowCount = 1;
            this.tlpTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTable.Size = new System.Drawing.Size(432, 617);
            this.tlpTable.TabIndex = 0;
            // 
            // btPick
            // 
            this.btPick.Location = new System.Drawing.Point(283, 3);
            this.btPick.Name = "btPick";
            this.btPick.Size = new System.Drawing.Size(50, 28);
            this.btPick.TabIndex = 6;
            this.btPick.Text = "Pick";
            this.btPick.UseVisualStyleBackColor = true;
            this.btPick.Click += new System.EventHandler(this.btPick_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(4, 3);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(61, 28);
            this.btClear.TabIndex = 1;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(71, 3);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(61, 28);
            this.btGet.TabIndex = 2;
            this.btGet.Text = "Get";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(205, 3);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(72, 28);
            this.btCreate.TabIndex = 5;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btSet
            // 
            this.btSet.Location = new System.Drawing.Point(138, 3);
            this.btSet.Name = "btSet";
            this.btSet.Size = new System.Drawing.Size(61, 28);
            this.btSet.TabIndex = 3;
            this.btSet.Text = "Set";
            this.btSet.UseVisualStyleBackColor = true;
            this.btSet.Click += new System.EventHandler(this.btSet_Click);
            // 
            // dtgvPick
            // 
            this.dtgvPick.AllowUserToAddRows = false;
            this.dtgvPick.AllowUserToDeleteRows = false;
            this.dtgvPick.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvPick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgvPick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPick.Location = new System.Drawing.Point(4, 34);
            this.dtgvPick.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvPick.Name = "dtgvPick";
            this.dtgvPick.ReadOnly = true;
            this.dtgvPick.RowTemplate.Height = 24;
            this.dtgvPick.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPick.Size = new System.Drawing.Size(437, 617);
            this.dtgvPick.TabIndex = 6;
            this.dtgvPick.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgvPick_KeyUp);
            // 
            // cbPickTables
            // 
            this.cbPickTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPickTables.FormattingEnabled = true;
            this.cbPickTables.Location = new System.Drawing.Point(4, 3);
            this.cbPickTables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPickTables.Name = "cbPickTables";
            this.cbPickTables.Size = new System.Drawing.Size(437, 28);
            this.cbPickTables.TabIndex = 7;
            this.cbPickTables.SelectedIndexChanged += new System.EventHandler(this.cbPickTables_SelectedIndexChanged);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(339, 3);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(56, 28);
            this.btPrint.TabIndex = 7;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1260, 656);
            this.Controls.Add(this.scSplitter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database 2 UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.scSplitter1.Panel1.ResumeLayout(false);
            this.scSplitter1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSplitter1)).EndInit();
            this.scSplitter1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTable)).EndInit();
            this.scSplitter2.Panel1.ResumeLayout(false);
            this.scSplitter2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSplitter2)).EndInit();
            this.scSplitter2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scSplitter1;
        private System.Windows.Forms.DataGridView dtgvTable;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.TableLayoutPanel tlpTable;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btSet;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.SplitContainer scSplitter2;
        private System.Windows.Forms.DataGridView dtgvPick;
        private System.Windows.Forms.Button btPick;
        private System.Windows.Forms.ComboBox cbPickTables;
        private System.Windows.Forms.Button btPrint;
    }
}

