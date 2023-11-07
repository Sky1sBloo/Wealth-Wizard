using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wealth_Wizard.Handlers;

namespace Wealth_Wizard.HelperForms
{
    /// <summary>
    /// Form that opens a window to edit subscriptions
    /// </summary>
    public partial class EditSubscriptionForm : Form
    {
        public Subscription subscription;

        public EditSubscriptionForm(Subscription defaultValues)
        {
            InitializeComponent();

            LoadComboBoxItems();

            DateT_StartDate.Value = defaultValues.StartDate;

            if (defaultValues.EndDate != null)
            {
                ChkB_HasEndDate.Checked = true;
                Panel_EndDate.Visible = true;

                DateT_EndDate.Value = defaultValues.EndDate ?? DateTime.Now;
            }
            else
            {
                ChkB_HasEndDate.Checked = false;
                Panel_EndDate.Visible = false;
            }

            ComboB_Type.SelectedIndex = 0;
            TxtB_EntryName.Text = defaultValues.Name;
            NumTxtB_Amount.Value = (decimal)defaultValues.Amount;
            ComboB_BillingCycle.Text = defaultValues.BillingCycle;


            Panel_EndDate.Visible = ChkB_HasEndDate.Checked;
        }

        private void LoadComboBoxItems()
        {
            // Load combo box
            foreach (string entryType in EntryTypesHandler.GetEntryTypes())
            {
                ComboB_Type.Items.Add(entryType);
            }
            ComboB_Type.SelectedIndex = 0;

            foreach (string billingCycle in DatabaseHandler.defaultBillingCycles)
            {
                ComboB_BillingCycle.Items.Add(billingCycle);
            }
            ComboB_BillingCycle.SelectedIndex = 0;
        }

        // Event
        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            if (ChkB_HasEndDate.Checked)
            {
                subscription = new Subscription(DateT_StartDate.Value, DateT_EndDate.Value,
                    ComboB_Type.Text, TxtB_EntryName.Text, (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);
            }
            else
            {
                subscription = new Subscription(DateT_StartDate.Value, ComboB_Type.Text, 
                    TxtB_EntryName.Text, (float)NumTxtB_Amount.Value, ComboB_BillingCycle.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChkB_HasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            Panel_EndDate.Visible = ChkB_HasEndDate.Checked;
        }
    }
}
