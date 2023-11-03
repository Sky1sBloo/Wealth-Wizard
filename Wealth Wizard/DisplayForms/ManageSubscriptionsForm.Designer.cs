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
            this.Lbl_Date = new System.Windows.Forms.Label();
            this.DateT_SubDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Type = new System.Windows.Forms.Label();
            this.ComboB_Type = new System.Windows.Forms.ComboBox();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.TxtB_EntryName = new System.Windows.Forms.TextBox();
            this.Lbl_BillingCycle = new System.Windows.Forms.Label();
            this.ComboB_BillingCycle = new System.Windows.Forms.ComboBox();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.Btn_AddSub = new System.Windows.Forms.Button();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.NumTxtB_Amount = new NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Subscriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_Amount)).BeginInit();
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
            // Lbl_Date
            // 
            this.Lbl_Date.AutoSize = true;
            this.Lbl_Date.Location = new System.Drawing.Point(10, 31);
            this.Lbl_Date.Name = "Lbl_Date";
            this.Lbl_Date.Size = new System.Drawing.Size(33, 13);
            this.Lbl_Date.TabIndex = 3;
            this.Lbl_Date.Text = "Date:";
            // 
            // DateT_SubDate
            // 
            this.DateT_SubDate.CustomFormat = "yyyy/MM/dd";
            this.DateT_SubDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateT_SubDate.Location = new System.Drawing.Point(49, 25);
            this.DateT_SubDate.Name = "DateT_SubDate";
            this.DateT_SubDate.Size = new System.Drawing.Size(128, 20);
            this.DateT_SubDate.TabIndex = 4;
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
            this.Lbl_BillingCycle.Location = new System.Drawing.Point(10, 136);
            this.Lbl_BillingCycle.Name = "Lbl_BillingCycle";
            this.Lbl_BillingCycle.Size = new System.Drawing.Size(66, 13);
            this.Lbl_BillingCycle.TabIndex = 9;
            this.Lbl_BillingCycle.Text = "Billing Cycle:";
            // 
            // ComboB_BillingCycle
            // 
            this.ComboB_BillingCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_BillingCycle.FormattingEnabled = true;
            this.ComboB_BillingCycle.Location = new System.Drawing.Point(82, 130);
            this.ComboB_BillingCycle.Name = "ComboB_BillingCycle";
            this.ComboB_BillingCycle.Size = new System.Drawing.Size(95, 21);
            this.ComboB_BillingCycle.TabIndex = 10;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(636, 257);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(75, 23);
            this.Btn_Close.TabIndex = 11;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.UseVisualStyleBackColor = true;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(126, 157);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(51, 23);
            this.Btn_Delete.TabIndex = 13;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.Location = new System.Drawing.Point(70, 157);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(50, 23);
            this.Btn_Edit.TabIndex = 14;
            this.Btn_Edit.Text = "Edit";
            this.Btn_Edit.UseVisualStyleBackColor = true;
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // Btn_AddSub
            // 
            this.Btn_AddSub.Location = new System.Drawing.Point(13, 157);
            this.Btn_AddSub.Name = "Btn_AddSub";
            this.Btn_AddSub.Size = new System.Drawing.Size(51, 23);
            this.Btn_AddSub.TabIndex = 15;
            this.Btn_AddSub.Text = "Add";
            this.Btn_AddSub.UseVisualStyleBackColor = true;
            this.Btn_AddSub.Click += new System.EventHandler(this.Btn_AddSub_Click);
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.AutoSize = true;
            this.Lbl_Amount.Location = new System.Drawing.Point(10, 106);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(46, 13);
            this.Lbl_Amount.TabIndex = 16;
            this.Lbl_Amount.Text = "Amount:";
            // 
            // NumTxtB_Amount
            // 
            this.NumTxtB_Amount.DecimalPlaces = 2;
            this.NumTxtB_Amount.Location = new System.Drawing.Point(65, 104);
            this.NumTxtB_Amount.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumTxtB_Amount.Name = "NumTxtB_Amount";
            this.NumTxtB_Amount.Size = new System.Drawing.Size(112, 20);
            this.NumTxtB_Amount.TabIndex = 17;
            // 
            // ManageSubscriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 292);
            this.Controls.Add(this.NumTxtB_Amount);
            this.Controls.Add(this.Lbl_Amount);
            this.Controls.Add(this.Btn_AddSub);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.ComboB_BillingCycle);
            this.Controls.Add(this.Lbl_BillingCycle);
            this.Controls.Add(this.TxtB_EntryName);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.ComboB_Type);
            this.Controls.Add(this.Lbl_Type);
            this.Controls.Add(this.DateT_SubDate);
            this.Controls.Add(this.Lbl_Date);
            this.Controls.Add(this.DataGridV_Subscriptions);
            this.Controls.Add(this.Lbl_SubscriptionsDisplay);
            this.Name = "ManageSubscriptionsForm";
            this.Text = "Manage Subscriptions";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridV_Subscriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_Amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_SubscriptionsDisplay;
        private System.Windows.Forms.DataGridView DataGridV_Subscriptions;
        private System.Windows.Forms.Label Lbl_Date;
        private System.Windows.Forms.DateTimePicker DateT_SubDate;
        private System.Windows.Forms.Label Lbl_Type;
        private System.Windows.Forms.ComboBox ComboB_Type;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.TextBox TxtB_EntryName;
        private System.Windows.Forms.Label Lbl_BillingCycle;
        private System.Windows.Forms.ComboBox ComboB_BillingCycle;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Edit;
        private System.Windows.Forms.Button Btn_AddSub;
        private System.Windows.Forms.Label Lbl_Amount;
        private NumericTextBox NumTxtB_Amount;
    }
}