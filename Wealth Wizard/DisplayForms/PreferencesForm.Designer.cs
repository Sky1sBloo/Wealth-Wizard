namespace Wealth_Wizard
{
    partial class PreferencesForm
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
            this.components = new System.ComponentModel.Container();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GroupB_OnStart = new System.Windows.Forms.GroupBox();
            this.Btn_BrowseDatabase = new System.Windows.Forms.Button();
            this.TxtB_DefaultDatabase = new System.Windows.Forms.TextBox();
            this.Lbl_DefaultDatabase = new System.Windows.Forms.Label();
            this.GroupB_EntryTypes = new System.Windows.Forms.GroupBox();
            this.Lbl_Notice = new System.Windows.Forms.Label();
            this.ListB_EntryTypes = new System.Windows.Forms.ListBox();
            this.Btn_AddEntryType = new System.Windows.Forms.Button();
            this.Btn_DeleteEntryType = new System.Windows.Forms.Button();
            this.Btn_EditEntryType = new System.Windows.Forms.Button();
            this.TabController = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GroupB_Excel = new System.Windows.Forms.GroupBox();
            this.Num_StartingCellY = new System.Windows.Forms.NumericUpDown();
            this.Num_StartingCellX = new System.Windows.Forms.NumericUpDown();
            this.Lbl_StartingCell = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.ToolTip_StartingInfo = new System.Windows.Forms.ToolTip(this.components);
            this.Lbl_SheetName = new System.Windows.Forms.Label();
            this.TxtB_SheetName = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            this.GroupB_OnStart.SuspendLayout();
            this.GroupB_EntryTypes.SuspendLayout();
            this.TabController.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GroupB_Excel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingCellY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingCellX)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.GroupB_OnStart);
            this.tabPage1.Controls.Add(this.GroupB_EntryTypes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupB_OnStart
            // 
            this.GroupB_OnStart.Controls.Add(this.Btn_BrowseDatabase);
            this.GroupB_OnStart.Controls.Add(this.TxtB_DefaultDatabase);
            this.GroupB_OnStart.Controls.Add(this.Lbl_DefaultDatabase);
            this.GroupB_OnStart.Location = new System.Drawing.Point(4, 3);
            this.GroupB_OnStart.Name = "GroupB_OnStart";
            this.GroupB_OnStart.Size = new System.Drawing.Size(564, 65);
            this.GroupB_OnStart.TabIndex = 9;
            this.GroupB_OnStart.TabStop = false;
            this.GroupB_OnStart.Text = "On Start";
            // 
            // Btn_BrowseDatabase
            // 
            this.Btn_BrowseDatabase.Location = new System.Drawing.Point(474, 19);
            this.Btn_BrowseDatabase.Name = "Btn_BrowseDatabase";
            this.Btn_BrowseDatabase.Size = new System.Drawing.Size(75, 23);
            this.Btn_BrowseDatabase.TabIndex = 3;
            this.Btn_BrowseDatabase.Text = "Browse";
            this.Btn_BrowseDatabase.UseVisualStyleBackColor = true;
            this.Btn_BrowseDatabase.Click += new System.EventHandler(this.Btn_BrowseDatabase_Click);
            // 
            // TxtB_DefaultDatabase
            // 
            this.TxtB_DefaultDatabase.Location = new System.Drawing.Point(115, 19);
            this.TxtB_DefaultDatabase.Name = "TxtB_DefaultDatabase";
            this.TxtB_DefaultDatabase.Size = new System.Drawing.Size(353, 20);
            this.TxtB_DefaultDatabase.TabIndex = 2;
            // 
            // Lbl_DefaultDatabase
            // 
            this.Lbl_DefaultDatabase.AutoSize = true;
            this.Lbl_DefaultDatabase.Location = new System.Drawing.Point(11, 24);
            this.Lbl_DefaultDatabase.Name = "Lbl_DefaultDatabase";
            this.Lbl_DefaultDatabase.Size = new System.Drawing.Size(98, 13);
            this.Lbl_DefaultDatabase.TabIndex = 1;
            this.Lbl_DefaultDatabase.Text = "Database on open:";
            this.ToolTip_StartingInfo.SetToolTip(this.Lbl_DefaultDatabase, "Sets the default database on Open");
            // 
            // GroupB_EntryTypes
            // 
            this.GroupB_EntryTypes.Controls.Add(this.Lbl_Notice);
            this.GroupB_EntryTypes.Controls.Add(this.ListB_EntryTypes);
            this.GroupB_EntryTypes.Controls.Add(this.Btn_AddEntryType);
            this.GroupB_EntryTypes.Controls.Add(this.Btn_DeleteEntryType);
            this.GroupB_EntryTypes.Controls.Add(this.Btn_EditEntryType);
            this.GroupB_EntryTypes.Location = new System.Drawing.Point(4, 74);
            this.GroupB_EntryTypes.Name = "GroupB_EntryTypes";
            this.GroupB_EntryTypes.Size = new System.Drawing.Size(564, 117);
            this.GroupB_EntryTypes.TabIndex = 8;
            this.GroupB_EntryTypes.TabStop = false;
            this.GroupB_EntryTypes.Text = "Entry Types";
            // 
            // Lbl_Notice
            // 
            this.Lbl_Notice.AutoSize = true;
            this.Lbl_Notice.Location = new System.Drawing.Point(255, 19);
            this.Lbl_Notice.Name = "Lbl_Notice";
            this.Lbl_Notice.Size = new System.Drawing.Size(179, 13);
            this.Lbl_Notice.TabIndex = 6;
            this.Lbl_Notice.Text = "*EntryTypes is localized to Database";
            // 
            // ListB_EntryTypes
            // 
            this.ListB_EntryTypes.FormattingEnabled = true;
            this.ListB_EntryTypes.Location = new System.Drawing.Point(6, 19);
            this.ListB_EntryTypes.Name = "ListB_EntryTypes";
            this.ListB_EntryTypes.Size = new System.Drawing.Size(162, 82);
            this.ListB_EntryTypes.TabIndex = 2;
            // 
            // Btn_AddEntryType
            // 
            this.Btn_AddEntryType.Location = new System.Drawing.Point(174, 19);
            this.Btn_AddEntryType.Name = "Btn_AddEntryType";
            this.Btn_AddEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddEntryType.TabIndex = 3;
            this.Btn_AddEntryType.Text = "Add";
            this.Btn_AddEntryType.UseVisualStyleBackColor = true;
            this.Btn_AddEntryType.Click += new System.EventHandler(this.Btn_AddEntryType_Click);
            // 
            // Btn_DeleteEntryType
            // 
            this.Btn_DeleteEntryType.Location = new System.Drawing.Point(174, 78);
            this.Btn_DeleteEntryType.Name = "Btn_DeleteEntryType";
            this.Btn_DeleteEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_DeleteEntryType.TabIndex = 5;
            this.Btn_DeleteEntryType.Text = "Delete";
            this.Btn_DeleteEntryType.UseVisualStyleBackColor = true;
            this.Btn_DeleteEntryType.Click += new System.EventHandler(this.Btn_DeleteEntryType_Click);
            // 
            // Btn_EditEntryType
            // 
            this.Btn_EditEntryType.Location = new System.Drawing.Point(174, 49);
            this.Btn_EditEntryType.Name = "Btn_EditEntryType";
            this.Btn_EditEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_EditEntryType.TabIndex = 4;
            this.Btn_EditEntryType.Text = "Edit";
            this.Btn_EditEntryType.UseVisualStyleBackColor = true;
            this.Btn_EditEntryType.Click += new System.EventHandler(this.Btn_EditEntryType_Click);
            // 
            // TabController
            // 
            this.TabController.Controls.Add(this.tabPage1);
            this.TabController.Controls.Add(this.tabPage2);
            this.TabController.Location = new System.Drawing.Point(12, 12);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(582, 353);
            this.TabController.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GroupB_Excel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupB_Excel
            // 
            this.GroupB_Excel.Controls.Add(this.TxtB_SheetName);
            this.GroupB_Excel.Controls.Add(this.Lbl_SheetName);
            this.GroupB_Excel.Controls.Add(this.Num_StartingCellY);
            this.GroupB_Excel.Controls.Add(this.Num_StartingCellX);
            this.GroupB_Excel.Controls.Add(this.Lbl_StartingCell);
            this.GroupB_Excel.Location = new System.Drawing.Point(3, 6);
            this.GroupB_Excel.Name = "GroupB_Excel";
            this.GroupB_Excel.Size = new System.Drawing.Size(565, 82);
            this.GroupB_Excel.TabIndex = 0;
            this.GroupB_Excel.TabStop = false;
            this.GroupB_Excel.Text = "Excel";
            // 
            // Num_StartingCellY
            // 
            this.Num_StartingCellY.Location = new System.Drawing.Point(119, 52);
            this.Num_StartingCellY.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.Num_StartingCellY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_StartingCellY.Name = "Num_StartingCellY";
            this.Num_StartingCellY.Size = new System.Drawing.Size(34, 20);
            this.Num_StartingCellY.TabIndex = 2;
            this.Num_StartingCellY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Num_StartingCellX
            // 
            this.Num_StartingCellX.Location = new System.Drawing.Point(78, 52);
            this.Num_StartingCellX.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.Num_StartingCellX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_StartingCellX.Name = "Num_StartingCellX";
            this.Num_StartingCellX.Size = new System.Drawing.Size(35, 20);
            this.Num_StartingCellX.TabIndex = 1;
            this.Num_StartingCellX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lbl_StartingCell
            // 
            this.Lbl_StartingCell.AutoSize = true;
            this.Lbl_StartingCell.Location = new System.Drawing.Point(6, 54);
            this.Lbl_StartingCell.Name = "Lbl_StartingCell";
            this.Lbl_StartingCell.Size = new System.Drawing.Size(66, 13);
            this.Lbl_StartingCell.TabIndex = 0;
            this.Lbl_StartingCell.Text = "Starting Cell:";
            this.ToolTip_StartingInfo.SetToolTip(this.Lbl_StartingCell, "Sets the starting top left cell of all your info uploaded to the Excel.");
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(357, 371);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(438, 371);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Location = new System.Drawing.Point(519, 371);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.Btn_Apply.TabIndex = 3;
            this.Btn_Apply.Text = "Apply";
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Lbl_SheetName
            // 
            this.Lbl_SheetName.AutoSize = true;
            this.Lbl_SheetName.Location = new System.Drawing.Point(6, 29);
            this.Lbl_SheetName.Name = "Lbl_SheetName";
            this.Lbl_SheetName.Size = new System.Drawing.Size(69, 13);
            this.Lbl_SheetName.TabIndex = 3;
            this.Lbl_SheetName.Text = "Sheet Name:";
            // 
            // TxtB_SheetName
            // 
            this.TxtB_SheetName.Location = new System.Drawing.Point(78, 26);
            this.TxtB_SheetName.Name = "TxtB_SheetName";
            this.TxtB_SheetName.Size = new System.Drawing.Size(100, 20);
            this.TxtB_SheetName.TabIndex = 4;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(606, 400);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.TabController);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.tabPage1.ResumeLayout(false);
            this.GroupB_OnStart.ResumeLayout(false);
            this.GroupB_OnStart.PerformLayout();
            this.GroupB_EntryTypes.ResumeLayout(false);
            this.GroupB_EntryTypes.PerformLayout();
            this.TabController.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.GroupB_Excel.ResumeLayout(false);
            this.GroupB_Excel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingCellY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_StartingCellX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Btn_DeleteEntryType;
        private System.Windows.Forms.ListBox ListB_EntryTypes;
        private System.Windows.Forms.Button Btn_EditEntryType;
        private System.Windows.Forms.Button Btn_AddEntryType;
        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.Label Lbl_DefaultDatabase;
        private System.Windows.Forms.TextBox TxtB_DefaultDatabase;
        private System.Windows.Forms.Button Btn_BrowseDatabase;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Label Lbl_Notice;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox GroupB_EntryTypes;
        private System.Windows.Forms.GroupBox GroupB_OnStart;
        private System.Windows.Forms.GroupBox GroupB_Excel;
        private System.Windows.Forms.Label Lbl_StartingCell;
        private System.Windows.Forms.ToolTip ToolTip_StartingInfo;
        private System.Windows.Forms.NumericUpDown Num_StartingCellX;
        private System.Windows.Forms.NumericUpDown Num_StartingCellY;
        private System.Windows.Forms.Label Lbl_SheetName;
        private System.Windows.Forms.TextBox TxtB_SheetName;
    }
}