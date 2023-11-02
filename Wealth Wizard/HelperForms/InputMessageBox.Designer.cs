namespace Wealth_Wizard.HelperForms
{
    partial class InputMessageBox
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
            this.TxtB_Value = new System.Windows.Forms.TextBox();
            this.Lbl_Display = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtB_Value
            // 
            this.TxtB_Value.Location = new System.Drawing.Point(12, 25);
            this.TxtB_Value.Name = "TxtB_Value";
            this.TxtB_Value.Size = new System.Drawing.Size(169, 20);
            this.TxtB_Value.TabIndex = 0;
            // 
            // Lbl_Display
            // 
            this.Lbl_Display.Location = new System.Drawing.Point(12, 9);
            this.Lbl_Display.Name = "Lbl_Display";
            this.Lbl_Display.Size = new System.Drawing.Size(169, 13);
            this.Lbl_Display.TabIndex = 1;
            this.Lbl_Display.Text = "-";
            this.Lbl_Display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(51, 56);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(86, 23);
            this.Btn_Ok.TabIndex = 2;
            this.Btn_Ok.Text = "Ok";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // InputMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 91);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Lbl_Display);
            this.Controls.Add(this.TxtB_Value);
            this.Name = "InputMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Message Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtB_Value;
        private System.Windows.Forms.Label Lbl_Display;
        private System.Windows.Forms.Button Btn_Ok;
    }
}