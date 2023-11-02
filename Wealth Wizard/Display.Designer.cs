namespace Wealth_Wizard
{
    partial class Display
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
            this.DataGridV_Display = new System.Windows.Forms.DataGridView();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.Lbl_FilterDisplay = new System.Windows.Forms.Label();
            this.Panel_Filter = new System.Windows.Forms.Panel();
            this.ComboB_FilterType = new System.Windows.Forms.ComboBox();
            this.Lbl_Filter = new System.Windows.Forms.Label();
            this.ComboB_FilterPreset = new System.Windows.Forms.ComboBox();
            this.DatePick_FilterEndDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FilterEndDisplay = new System.Windows.Forms.Label();
            this.Lbl_FromDisplay = new System.Windows.Forms.Label();
            this.DatePick_FilterStartDate = new System.Windows.Forms.DateTimePicker();
            this.Btn_AddEntry = new System.Windows.Forms.Button();
            this.Btn_EditEntry = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.MenuStrip_Display = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSubscriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageGoalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DatePick_EntryDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_AmountDisplay = new System.Windows.Forms.Label();
            this.ChkB_Income = new System.Windows.Forms.CheckBox();
            this.ChkB_Expenses = new System.Windows.Forms.CheckBox();
            this.TxtB_EntryName = new System.Windows.Forms.TextBox();
            this.Lbl_NameDisplay = new System.Windows.Forms.Label();
            this.ComboB_EntryType = new System.Windows.Forms.ComboBox();
            this.Lbl_TypeDisplay = new System.Windows.Forms.Label();
            this.Lbl_DateDisplay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_Debug = new System.Windows.Forms.Label();
            this.NumTxtB_EntryAmount = new NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Display)).BeginInit();
            this.Panel_Filter.SuspendLayout();
            this.MenuStrip_Display.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_EntryAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridV_Display
            // 
            this.DataGridV_Display.AllowUserToAddRows = false;
            this.DataGridV_Display.AllowUserToDeleteRows = false;
            this.DataGridV_Display.AllowUserToResizeRows = false;
            this.DataGridV_Display.Location = new System.Drawing.Point(258, 95);
            this.DataGridV_Display.Name = "DataGridV_Display";
            this.DataGridV_Display.ReadOnly = true;
            this.DataGridV_Display.ShowEditingIcon = false;
            this.DataGridV_Display.Size = new System.Drawing.Size(530, 343);
            this.DataGridV_Display.TabIndex = 0;
            this.DataGridV_Display.SelectionChanged += new System.EventHandler(this.SetCurrentSelection);
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(452, 39);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.Btn_Refresh.TabIndex = 1;
            this.Btn_Refresh.Text = "Refresh";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.RefreshBtn_Clicked);
            // 
            // Lbl_FilterDisplay
            // 
            this.Lbl_FilterDisplay.AutoSize = true;
            this.Lbl_FilterDisplay.Location = new System.Drawing.Point(3, 17);
            this.Lbl_FilterDisplay.Name = "Lbl_FilterDisplay";
            this.Lbl_FilterDisplay.Size = new System.Drawing.Size(32, 13);
            this.Lbl_FilterDisplay.TabIndex = 2;
            this.Lbl_FilterDisplay.Text = "Filter:";
            // 
            // Panel_Filter
            // 
            this.Panel_Filter.Controls.Add(this.ComboB_FilterType);
            this.Panel_Filter.Controls.Add(this.Lbl_Filter);
            this.Panel_Filter.Controls.Add(this.ComboB_FilterPreset);
            this.Panel_Filter.Controls.Add(this.DatePick_FilterEndDate);
            this.Panel_Filter.Controls.Add(this.Lbl_FilterEndDisplay);
            this.Panel_Filter.Controls.Add(this.Lbl_FromDisplay);
            this.Panel_Filter.Controls.Add(this.DatePick_FilterStartDate);
            this.Panel_Filter.Controls.Add(this.Btn_Refresh);
            this.Panel_Filter.Controls.Add(this.Lbl_FilterDisplay);
            this.Panel_Filter.Location = new System.Drawing.Point(258, 27);
            this.Panel_Filter.Name = "Panel_Filter";
            this.Panel_Filter.Size = new System.Drawing.Size(530, 62);
            this.Panel_Filter.TabIndex = 4;
            // 
            // ComboB_FilterType
            // 
            this.ComboB_FilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_FilterType.FormattingEnabled = true;
            this.ComboB_FilterType.Location = new System.Drawing.Point(208, 13);
            this.ComboB_FilterType.Name = "ComboB_FilterType";
            this.ComboB_FilterType.Size = new System.Drawing.Size(121, 21);
            this.ComboB_FilterType.TabIndex = 10;
            this.ComboB_FilterType.SelectedValueChanged += new System.EventHandler(this.ComboB_FilterType_SelectedValueChanged);
            // 
            // Lbl_Filter
            // 
            this.Lbl_Filter.AutoSize = true;
            this.Lbl_Filter.Location = new System.Drawing.Point(168, 17);
            this.Lbl_Filter.Name = "Lbl_Filter";
            this.Lbl_Filter.Size = new System.Drawing.Size(34, 13);
            this.Lbl_Filter.TabIndex = 9;
            this.Lbl_Filter.Text = "Type:";
            // 
            // ComboB_FilterPreset
            // 
            this.ComboB_FilterPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_FilterPreset.FormattingEnabled = true;
            this.ComboB_FilterPreset.Items.AddRange(new object[] {
            "Current Year",
            "Current Month",
            "Current Week",
            "Custom"});
            this.ComboB_FilterPreset.Location = new System.Drawing.Point(41, 13);
            this.ComboB_FilterPreset.Name = "ComboB_FilterPreset";
            this.ComboB_FilterPreset.Size = new System.Drawing.Size(121, 21);
            this.ComboB_FilterPreset.TabIndex = 8;
            this.ComboB_FilterPreset.SelectedIndexChanged += new System.EventHandler(this._SetFilter);
            this.ComboB_FilterPreset.Click += new System.EventHandler(this.RefreshBtn_Clicked);
            // 
            // DatePick_FilterEndDate
            // 
            this.DatePick_FilterEndDate.CustomFormat = "yyyy/MM/dd";
            this.DatePick_FilterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePick_FilterEndDate.Location = new System.Drawing.Point(162, 39);
            this.DatePick_FilterEndDate.Name = "DatePick_FilterEndDate";
            this.DatePick_FilterEndDate.Size = new System.Drawing.Size(89, 20);
            this.DatePick_FilterEndDate.TabIndex = 7;
            this.DatePick_FilterEndDate.ValueChanged += new System.EventHandler(this.DateUpdated);
            // 
            // Lbl_FilterEndDisplay
            // 
            this.Lbl_FilterEndDisplay.AutoSize = true;
            this.Lbl_FilterEndDisplay.Location = new System.Drawing.Point(136, 40);
            this.Lbl_FilterEndDisplay.Name = "Lbl_FilterEndDisplay";
            this.Lbl_FilterEndDisplay.Size = new System.Drawing.Size(20, 13);
            this.Lbl_FilterEndDisplay.TabIndex = 6;
            this.Lbl_FilterEndDisplay.Text = "To";
            // 
            // Lbl_FromDisplay
            // 
            this.Lbl_FromDisplay.AutoSize = true;
            this.Lbl_FromDisplay.Location = new System.Drawing.Point(5, 40);
            this.Lbl_FromDisplay.Name = "Lbl_FromDisplay";
            this.Lbl_FromDisplay.Size = new System.Drawing.Size(30, 13);
            this.Lbl_FromDisplay.TabIndex = 5;
            this.Lbl_FromDisplay.Text = "From";
            // 
            // DatePick_FilterStartDate
            // 
            this.DatePick_FilterStartDate.CustomFormat = "yyyy/MM/dd";
            this.DatePick_FilterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePick_FilterStartDate.Location = new System.Drawing.Point(41, 39);
            this.DatePick_FilterStartDate.Name = "DatePick_FilterStartDate";
            this.DatePick_FilterStartDate.Size = new System.Drawing.Size(89, 20);
            this.DatePick_FilterStartDate.TabIndex = 4;
            this.DatePick_FilterStartDate.ValueChanged += new System.EventHandler(this.DateUpdated);
            // 
            // Btn_AddEntry
            // 
            this.Btn_AddEntry.Location = new System.Drawing.Point(9, 139);
            this.Btn_AddEntry.Name = "Btn_AddEntry";
            this.Btn_AddEntry.Size = new System.Drawing.Size(59, 23);
            this.Btn_AddEntry.TabIndex = 0;
            this.Btn_AddEntry.Text = "Add";
            this.Btn_AddEntry.UseVisualStyleBackColor = true;
            this.Btn_AddEntry.Click += new System.EventHandler(this.Btn_AddEntry_Click);
            // 
            // Btn_EditEntry
            // 
            this.Btn_EditEntry.Location = new System.Drawing.Point(74, 139);
            this.Btn_EditEntry.Name = "Btn_EditEntry";
            this.Btn_EditEntry.Size = new System.Drawing.Size(60, 23);
            this.Btn_EditEntry.TabIndex = 1;
            this.Btn_EditEntry.Text = "Edit";
            this.Btn_EditEntry.UseVisualStyleBackColor = true;
            this.Btn_EditEntry.Click += new System.EventHandler(this.Btn_EditEntry_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(140, 139);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(61, 23);
            this.Btn_Delete.TabIndex = 2;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // MenuStrip_Display
            // 
            this.MenuStrip_Display.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.preferenceToolStripMenuItem,
            this.subscriptionsToolStripMenuItem});
            this.MenuStrip_Display.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Display.Name = "MenuStrip_Display";
            this.MenuStrip_Display.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip_Display.TabIndex = 5;
            this.MenuStrip_Display.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newDatabaseToolStripMenuItem.Text = "New Database";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.NewDatabaseMenu_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseMenu_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.queriesToolStripMenuItem,
            this.preferencesToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addToolStripMenuItem.Text = "New Entry";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Edit Entry";
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // preferencesToolStripMenuItem1
            // 
            this.preferencesToolStripMenuItem1.Name = "preferencesToolStripMenuItem1";
            this.preferencesToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem1.Text = "Preferences";
            this.preferencesToolStripMenuItem1.Click += new System.EventHandler(this.PreferencesMenu_Click);
            // 
            // preferenceToolStripMenuItem
            // 
            this.preferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsToolStripMenuItem});
            this.preferenceToolStripMenuItem.Name = "preferenceToolStripMenuItem";
            this.preferenceToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.preferenceToolStripMenuItem.Text = "Profile";
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.statsToolStripMenuItem.Text = "Stats";
            // 
            // subscriptionsToolStripMenuItem
            // 
            this.subscriptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSubscriptionsToolStripMenuItem,
            this.manageGoalsToolStripMenuItem});
            this.subscriptionsToolStripMenuItem.Name = "subscriptionsToolStripMenuItem";
            this.subscriptionsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.subscriptionsToolStripMenuItem.Text = "Subscriptions";
            // 
            // manageSubscriptionsToolStripMenuItem
            // 
            this.manageSubscriptionsToolStripMenuItem.Name = "manageSubscriptionsToolStripMenuItem";
            this.manageSubscriptionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.manageSubscriptionsToolStripMenuItem.Text = "Manage Subscriptions";
            // 
            // manageGoalsToolStripMenuItem
            // 
            this.manageGoalsToolStripMenuItem.Name = "manageGoalsToolStripMenuItem";
            this.manageGoalsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.manageGoalsToolStripMenuItem.Text = "Manage Goals";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DatePick_EntryDate);
            this.panel1.Controls.Add(this.NumTxtB_EntryAmount);
            this.panel1.Controls.Add(this.Lbl_AmountDisplay);
            this.panel1.Controls.Add(this.ChkB_Income);
            this.panel1.Controls.Add(this.ChkB_Expenses);
            this.panel1.Controls.Add(this.Btn_Delete);
            this.panel1.Controls.Add(this.Btn_EditEntry);
            this.panel1.Controls.Add(this.TxtB_EntryName);
            this.panel1.Controls.Add(this.Btn_AddEntry);
            this.panel1.Controls.Add(this.Lbl_NameDisplay);
            this.panel1.Controls.Add(this.ComboB_EntryType);
            this.panel1.Controls.Add(this.Lbl_TypeDisplay);
            this.panel1.Controls.Add(this.Lbl_DateDisplay);
            this.panel1.Location = new System.Drawing.Point(12, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 171);
            this.panel1.TabIndex = 6;
            // 
            // DatePick_EntryDate
            // 
            this.DatePick_EntryDate.CustomFormat = "yyyy/MM/dd";
            this.DatePick_EntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePick_EntryDate.Location = new System.Drawing.Point(52, 10);
            this.DatePick_EntryDate.Name = "DatePick_EntryDate";
            this.DatePick_EntryDate.Size = new System.Drawing.Size(176, 20);
            this.DatePick_EntryDate.TabIndex = 13;
            // 
            // Lbl_AmountDisplay
            // 
            this.Lbl_AmountDisplay.AutoSize = true;
            this.Lbl_AmountDisplay.Location = new System.Drawing.Point(3, 93);
            this.Lbl_AmountDisplay.Name = "Lbl_AmountDisplay";
            this.Lbl_AmountDisplay.Size = new System.Drawing.Size(46, 13);
            this.Lbl_AmountDisplay.TabIndex = 11;
            this.Lbl_AmountDisplay.Text = "Amount:";
            // 
            // ChkB_Income
            // 
            this.ChkB_Income.AutoSize = true;
            this.ChkB_Income.Location = new System.Drawing.Point(84, 116);
            this.ChkB_Income.Name = "ChkB_Income";
            this.ChkB_Income.Size = new System.Drawing.Size(61, 17);
            this.ChkB_Income.TabIndex = 10;
            this.ChkB_Income.Text = "Income";
            this.ChkB_Income.UseVisualStyleBackColor = true;
            this.ChkB_Income.CheckedChanged += new System.EventHandler(this.ChkB_Income_CheckedChanged);
            // 
            // ChkB_Expenses
            // 
            this.ChkB_Expenses.AutoSize = true;
            this.ChkB_Expenses.Checked = true;
            this.ChkB_Expenses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkB_Expenses.Location = new System.Drawing.Point(6, 116);
            this.ChkB_Expenses.Name = "ChkB_Expenses";
            this.ChkB_Expenses.Size = new System.Drawing.Size(72, 17);
            this.ChkB_Expenses.TabIndex = 9;
            this.ChkB_Expenses.Text = "Expenses";
            this.ChkB_Expenses.UseVisualStyleBackColor = true;
            this.ChkB_Expenses.CheckedChanged += new System.EventHandler(this.ChkB_Expenses_CheckedChanged);
            // 
            // TxtB_EntryName
            // 
            this.TxtB_EntryName.Location = new System.Drawing.Point(52, 62);
            this.TxtB_EntryName.Name = "TxtB_EntryName";
            this.TxtB_EntryName.Size = new System.Drawing.Size(176, 20);
            this.TxtB_EntryName.TabIndex = 7;
            // 
            // Lbl_NameDisplay
            // 
            this.Lbl_NameDisplay.AutoSize = true;
            this.Lbl_NameDisplay.Location = new System.Drawing.Point(3, 65);
            this.Lbl_NameDisplay.Name = "Lbl_NameDisplay";
            this.Lbl_NameDisplay.Size = new System.Drawing.Size(38, 13);
            this.Lbl_NameDisplay.TabIndex = 7;
            this.Lbl_NameDisplay.Text = "Name:";
            // 
            // ComboB_EntryType
            // 
            this.ComboB_EntryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_EntryType.FormattingEnabled = true;
            this.ComboB_EntryType.Location = new System.Drawing.Point(52, 36);
            this.ComboB_EntryType.Name = "ComboB_EntryType";
            this.ComboB_EntryType.Size = new System.Drawing.Size(176, 21);
            this.ComboB_EntryType.TabIndex = 6;
            // 
            // Lbl_TypeDisplay
            // 
            this.Lbl_TypeDisplay.AutoSize = true;
            this.Lbl_TypeDisplay.Location = new System.Drawing.Point(3, 39);
            this.Lbl_TypeDisplay.Name = "Lbl_TypeDisplay";
            this.Lbl_TypeDisplay.Size = new System.Drawing.Size(34, 13);
            this.Lbl_TypeDisplay.TabIndex = 5;
            this.Lbl_TypeDisplay.Text = "Type:";
            // 
            // Lbl_DateDisplay
            // 
            this.Lbl_DateDisplay.AutoSize = true;
            this.Lbl_DateDisplay.Location = new System.Drawing.Point(3, 15);
            this.Lbl_DateDisplay.Name = "Lbl_DateDisplay";
            this.Lbl_DateDisplay.Size = new System.Drawing.Size(33, 13);
            this.Lbl_DateDisplay.TabIndex = 3;
            this.Lbl_DateDisplay.Text = "Date:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lbl_Debug);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 234);
            this.panel2.TabIndex = 7;
            // 
            // Lbl_Debug
            // 
            this.Lbl_Debug.AutoSize = true;
            this.Lbl_Debug.Location = new System.Drawing.Point(9, 16);
            this.Lbl_Debug.Name = "Lbl_Debug";
            this.Lbl_Debug.Size = new System.Drawing.Size(10, 13);
            this.Lbl_Debug.TabIndex = 0;
            this.Lbl_Debug.Text = "-";
            // 
            // NumTxtB_EntryAmount
            // 
            this.NumTxtB_EntryAmount.DecimalPlaces = 2;
            this.NumTxtB_EntryAmount.Location = new System.Drawing.Point(52, 91);
            this.NumTxtB_EntryAmount.Name = "NumTxtB_EntryAmount";
            this.NumTxtB_EntryAmount.Size = new System.Drawing.Size(176, 20);
            this.NumTxtB_EntryAmount.TabIndex = 8;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Filter);
            this.Controls.Add(this.DataGridV_Display);
            this.Controls.Add(this.MenuStrip_Display);
            this.MainMenuStrip = this.MenuStrip_Display;
            this.Name = "Display";
            this.Text = "Wealth Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Display)).EndInit();
            this.Panel_Filter.ResumeLayout(false);
            this.Panel_Filter.PerformLayout();
            this.MenuStrip_Display.ResumeLayout(false);
            this.MenuStrip_Display.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_EntryAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridV_Display;
        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.Label Lbl_FilterDisplay;
        private System.Windows.Forms.Panel Panel_Filter;
        private System.Windows.Forms.DateTimePicker DatePick_FilterStartDate;
        private System.Windows.Forms.Label Lbl_FromDisplay;
        private System.Windows.Forms.Label Lbl_FilterEndDisplay;
        private System.Windows.Forms.DateTimePicker DatePick_FilterEndDate;
        private System.Windows.Forms.ComboBox ComboB_FilterPreset;
        private System.Windows.Forms.Button Btn_AddEntry;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_EditEntry;
        private System.Windows.Forms.MenuStrip MenuStrip_Display;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSubscriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageGoalsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_DateDisplay;
        private System.Windows.Forms.Label Lbl_TypeDisplay;
        private System.Windows.Forms.ComboBox ComboB_EntryType;
        private System.Windows.Forms.Label Lbl_NameDisplay;
        private System.Windows.Forms.TextBox TxtB_EntryName;
        private System.Windows.Forms.CheckBox ChkB_Expenses;
        private System.Windows.Forms.CheckBox ChkB_Income;
        private System.Windows.Forms.Label Lbl_AmountDisplay;
        private NumericTextBox NumTxtB_EntryAmount;
        private System.Windows.Forms.DateTimePicker DatePick_EntryDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_Debug;
        private System.Windows.Forms.Label Lbl_Filter;
        private System.Windows.Forms.ComboBox ComboB_FilterType;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem1;
    }
}

