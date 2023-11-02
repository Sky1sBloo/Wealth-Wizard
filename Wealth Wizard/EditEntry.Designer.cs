namespace Wealth_Wizard
{
    partial class EditEntry
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
            this.Lbl_Date = new System.Windows.Forms.Label();
            this.DateT_Date = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Type = new System.Windows.Forms.Label();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.ComboB_Types = new System.Windows.Forms.ComboBox();
            this.TxtB_Name = new System.Windows.Forms.TextBox();
            this.ChkB_Expenses = new System.Windows.Forms.CheckBox();
            this.ChkB_Income = new System.Windows.Forms.CheckBox();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.NumTxtB_EntryAmount = new NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_EntryAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Date
            // 
            this.Lbl_Date.AutoSize = true;
            this.Lbl_Date.Location = new System.Drawing.Point(12, 15);
            this.Lbl_Date.Name = "Lbl_Date";
            this.Lbl_Date.Size = new System.Drawing.Size(33, 13);
            this.Lbl_Date.TabIndex = 0;
            this.Lbl_Date.Text = "Date:";
            // 
            // DateT_Date
            // 
            this.DateT_Date.CustomFormat = "yyyy/MM/dd";
            this.DateT_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateT_Date.Location = new System.Drawing.Point(64, 9);
            this.DateT_Date.Name = "DateT_Date";
            this.DateT_Date.Size = new System.Drawing.Size(122, 20);
            this.DateT_Date.TabIndex = 1;
            // 
            // Lbl_Type
            // 
            this.Lbl_Type.AutoSize = true;
            this.Lbl_Type.Location = new System.Drawing.Point(12, 40);
            this.Lbl_Type.Name = "Lbl_Type";
            this.Lbl_Type.Size = new System.Drawing.Size(34, 13);
            this.Lbl_Type.TabIndex = 2;
            this.Lbl_Type.Text = "Type:";
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.Location = new System.Drawing.Point(12, 64);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.Lbl_Name.TabIndex = 3;
            this.Lbl_Name.Text = "Name:";
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.AutoSize = true;
            this.Lbl_Amount.Location = new System.Drawing.Point(12, 90);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(46, 13);
            this.Lbl_Amount.TabIndex = 4;
            this.Lbl_Amount.Text = "Amount:";
            // 
            // ComboB_Types
            // 
            this.ComboB_Types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboB_Types.FormattingEnabled = true;
            this.ComboB_Types.Location = new System.Drawing.Point(64, 37);
            this.ComboB_Types.Name = "ComboB_Types";
            this.ComboB_Types.Size = new System.Drawing.Size(122, 21);
            this.ComboB_Types.TabIndex = 5;
            // 
            // TxtB_Name
            // 
            this.TxtB_Name.Location = new System.Drawing.Point(64, 61);
            this.TxtB_Name.Name = "TxtB_Name";
            this.TxtB_Name.Size = new System.Drawing.Size(122, 20);
            this.TxtB_Name.TabIndex = 6;
            // 
            // ChkB_Expenses
            // 
            this.ChkB_Expenses.AutoSize = true;
            this.ChkB_Expenses.Location = new System.Drawing.Point(15, 113);
            this.ChkB_Expenses.Name = "ChkB_Expenses";
            this.ChkB_Expenses.Size = new System.Drawing.Size(72, 17);
            this.ChkB_Expenses.TabIndex = 8;
            this.ChkB_Expenses.Text = "Expenses";
            this.ChkB_Expenses.UseVisualStyleBackColor = true;
            this.ChkB_Expenses.CheckedChanged += new System.EventHandler(this.ChkB_Expenses_CheckedChanged);
            // 
            // ChkB_Income
            // 
            this.ChkB_Income.AutoSize = true;
            this.ChkB_Income.Location = new System.Drawing.Point(93, 113);
            this.ChkB_Income.Name = "ChkB_Income";
            this.ChkB_Income.Size = new System.Drawing.Size(61, 17);
            this.ChkB_Income.TabIndex = 9;
            this.ChkB_Income.Text = "Income";
            this.ChkB_Income.UseVisualStyleBackColor = true;
            this.ChkB_Income.CheckedChanged += new System.EventHandler(this.ChkB_Income_CheckedChanged);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Location = new System.Drawing.Point(15, 136);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.Btn_Apply.TabIndex = 10;
            this.Btn_Apply.Text = "Apply";
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(105, 136);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 11;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // NumTxtB_EntryAmount
            // 
            this.NumTxtB_EntryAmount.DecimalPlaces = 6;
            this.NumTxtB_EntryAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.NumTxtB_EntryAmount.Location = new System.Drawing.Point(66, 87);
            this.NumTxtB_EntryAmount.Name = "NumTxtB_EntryAmount";
            this.NumTxtB_EntryAmount.Size = new System.Drawing.Size(120, 20);
            this.NumTxtB_EntryAmount.TabIndex = 12;
            // 
            // EditEntry
            // 
            this.AcceptButton = this.Btn_Apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Cancel;
            this.ClientSize = new System.Drawing.Size(198, 172);
            this.Controls.Add(this.NumTxtB_EntryAmount);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.ChkB_Income);
            this.Controls.Add(this.ChkB_Expenses);
            this.Controls.Add(this.TxtB_Name);
            this.Controls.Add(this.ComboB_Types);
            this.Controls.Add(this.Lbl_Amount);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.Lbl_Type);
            this.Controls.Add(this.DateT_Date);
            this.Controls.Add(this.Lbl_Date);
            this.Name = "EditEntry";
            this.Text = "Edit Entry";
            ((System.ComponentModel.ISupportInitialize)(this.NumTxtB_EntryAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Date;
        private System.Windows.Forms.DateTimePicker DateT_Date;
        private System.Windows.Forms.Label Lbl_Type;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.Label Lbl_Amount;
        private System.Windows.Forms.ComboBox ComboB_Types;
        private System.Windows.Forms.TextBox TxtB_Name;
        private System.Windows.Forms.CheckBox ChkB_Expenses;
        private System.Windows.Forms.CheckBox ChkB_Income;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_Cancel;
        private NumericTextBox NumTxtB_EntryAmount;
    }
}