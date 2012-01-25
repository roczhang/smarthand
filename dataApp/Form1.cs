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
        private RecordStructure m_smartbufferlist;
        private string m_name = "";
        private string m_no = "";
        private string m_address = "";
        private float m_age = 0.0f;
        private string m_sex = "";

        //private DateTime m_dateTime = System.DateTime.Today();
        private string m_currentData = DateTime.Today.ToShortDateString();
        private float m_allCost = 0.0f;
        private float m_selfCost = 0.0f;
        private float m_compenatecost = 0.0f;
        public Form1()
        {
            InitializeComponent();
            string filePath = @"C:\Users\zhangroc\app\data\DB.csv";
            m_smartbufferlist = new RecordStructure(filePath);
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

        private void SetCurrentRecord(PeopleInfo peopleInfo)
        {
 	        this.numberText.Text = peopleInfo.m_no;
            this.ageText.Text = peopleInfo.m_age.ToString();
            this.sexText.Text = peopleInfo.m_sex;
            this.addressText.Text = peopleInfo.m_address;
        }



 

        private void nameText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                string name = nameText.Text.Trim();
                List<PeopleInfo> peopleList = new List<PeopleInfo>();
                bool isExsited = m_smartbufferlist.Query(name, ref peopleList);
                if (isExsited)
                {
                    SetCurrentRecord(peopleList.First());
                    this.diagnosisText.Focus();
                }
                else
                {
                    this.numberText.Focus();
                }
                
               ;
                
            }

            
        }

        private void diagnosisText_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyValue == 13)
            {
                allCostText.Focus();
            }
        }

        private void allCostText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //try
                //{
                //    m_allCost = float.TryParse(this.allCostText.Text.Trim());
                //}
                //catch (Exception)
                //{
                //    MessageBox("总费用是数值");
                //}

                m_allCost = float.Parse(this.allCostText.Text.Trim());

                //later the caclulation formular will change
                if (m_allCost > 0)
                {
                    m_selfCost =  m_allCost*0.7f;
                    m_compenatecost = m_allCost - m_selfCost;

                    this.selfPayText.Text = m_selfCost.ToString();
                    this.compensatePayText.Text = m_compenatecost.ToString();
                    compensatePayText.Focus();
                }


            }
        }

  

        private void compensatePayText_KeyUp(object sender, KeyEventArgs e)
        {
             if (e.KeyValue == 13)
             {
                 string newValue = compensatePayText.Text.Trim();
                 string oldValue = m_compenatecost.ToString();
                 if (  String.Compare(newValue, oldValue) != 0)
                 {
                     m_compenatecost = float.Parse(newValue);
                     m_selfCost = m_allCost - m_compenatecost;
                     selfPayText.Text = m_selfCost.ToString();
                 }
                 NextRecord.Focus();
             }
        }

        private void NextRecord_Click(object sender, EventArgs e)
        {
           
           if( !String.IsNullOrEmpty(nameText.Text.Trim()) &&
               !String.IsNullOrEmpty(diagnosisText.Text.Trim()) &&
               !String.IsNullOrEmpty(allCostText.Text.Trim()))
           {

               ClearUI();

               // SaveCurrentRecord();

               // UpdatePreviosButton();

               // UpdateSerailStatus();

               // UpdateSmartBuffer();
               
           }
            

        }

        private void ClearUI()
        {
            this.nameText.Clear();
            this.ageText.Clear();
            this.sexText.Clear();
            this.addressText.Clear();
            this.numberText.Clear();

            this.diagnosisText.Clear();
            this.allCostText.Clear();
            this.selfPayText.Clear();
            this.compensatePayText.Clear();
        }

        private void calenderTimePicker_ValueChanged(object sender, EventArgs e)
        {
            m_currentData = this.calenderTimePicker.Text;
        }

    }
}
