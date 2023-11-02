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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_BrowseDatabase = new System.Windows.Forms.Button();
            this.TxtB_DefaultDatabase = new System.Windows.Forms.TextBox();
            this.Lbl_DefaultDatabase = new System.Windows.Forms.Label();
            this.Lbl_Defaults = new System.Windows.Forms.Label();
            this.Panel_EntryTypes = new System.Windows.Forms.Panel();
            this.Lbl_EntryTypesHeader = new System.Windows.Forms.Label();
            this.Btn_DeleteEntryType = new System.Windows.Forms.Button();
            this.ListB_EntryTypes = new System.Windows.Forms.ListBox();
            this.Btn_EditEntryType = new System.Windows.Forms.Button();
            this.Btn_AddEntryType = new System.Windows.Forms.Button();
            this.TabController = new System.Windows.Forms.TabControl();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Lbl_Notice = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_EntryTypes.SuspendLayout();
            this.TabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.Panel_EntryTypes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_BrowseDatabase);
            this.panel1.Controls.Add(this.TxtB_DefaultDatabase);
            this.panel1.Controls.Add(this.Lbl_DefaultDatabase);
            this.panel1.Controls.Add(this.Lbl_Defaults);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 131);
            this.panel1.TabIndex = 7;
            // 
            // Btn_BrowseDatabase
            // 
            this.Btn_BrowseDatabase.Location = new System.Drawing.Point(466, 17);
            this.Btn_BrowseDatabase.Name = "Btn_BrowseDatabase";
            this.Btn_BrowseDatabase.Size = new System.Drawing.Size(75, 23);
            this.Btn_BrowseDatabase.TabIndex = 3;
            this.Btn_BrowseDatabase.Text = "Browse";
            this.Btn_BrowseDatabase.UseVisualStyleBackColor = true;
            this.Btn_BrowseDatabase.Click += new System.EventHandler(this.Btn_BrowseDatabase_Click);
            // 
            // TxtB_DefaultDatabase
            // 
            this.TxtB_DefaultDatabase.Location = new System.Drawing.Point(107, 17);
            this.TxtB_DefaultDatabase.Name = "TxtB_DefaultDatabase";
            this.TxtB_DefaultDatabase.Size = new System.Drawing.Size(353, 20);
            this.TxtB_DefaultDatabase.TabIndex = 2;
            // 
            // Lbl_DefaultDatabase
            // 
            this.Lbl_DefaultDatabase.AutoSize = true;
            this.Lbl_DefaultDatabase.Location = new System.Drawing.Point(3, 22);
            this.Lbl_DefaultDatabase.Name = "Lbl_DefaultDatabase";
            this.Lbl_DefaultDatabase.Size = new System.Drawing.Size(98, 13);
            this.Lbl_DefaultDatabase.TabIndex = 1;
            this.Lbl_DefaultDatabase.Text = "Database on open:";
            // 
            // Lbl_Defaults
            // 
            this.Lbl_Defaults.AutoSize = true;
            this.Lbl_Defaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Defaults.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Defaults.Name = "Lbl_Defaults";
            this.Lbl_Defaults.Size = new System.Drawing.Size(54, 13);
            this.Lbl_Defaults.TabIndex = 0;
            this.Lbl_Defaults.Text = "Defaults";
            // 
            // Panel_EntryTypes
            // 
            this.Panel_EntryTypes.Controls.Add(this.Lbl_Notice);
            this.Panel_EntryTypes.Controls.Add(this.Lbl_EntryTypesHeader);
            this.Panel_EntryTypes.Controls.Add(this.Btn_DeleteEntryType);
            this.Panel_EntryTypes.Controls.Add(this.ListB_EntryTypes);
            this.Panel_EntryTypes.Controls.Add(this.Btn_EditEntryType);
            this.Panel_EntryTypes.Controls.Add(this.Btn_AddEntryType);
            this.Panel_EntryTypes.Location = new System.Drawing.Point(6, 143);
            this.Panel_EntryTypes.Name = "Panel_EntryTypes";
            this.Panel_EntryTypes.Size = new System.Drawing.Size(555, 105);
            this.Panel_EntryTypes.TabIndex = 6;
            // 
            // Lbl_EntryTypesHeader
            // 
            this.Lbl_EntryTypesHeader.AutoSize = true;
            this.Lbl_EntryTypesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_EntryTypesHeader.Location = new System.Drawing.Point(3, 0);
            this.Lbl_EntryTypesHeader.Name = "Lbl_EntryTypesHeader";
            this.Lbl_EntryTypesHeader.Size = new System.Drawing.Size(74, 13);
            this.Lbl_EntryTypesHeader.TabIndex = 1;
            this.Lbl_EntryTypesHeader.Text = "Entry Types";
            // 
            // Btn_DeleteEntryType
            // 
            this.Btn_DeleteEntryType.Location = new System.Drawing.Point(174, 75);
            this.Btn_DeleteEntryType.Name = "Btn_DeleteEntryType";
            this.Btn_DeleteEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_DeleteEntryType.TabIndex = 5;
            this.Btn_DeleteEntryType.Text = "Delete";
            this.Btn_DeleteEntryType.UseVisualStyleBackColor = true;
            // 
            // ListB_EntryTypes
            // 
            this.ListB_EntryTypes.FormattingEnabled = true;
            this.ListB_EntryTypes.Location = new System.Drawing.Point(6, 16);
            this.ListB_EntryTypes.Name = "ListB_EntryTypes";
            this.ListB_EntryTypes.Size = new System.Drawing.Size(162, 82);
            this.ListB_EntryTypes.TabIndex = 2;
            // 
            // Btn_EditEntryType
            // 
            this.Btn_EditEntryType.Location = new System.Drawing.Point(174, 45);
            this.Btn_EditEntryType.Name = "Btn_EditEntryType";
            this.Btn_EditEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_EditEntryType.TabIndex = 4;
            this.Btn_EditEntryType.Text = "Edit";
            this.Btn_EditEntryType.UseVisualStyleBackColor = true;
            // 
            // Btn_AddEntryType
            // 
            this.Btn_AddEntryType.Location = new System.Drawing.Point(174, 16);
            this.Btn_AddEntryType.Name = "Btn_AddEntryType";
            this.Btn_AddEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddEntryType.TabIndex = 3;
            this.Btn_AddEntryType.Text = "Add";
            this.Btn_AddEntryType.UseVisualStyleBackColor = true;
            this.Btn_AddEntryType.Click += new System.EventHandler(this.Btn_AddEntryType_Click);
            // 
            // TabController
            // 
            this.TabController.Controls.Add(this.tabPage1);
            this.TabController.Location = new System.Drawing.Point(12, 12);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(582, 353);
            this.TabController.TabIndex = 0;
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
            // Lbl_Notice
            // 
            this.Lbl_Notice.AutoSize = true;
            this.Lbl_Notice.Location = new System.Drawing.Point(83, 0);
            this.Lbl_Notice.Name = "Lbl_Notice";
            this.Lbl_Notice.Size = new System.Drawing.Size(179, 13);
            this.Lbl_Notice.TabIndex = 6;
            this.Lbl_Notice.Text = "*EntryTypes is localized to Database";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 400);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.TabController);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel_EntryTypes.ResumeLayout(false);
            this.Panel_EntryTypes.PerformLayout();
            this.TabController.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel Panel_EntryTypes;
        private System.Windows.Forms.Label Lbl_EntryTypesHeader;
        private System.Windows.Forms.Button Btn_DeleteEntryType;
        private System.Windows.Forms.ListBox ListB_EntryTypes;
        private System.Windows.Forms.Button Btn_EditEntryType;
        private System.Windows.Forms.Button Btn_AddEntryType;
        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_Defaults;
        private System.Windows.Forms.Label Lbl_DefaultDatabase;
        private System.Windows.Forms.TextBox TxtB_DefaultDatabase;
        private System.Windows.Forms.Button Btn_BrowseDatabase;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Label Lbl_Notice;
    }
}