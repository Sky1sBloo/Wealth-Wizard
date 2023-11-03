namespace Wealth_Wizard.DisplayForms
{
    partial class ManageSubscriptionsForm
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
            this.Lbl_SubscriptionsDisplay = new System.Windows.Forms.Label();
            this.DataGridV_Subscriptions = new System.Windows.Forms.DataGridView();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Lbl_Date = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Type = new System.Windows.Forms.Label();
            this.ComboB_Type = new System.Windows.Forms.ComboBox();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.TxtB_EntryName = new System.Windows.Forms.TextBox();
            this.Lbl_BillingCycle = new System.Windows.Forms.Label();
            this.ComboB_BillingCycle = new System.Windows.Forms.ComboBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Subscriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_SubscriptionsDisplay
            // 
            this.Lbl_SubscriptionsDisplay.AutoSize = true;
            this.Lbl_SubscriptionsDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_SubscriptionsDisplay.Location = new System.Drawing.Point(12, 9);
            this.Lbl_SubscriptionsDisplay.Name = "Lbl_SubscriptionsDisplay";
            this.Lbl_SubscriptionsDisplay.Size = new System.Drawing.Size(83, 13);
            this.Lbl_SubscriptionsDisplay.TabIndex = 0;
            this.Lbl_SubscriptionsDisplay.Text = "Subscriptions";
            // 
            // DataGridV_Subscriptions
            // 
            this.DataGridV_Subscriptions.AllowUserToAddRows = false;
            this.DataGridV_Subscriptions.AllowUserToDeleteRows = false;
            this.DataGridV_Subscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridV_Subscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridV_Subscriptions.Location = new System.Drawing.Point(209, 12);
            this.DataGridV_Subscriptions.Name = "DataGridV_Subscriptions";
            this.DataGridV_Subscriptions.Size = new System.Drawing.Size(502, 238);
            this.DataGridV_Subscriptions.TabIndex = 1;
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Location = new System.Drawing.Point(636, 256);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.Btn_Apply.TabIndex = 2;
            this.Btn_Apply.Text = "Apply";
            this.Btn_Apply.UseVisualStyleBackColor = true;
            // 
            // Lbl_Date
            // 
            this.Lbl_Date.AutoSize = true;
            this.Lbl_Date.Location = new System.Drawing.Point(10, 31);
            this.Lbl_Date.Name = "Lbl_Date";
            this.Lbl_Date.Size = new System.Drawing.Size(33, 13);
            this.Lbl_Date.TabIndex = 3;
            this.Lbl_Date.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(49, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // Lbl_Type
            // 
            this.Lbl_Type.AutoSize = true;
            this.Lbl_Type.Location = new System.Drawing.Point(10, 53);
            this.Lbl_Type.Name = "Lbl_Type";
            this.Lbl_Type.Size = new System.Drawing.Size(34, 13);
            this.Lbl_Type.TabIndex = 5;
            this.Lbl_Type.Text = "Type:";
            // 
            // ComboB_Type
            // 
            this.ComboB_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_Type.FormattingEnabled = true;
            this.ComboB_Type.Location = new System.Drawing.Point(49, 50);
            this.ComboB_Type.Name = "ComboB_Type";
            this.ComboB_Type.Size = new System.Drawing.Size(128, 21);
            this.ComboB_Type.TabIndex = 6;
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.Location = new System.Drawing.Point(10, 79);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.Lbl_Name.TabIndex = 7;
            this.Lbl_Name.Text = "Name:";
            // 
            // TxtB_EntryName
            // 
            this.TxtB_EntryName.Location = new System.Drawing.Point(49, 77);
            this.TxtB_EntryName.Name = "TxtB_EntryName";
            this.TxtB_EntryName.Size = new System.Drawing.Size(128, 20);
            this.TxtB_EntryName.TabIndex = 8;
            // 
            // Lbl_BillingCycle
            // 
            this.Lbl_BillingCycle.AutoSize = true;
            this.Lbl_BillingCycle.Location = new System.Drawing.Point(10, 109);
            this.Lbl_BillingCycle.Name = "Lbl_BillingCycle";
            this.Lbl_BillingCycle.Size = new System.Drawing.Size(66, 13);
            this.Lbl_BillingCycle.TabIndex = 9;
            this.Lbl_BillingCycle.Text = "Billing Cycle:";
            // 
            // ComboB_BillingCycle
            // 
            this.ComboB_BillingCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_BillingCycle.FormattingEnabled = true;
            this.ComboB_BillingCycle.Location = new System.Drawing.Point(82, 103);
            this.ComboB_BillingCycle.Name = "ComboB_BillingCycle";
            this.ComboB_BillingCycle.Size = new System.Drawing.Size(95, 21);
            this.ComboB_BillingCycle.TabIndex = 10;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(555, 256);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 11;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(474, 256);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 12;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(126, 130);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(51, 23);
            this.Btn_Delete.TabIndex = 13;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.Location = new System.Drawing.Point(70, 130);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(50, 23);
            this.Btn_Edit.TabIndex = 14;
            this.Btn_Edit.Text = "Edit";
            this.Btn_Edit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ManageSubscriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.ComboB_BillingCycle);
            this.Controls.Add(this.Lbl_BillingCycle);
            this.Controls.Add(this.TxtB_EntryName);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.ComboB_Type);
            this.Controls.Add(this.Lbl_Type);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Lbl_Date);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.DataGridV_Subscriptions);
            this.Controls.Add(this.Lbl_SubscriptionsDisplay);
            this.Name = "ManageSubscriptionsForm";
            this.Text = "Manage Subscriptions";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Subscriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_SubscriptionsDisplay;
        private System.Windows.Forms.DataGridView DataGridV_Subscriptions;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Label Lbl_Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label Lbl_Type;
        private System.Windows.Forms.ComboBox ComboB_Type;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.TextBox TxtB_EntryName;
        private System.Windows.Forms.Label Lbl_BillingCycle;
        private System.Windows.Forms.ComboBox ComboB_BillingCycle;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Edit;
        private System.Windows.Forms.Button button1;
    }
}