using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using app.Properties;

namespace app
{
    public partial class compensationForm : Form
    {
        private Settings m_setting;
        public compensationForm(Settings setting)
        {
            InitializeComponent();
            m_setting = setting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float RatioX = 0;
            if ( ! float.TryParse(this.RatioTextBox.Text, out RatioX))
            {
                MessageBox.Show("请输入数字");
                this.RatioTextBox.Text = "";
                this.RatioTextBox.Focus();
                return;
            }

            float remainder = 0;
            if (!float.TryParse(this.RemainderTextBox.Text, out remainder))
            {
                MessageBox.Show("调整额应该是数字");
                this.RemainderTextBox.Text = "";
                this.RemainderTextBox.Focus();
                return;
            }

            float totalCost;
            if (!float.TryParse(this.SampleTotalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("总费用应该是数字");
                this.SampleTotalCostTextBox.Text = "";
                this.SampleTotalCostTextBox.Focus();
                return;
            }

            // save the parmater to file
            m_setting.Ratio = RatioX;
            m_setting.Remainder = remainder;
            m_setting.SampleTotal = totalCost;
            m_setting.Save();




            this.SampleRatioXTextBox.Text = this.RatioTextBox.Text;
            this.SampleRemainderTextBox.Text = this.RemainderTextBox.Text;


            CostFormular cf = new CostFormular(totalCost, RatioX, remainder);
            this.SampleResult.Text = cf.Compentation.ToString();

            if (cf.Compentation - 20 >= 0)
            {
                this.SampleResult.Text = "20";
                this.SampleRatioXTextBox.Text = "";
                this.SampleRemainderTextBox.Text = "";
            }

        }

        private void compensationForm_Load(object sender, EventArgs e)
        {
            this.RatioTextBox.Text = this.m_setting.Ratio.ToString();
            this.RemainderTextBox.Text = this.m_setting.Remainder.ToString();

            this.SampleRatioXTextBox.Text = this.m_setting.Ratio.ToString();
            this.SampleRemainderTextBox.Text = this.m_setting.Remainder.ToString();
            this.SampleResult.Text = this.m_setting.SampleTotal.ToString();

            CostFormular cf = new CostFormular(this.m_setting.SampleTotal, m_setting.Ratio, m_setting.Remainder);
            this.SampleResult.Text = cf.Compentation.ToString();

            if (cf.Compentation - 20 >= 0)
            {
                this.SampleResult.Text = "20";
                this.SampleRatioXTextBox.Text = "";
                this.SampleRemainderTextBox.Text = "";
            }

        }
    }
}
