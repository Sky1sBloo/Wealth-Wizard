namespace Wealth_Wizard
{
    partial class NewDatabaseForm
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
            this.Lbl_Location = new System.Windows.Forms.Label();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.Btn_Accept = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.TxtB_Name = new System.Windows.Forms.TextBox();
            this.TxtB_Location = new System.Windows.Forms.TextBox();
            this.Btn_SaveLocation = new System.Windows.Forms.Button();
            this.ChkB_OpenDatabase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Lbl_Location
            // 
            this.Lbl_Location.AutoSize = true;
            this.Lbl_Location.Location = new System.Drawing.Point(12, 33);
            this.Lbl_Location.Name = "Lbl_Location";
            this.Lbl_Location.Size = new System.Drawing.Size(51, 13);
            this.Lbl_Location.TabIndex = 0;
            this.Lbl_Location.Text = "Location:";
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.Location = new System.Drawing.Point(12, 9);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.Lbl_Name.TabIndex = 1;
            this.Lbl_Name.Text = "Name:";
            // 
            // Btn_Accept
            // 
            this.Btn_Accept.Location = new System.Drawing.Point(184, 97);
            this.Btn_Accept.Name = "Btn_Accept";
            this.Btn_Accept.Size = new System.Drawing.Size(75, 23);
            this.Btn_Accept.TabIndex = 2;
            this.Btn_Accept.Text = "Accept";
            this.Btn_Accept.UseVisualStyleBackColor = true;
            this.Btn_Accept.Click += new System.EventHandler(this.Btn_Accept_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(184, 126);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 3;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // TxtB_Name
            // 
            this.TxtB_Name.Location = new System.Drawing.Point(56, 6);
            this.TxtB_Name.Name = "TxtB_Name";
            this.TxtB_Name.Size = new System.Drawing.Size(371, 20);
            this.TxtB_Name.TabIndex = 4;
            // 
            // TxtB_Location
            // 
            this.TxtB_Location.Location = new System.Drawing.Point(69, 30);
            this.TxtB_Location.Name = "TxtB_Location";
            this.TxtB_Location.Size = new System.Drawing.Size(277, 20);
            this.TxtB_Location.TabIndex = 5;
            // 
            // Btn_SaveLocation
            // 
            this.Btn_SaveLocation.Location = new System.Drawing.Point(352, 28);
            this.Btn_SaveLocation.Name = "Btn_SaveLocation";
            this.Btn_SaveLocation.Size = new System.Drawing.Size(75, 23);
            this.Btn_SaveLocation.TabIndex = 6;
            this.Btn_SaveLocation.Text = "Browse";
            this.Btn_SaveLocation.UseVisualStyleBackColor = true;
            this.Btn_SaveLocation.Click += new System.EventHandler(this.Btn_SaveLocation_Click);
            // 
            // ChkB_OpenDatabase
            // 
            this.ChkB_OpenDatabase.AutoSize = true;
            this.ChkB_OpenDatabase.Checked = true;
            this.ChkB_OpenDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkB_OpenDatabase.Location = new System.Drawing.Point(173, 74);
            this.ChkB_OpenDatabase.Name = "ChkB_OpenDatabase";
            this.ChkB_OpenDatabase.Size = new System.Drawing.Size(101, 17);
            this.ChkB_OpenDatabase.TabIndex = 7;
            this.ChkB_OpenDatabase.Text = "Open Database";
            this.ChkB_OpenDatabase.UseVisualStyleBackColor = true;
            // 
            // NewDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 161);
            this.Controls.Add(this.ChkB_OpenDatabase);
            this.Controls.Add(this.Btn_SaveLocation);
            this.Controls.Add(this.TxtB_Location);
            this.Controls.Add(this.TxtB_Name);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Accept);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.Lbl_Location);
            this.Name = "NewDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Location;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.Button Btn_Accept;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.TextBox TxtB_Name;
        private System.Windows.Forms.TextBox TxtB_Location;
        private System.Windows.Forms.Button Btn_SaveLocation;
        private System.Windows.Forms.CheckBox ChkB_OpenDatabase;
    }
}