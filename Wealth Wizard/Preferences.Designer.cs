namespace Wealth_Wizard
{
    partial class Preferences
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
            this.Panel_EntryTypes = new System.Windows.Forms.Panel();
            this.Btn_AddEntryType = new System.Windows.Forms.Button();
            this.Btn_EditEntryType = new System.Windows.Forms.Button();
            this.ListB_EntryTypes = new System.Windows.Forms.ListBox();
            this.Btn_DeleteEntryType = new System.Windows.Forms.Button();
            this.Lbl_EntryTypesHeader = new System.Windows.Forms.Label();
            this.TabController = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.Panel_EntryTypes.SuspendLayout();
            this.TabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.Panel_EntryTypes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Panel_EntryTypes
            // 
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
            // Btn_EditEntryType
            // 
            this.Btn_EditEntryType.Location = new System.Drawing.Point(174, 45);
            this.Btn_EditEntryType.Name = "Btn_EditEntryType";
            this.Btn_EditEntryType.Size = new System.Drawing.Size(75, 23);
            this.Btn_EditEntryType.TabIndex = 4;
            this.Btn_EditEntryType.Text = "Edit";
            this.Btn_EditEntryType.UseVisualStyleBackColor = true;
            // 
            // ListB_EntryTypes
            // 
            this.ListB_EntryTypes.FormattingEnabled = true;
            this.ListB_EntryTypes.Location = new System.Drawing.Point(6, 16);
            this.ListB_EntryTypes.Name = "ListB_EntryTypes";
            this.ListB_EntryTypes.Size = new System.Drawing.Size(162, 82);
            this.ListB_EntryTypes.TabIndex = 2;
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
            // TabController
            // 
            this.TabController.Controls.Add(this.tabPage1);
            this.TabController.Location = new System.Drawing.Point(12, 12);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(582, 376);
            this.TabController.TabIndex = 0;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 400);
            this.Controls.Add(this.TabController);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.tabPage1.ResumeLayout(false);
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
    }
}