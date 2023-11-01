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
            this.TabController = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EntryTypesTab = new System.Windows.Forms.TabPage();
            this.DataGridV_Types = new System.Windows.Forms.DataGridView();
            this.TabController.SuspendLayout();
            this.EntryTypesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Types)).BeginInit();
            this.SuspendLayout();
            // 
            // TabController
            // 
            this.TabController.Controls.Add(this.tabPage1);
            this.TabController.Controls.Add(this.EntryTypesTab);
            this.TabController.Location = new System.Drawing.Point(12, 12);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(582, 376);
            this.TabController.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EntryTypesTab
            // 
            this.EntryTypesTab.Controls.Add(this.DataGridV_Types);
            this.EntryTypesTab.Location = new System.Drawing.Point(4, 22);
            this.EntryTypesTab.Name = "EntryTypesTab";
            this.EntryTypesTab.Padding = new System.Windows.Forms.Padding(3);
            this.EntryTypesTab.Size = new System.Drawing.Size(574, 350);
            this.EntryTypesTab.TabIndex = 1;
            this.EntryTypesTab.Text = "Entry Types";
            this.EntryTypesTab.UseVisualStyleBackColor = true;
            // 
            // DataGridV_Types
            // 
            this.DataGridV_Types.AllowUserToAddRows = false;
            this.DataGridV_Types.AllowUserToDeleteRows = false;
            this.DataGridV_Types.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridV_Types.Location = new System.Drawing.Point(279, 6);
            this.DataGridV_Types.Name = "DataGridV_Types";
            this.DataGridV_Types.ReadOnly = true;
            this.DataGridV_Types.Size = new System.Drawing.Size(289, 338);
            this.DataGridV_Types.TabIndex = 0;
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
            this.TabController.ResumeLayout(false);
            this.EntryTypesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Types)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage EntryTypesTab;
        private System.Windows.Forms.DataGridView DataGridV_Types;
    }
}