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
        private int m_indicator = 0;
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
            m_indicator = 0;
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
           
           
           // create the new record
           if ( m_recordList.Count == 0 || m_indicator == m_recordList.Count -1  )
           {
               if (!String.IsNullOrEmpty(nameText.Text.Trim()) &&
                   !String.IsNullOrEmpty(diagnosisText.Text.Trim()) &&
                   !String.IsNullOrEmpty(allCostText.Text.Trim()))
               {
                  
                   SaveCurrentRecord();
                   m_indicator = m_recordList.Count - 1;
                   UpdateIndicator(m_indicator);

                   Record previous = m_currentRecord;
                   Record current = null;
                   Record next = null;
                   string label = Indicator2Position(m_indicator) + "/" + m_recordList.Count.ToString();
                   UpdateIndicator(previous, current, next, label);

                   // UpdateSmartBuffer();
                   ClearUI();
                   nameText.Focus();
               }
           }
           else
           {
               m_indicator++;

               int current = m_indicator;
               int previous = m_indicator - 1;
               int next = m_indicator + 1;
               if ( next > m_recordList.Count - 1)
                   next = m_recordList.Count - 1;

               string lableStatus = Indicator2Position(m_indicator).ToString() + "/" + m_recordList.Count.ToString();
               UpdateIndicator( m_recordList[previous], m_recordList[current],m_recordList[next], lableStatus);
           }
          
            

        }

        private void UpdateIndicator(int indicator)
        {
            if( m_recordList.Count == 0 )
                return;
            
            //if( indicator == 0 )
            //{
            //    UpdateIndicator()
            //}
            //Record previous = m_currentRecord;
            //Record current = null;
            //Record next = null;
        }

        private void UpdateIndicator(Record previous, Record current, Record next, string label)
        {
            UpdateInputUI(current);
            if(! ReferenceEquals( previous, null))
            {
                PreviousRecord.Text = @"上一个: " + previous.BasicInfo(); 
            }

            if( ! ReferenceEquals( next, null) )
            {
                NextRecord.Text = @"下一个: " + next.BasicInfo(); 
            }

            if (! ReferenceEquals( label, null))
            {
                indicatorLable.Text = label;            
            }
        }

        private void UpdateInputUI(Record current)
        {
            if ( !ReferenceEquals(current,null))
            {
                nameText.Text = current.Name;
                numberText.Text = current.No;
                ageText.Text = current.Age.ToString();
                sexText.Text = current.Sex;
                addressText.Text = current.Address;

                calenderTimePicker.Text = current.Date;

                diagnosisText.Text = current.Diagnose;
                allCostText.Text = current.AllCost.ToString();
                compensatePayText.Text = current.Compensation.ToString();
                selfPayText.Text = current.SelfPay.ToString();
            }
        }
       
        private void SaveCurrentRecord()
        {
            Record r =new Record(m_currentRecord);
            m_recordList.Add(r);
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

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //initialize the m_indicator which will point the last node of poeple
            //add the previousrecordbutton
            m_indicator = 0;
        }

        private void PreviousRecord_Click(object sender, EventArgs e)
        {
            m_indicator--;

            int current = 0;
            int next = 0;
            int previous = 0;
            if( m_indicator == -1 )
            {
                m_indicator = 0;
                previous = current = m_indicator;
                next = current + 1;
            }
            else
            {
                current = m_indicator;
                previous = m_indicator - 1;
                if (previous == -1)
                    previous = 0;
                next = m_indicator + 1;
            }

            string label = Indicator2Position(m_indicator).ToString() + "/" + m_recordList.Count;
            UpdateIndicator(m_recordList[previous], m_recordList[current], m_recordList[next], label);
        }

        private int Indicator2Position(int indicator)
        {
            return indicator + 1;
        }
    }
}
