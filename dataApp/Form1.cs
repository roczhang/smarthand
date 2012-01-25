using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLibrary;
using Datalibrary;

namespace app
{
    public partial class Form1 : Form
    {
        private RecordStructure m_smartbufferlist;
        private IList<Record> m_recordList;
        private Record m_currentRecord ;
        //private string m_name = "";
        //private string m_no = "";
        //private string m_address = "";
        //private float m_age = 0.0f;
        //private string m_sex = "";

        //private string m_currentData = DateTime.Today.ToShortDateString();

        //private string m_diagose = "";

        //private float m_allCost = 0.0f;
        //private float m_selfPay = 0.0f;
        //private float m_compenatecost = 0.0f;

        
        public Form1()
        {
            InitializeComponent();
            // initialize the data
            string filePath = @"C:\Users\zhangroc\app\data\DB.csv";
            m_smartbufferlist = new RecordStructure(filePath);

            m_recordList = new List<Record>();
            m_currentRecord = new Record();
            m_currentRecord.Date = DateTime.Today.ToShortDateString();
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


        private void SetCurrentRecord(PeopleInfo people)
        {
            this.numberText.Text = people.No;
            this.ageText.Text = people.Age.ToString();
            this.sexText.Text = people.Sex;
            this.addressText.Text = people.Address;

            m_currentRecord.People = people;
        }

        private void nameText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13 && ! String.IsNullOrEmpty(nameText.Text.Trim()))
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
            if ( e.KeyValue == 13 &&!String.IsNullOrEmpty(diagnosisText.Text.Trim()))
            {
                m_currentRecord.Diagnose = this.diagnosisText.Text.Trim();
                allCostText.Focus();
            }
        }

        private void allCostText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(allCostText.Text.Trim()))
            {
                //try
                //{
                //    m_allCost = float.TryParse(this.allCostText.Text.Trim());
                //}
                //catch (Exception)
                //{
                //    MessageBox("总费用是数值");
                //}

                m_currentRecord.AllCost = float.Parse(this.allCostText.Text.Trim());

                //later the caclulation formular will change
                if (m_currentRecord.AllCost > 0)
                {
                    m_currentRecord.Compensation = m_currentRecord.AllCost * 0.7f;
                    //m_currentRecord.SelfPaym_compenatecost = m_currentRecord.AllCost - m_currentRecord.SelfPay;

                    this.selfPayText.Text = m_currentRecord.SelfPay.ToString();
                    this.compensatePayText.Text = m_currentRecord.Compensation.ToString();
                    compensatePayText.Focus();
                }


            }
        }

        private void compensatePayText_KeyUp(object sender, KeyEventArgs e)
        {
             if (e.KeyValue == 13 && !String.IsNullOrEmpty(compensatePayText.Text.Trim()))
             {
                 string newValue = compensatePayText.Text.Trim();
                 string oldValue = m_currentRecord.Compensation.ToString();
                 if (  String.Compare(newValue, oldValue) != 0)
                 {
                     m_currentRecord.Compensation = float.Parse(newValue);
                     selfPayText.Text = m_currentRecord.SelfPay.ToString();
                 }
                 NextRecord.Focus();
             }
        }

        private void selfPayText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(selfPayText.Text.Trim()))
            {
                float selfPay = float.Parse(selfPayText.Text.Trim());
                m_currentRecord.Compensation = m_currentRecord.AllCost - selfPay;

                compensatePayText.Text = m_currentRecord.Compensation.ToString();
                NextRecord.Focus();
            }
        }
        private void NextRecord_Click(object sender, EventArgs e)
        {
           
           if( !String.IsNullOrEmpty(nameText.Text.Trim()) &&
               !String.IsNullOrEmpty(diagnosisText.Text.Trim()) &&
               !String.IsNullOrEmpty(allCostText.Text.Trim()))
           {
                          


               SaveCurrentRecord();

               // UpdatePreviosButton();

               // UpdateSerailStatus();

               // UpdateSmartBuffer();

               ClearUI();
               
           }
            

        }

        private void SaveCurrentRecord()
        {
            m_recordList.Add(m_currentRecord);
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

            m_currentRecord.Clear();
        }

        private void calenderTimePicker_ValueChanged(object sender, EventArgs e)
        {
            m_currentRecord.Date = this.calenderTimePicker.Text;
        }

        private void numberText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(numberText.Text.Trim()))
            {
                m_currentRecord.No = numberText.Text.Trim();

                addressText.Focus();
            }
        }

        private void addressText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(addressText.Text.Trim()))
            {
                m_currentRecord.Address = addressText.Text.Trim();

                ageText.Focus();
            }

        }

        private void ageText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(ageText.Text.Trim()))
            {
                m_currentRecord.Age = float.Parse(ageText.Text.Trim());

                sexText.Focus();
            }
        }

        private void sexText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(sexText.Text.Trim()))
            {
                m_currentRecord.Sex = sexText.Text.Trim();

                diagnosisText.Focus();
            }
        }



    }
}
