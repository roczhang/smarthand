using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datalibrary;

namespace app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableInput(true);
            this.nameText.Focus();
        }

        public void DisableInput(bool enabled)
        {
            this.nameText.Enabled    = enabled;
            this.ageText.Enabled     = enabled;
            this.sexText.Enabled     = enabled;
            this.addressText.Enabled = enabled;
            this.numberText.Enabled  = enabled;
                   
            this.calenderTimePicker.Enabled = enabled;

            this.diagnosisText.Enabled = enabled;
            this.allCostText.Enabled   = enabled;
            this.selfPayText.Enabled   = enabled;
            this.compensatePayText.Enabled = enabled;

            this.NextRecord.Enabled     = enabled;
            this.PreviousRecord.Enabled = enabled;
            

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nameText_TextChanged(object sender, EventArgs e)
        {
            
        }

       

    }
}
