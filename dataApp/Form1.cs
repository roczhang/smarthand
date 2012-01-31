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
using System.IO;
using LumenWorks.Framework.IO.Csv;
using app.Properties;

namespace app
{
    public partial class Form1 : Form
    {
        private IList<Record> m_recordList;
        private RecordStructure m_smartbufferlist;
        private StatisticsRecord m_diagnosisList;
        private Record m_currentRecord ;
        private int m_indicator = 0;
        private bool m_isCatched = false;

        //filename for save
        private string m_filepath;
        private bool m_fileChanged = false; // check if user input new date

        private Settings m_setting;
        private int m_noLenght = 0;

        
        public Form1()
        {
            InitializeComponent();

            m_recordList = new List<Record>();
            // initialize the data
            m_setting = new Settings();
            string filePath = m_setting.DBPath;
            m_smartbufferlist = new RecordStructure(filePath);

            m_diagnosisList = new StatisticsRecord();
            m_currentRecord = new Record();
            m_currentRecord.Date = DateTime.Today.ToShortDateString();

            PreviousRecord.Enabled = false;

            // update the data to today
            this.calenderTimePicker.Value = DateTime.Today;


        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableInput(true);

            if (CheckAppChanged(m_filepath, m_recordList.Count, m_fileChanged))
            {
                if (MessageBox.Show("还没有保存当前输入，创建新文件会丢失已经输入信息。\r\n" +
                                  " 你确认丢掉已输入信息而创建新文件吗?", "保存提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            ResetAppStatus();

        }

        private void ResetAppStatus()
        {

            m_filepath = "";
            m_fileChanged = false;

            m_recordList.Clear();
            m_indicator = 0;


            // app title
            UpdateAppTitle(m_filepath, m_fileChanged);

            // input Box
            ClearUI();

            // previous and next button
            PreviousRecord.Text = "上一个";
            NextRecord.Text = "下一个";
            indicatorLable.Text = "0/0";
            
            this.nameText.Focus();
        }

        public void EnableInput(bool enabled)
        {
            this.nameText.Enabled    = enabled;
            this.ageText.Enabled     = enabled;
            this.SexBox.Enabled      = enabled;
            this.addressText.Enabled = enabled;
            this.numberText.Enabled  = enabled;
                   
            this.calenderTimePicker.Enabled = enabled;

            this.DiagnosisBox.Enabled = enabled;
            this.allCostText.Enabled   = enabled;
            this.selfPayText.Enabled   = enabled;
            this.compensatePayText.Enabled = enabled;

            this.NextRecord.Enabled     = enabled;
            //// diable the previous function 
            //this.PreviousRecord.Enabled = enabled; 
            

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void SetCurrentRecord(PeopleInfo people)
        {
            this.numberText.Text = people.No;
            this.ageText.Text = people.Age.ToString();
            this.SexBox.Text = people.Sex;
            this.addressText.Text = people.Address;

            m_currentRecord.People = people;
        }

        private void nameText_KeyUp(object sender, KeyEventArgs e)
       {
            if(e.KeyValue == 13 && ! String.IsNullOrEmpty(nameText.Text.Trim()))
            {
                m_currentRecord.Name = nameText.Text.Trim();
                List<PeopleInfo> peopleList = new List<PeopleInfo>();
                m_isCatched = m_smartbufferlist.Query(m_currentRecord.Name, ref peopleList);
                if (m_isCatched)
                {

                    SetCurrentRecord(peopleList.First());
                    
                    //not noly set the focus and also add the cache date
                    UpdateDiagnosisBox();
                    //this.DiagnosisBox.Focus();
                   

                }
                else
                {
                    this.numberText.Text = "";
                    this.ageText.Text = "";
                    this.SexBox.Text = ""; // statistics number : C(woman) > C(man)
                    this.addressText.Text = "";

                    this.numberText.Focus();
                }
                
            }
        }

        private void UpdateDiagnosisBox()
        {
            string capture;
            IList<String> illnessList;
            if(FindDiagnosisContent(m_currentRecord.Name, calenderTimePicker.Text, m_setting.BeforeDays,out capture, out illnessList))
            {
                DiagnosisBox.Text = capture;
            }

            if (illnessList.Count > 0)
            {
                DiagnosisBox.Items.Clear();
               // DiagnosisBox.Text = illnessList.First();  // statistics data just fill to the list
            }
            foreach (string s in illnessList)
            {
                DiagnosisBox.Items.Add(s);
            }
          

            DiagnosisBox.Focus();


        }

        private bool  FindDiagnosisContent(string name, string day, int days,out string capture, out IList<string> illnessList )
        {
            
            //the user has been appeared in the last two days
            illnessList = new List<string>();
            if (IsExsitedInRecent(name, day, days, out capture))
            {
                return true;
            }
            
            if( m_recordList.Count > 0) // get the first 5 entries which will fill the list
            {
                illnessList = GetToplist(5);
            }
            return false;

            
        }

        private IList<string> GetToplist(int i)
        {
    
            Dictionary<string, int> statistics = new Dictionary<string, int>();
            foreach (Record r in m_recordList)
            {
                if(statistics.ContainsKey(r.Diagnose))
                {
                    statistics[r.Diagnose]++;
                }
                else
                {
                    statistics.Add(r.Diagnose, 1);
                }
            }

            //KeyValuePair<string, int> pair;
            var result = from pair in statistics orderby pair.Value descending select pair;
            List<string> toplist = new List<string>();
            foreach (KeyValuePair<string, int> elem in result)
            {
                if( i <= 0)
                {
                    break;
                }
                i--;
                toplist.Add(elem.Key);
            }

            return toplist;
        }

        private bool IsExsitedInRecent(string name, string day, int days, out string diagnosis)
        {
            diagnosis = "";
            DateTimeConverter convert = new DateTimeConverter();
            DateTime inputDay = (DateTime) convert.ConvertFromString(day);

          
            for (int i = m_recordList.Count-1; i>= 0; i--  )
            {
                Record r = m_recordList[i];
                DateTime currentDay;
                try
                {
                    currentDay = (DateTime) convert.ConvertFromString(r.Date);

                }
                catch (Exception)
                {

                    continue;
                }

                if (currentDay.AddDays(days) >= inputDay)
                {
                    if (r.Name == name)
                    {
                        diagnosis = r.Diagnose;
                        return true;
                    }
                }
                else
                {
                    break; // assume that user input the data from old to latest
                }
            }
            return false;
        }


        private void allCostText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !String.IsNullOrEmpty(allCostText.Text.Trim()))
            {
                
                float allcost;
                if(!float.TryParse(this.allCostText.Text.Trim(),out allcost))
                {
                    ShowMesage(@"总费用应该是数字");
                    allCostText.Text = "";
                    allCostText.Focus();
                    return;
                }
                if (!ValidateMorethanZero(allcost))
                {
                    ShowMesage(@"总费用不能小于0！");
                    allCostText.Text = "";
                    allCostText.Focus();
                    return;
                }

                CostFormular cf = new CostFormular(allcost,m_setting.Ratio);

                m_currentRecord.AllCost = cf.AllCost;
                m_currentRecord.Compensation = cf.Compentation;


                this.allCostText.Text = m_currentRecord.AllCost.ToString("F2");
                this.selfPayText.Text = m_currentRecord.SelfPay.ToString("F2");
                this.compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");

                compensatePayText.Focus();
            }
        }

        private void ShowMesage(string val)
        {
            if (!String.IsNullOrEmpty(val))
            {
                MessageBox.Show(val);
            }
        }

        private void ShowMesage(int lineNo,string promote, string val)
        {
            string format = lineNo.ToString() + ": " + promote + "[" + val + "]";
            ShowMesage(format);
        }

        private void compensatePayText_KeyUp(object sender, KeyEventArgs e)
        {


             if (e.KeyValue == 13 && !String.IsNullOrEmpty(compensatePayText.Text.Trim()))
             {
                 string newValue = compensatePayText.Text.Trim();
                 string oldValue = m_currentRecord.Compensation.ToString();
    
                 if (  String.Compare(newValue, oldValue) != 0)
                 {
                     float newVal;
                     if(!float.TryParse(newValue,out newVal))
                     {
                         ShowMesage(@"总费用应该是数字");
                         compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");
                         compensatePayText.Focus();
                         return;
                     }

                     if (! ValidateMorethanZero(newVal))
                     {
                         ShowMesage(@"补偿费应该大于0");
                         compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");
                         compensatePayText.Focus();
                         return;
                     }

                     if (newVal - m_currentRecord.AllCost > 0)
                     {
                         ShowMesage("补偿费("+newVal.ToString("F2")+")不能大于总费用("+m_currentRecord.AllCost.ToString("F2")+")!");
                         compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");
                         compensatePayText.Focus();
                         return;
                     }

                     m_currentRecord.Compensation = newVal;
                     compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");
                     selfPayText.Text = m_currentRecord.SelfPay.ToString("F2");
                 }
                 
                  NextRecord.Focus();

             }
        }

        private bool ValidateMorethanZero(float val)
        {
            return val > 0.0f;
        }

        private void selfPayText_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13 && !String.IsNullOrEmpty(selfPayText.Text.Trim()))
            {
                float selfPay;
                string newValue = selfPayText.Text.Trim();
                string oldValue = m_currentRecord.SelfPay.ToString();
                if (String.Compare(newValue, oldValue) != 0)
                {
                    if (!float.TryParse(selfPayText.Text.Trim(), out selfPay))
                    {
                        ShowMesage(@"总费用应该是数字");
                        selfPayText.Text = m_currentRecord.SelfPay.ToString("F2");
                        selfPayText.Focus();
                        return;
                    }

                    if (!ValidateMorethanZero(selfPay))
                    {
                        ShowMesage(@"自付费用不能小于0！");
                        selfPayText.Text = m_currentRecord.SelfPay.ToString("F2");
                        selfPayText.Focus();
                        return;
                    }

                    if (selfPay > m_currentRecord.AllCost)
                    {
                        ShowMesage(@"自付费" + selfPay.ToString("F2") + "用不能大于总费用" + m_currentRecord.AllCost.ToString("F2") +
                                   ")!");
                        selfPayText.Text = m_currentRecord.SelfPay.ToString("F2");
                        selfPayText.Focus();
                        return;
                    }


                    m_currentRecord.Compensation = m_currentRecord.AllCost - selfPay;

                    compensatePayText.Text = m_currentRecord.Compensation.ToString("F2");
                    selfPayText.Text = selfPay.ToString("F2");
                }
                
                NextRecord.Focus();
               
            }
        }
        private void NextRecord_Click(object sender, EventArgs e)
        {
           
           
           // create the new record
           if ( m_recordList.Count == 0 || m_indicator == m_recordList.Count -1  )
           {
               if (!String.IsNullOrEmpty(nameText.Text.Trim()) &&
                   !String.IsNullOrEmpty(numberText.Text.Trim()) &&
                   !String.IsNullOrEmpty(addressText.Text.Trim()) &&
                   !String.IsNullOrEmpty(ageText.Text.Trim()) &&
                   !String.IsNullOrEmpty(SexBox.Text.Trim()) &&
                   !String.IsNullOrEmpty(DiagnosisBox.Text.Trim()) &&
                   !String.IsNullOrEmpty(allCostText.Text.Trim()) &&
                   !string.IsNullOrEmpty(selfPayText.Text.Trim())&&
                   !string.IsNullOrEmpty(compensatePayText.Text.Trim()))
               {
                  
                   //when open exsite file ,the current text box display the last record from m_recordlist
                   //Now add the record it will create duplicate code.
                   if(String.IsNullOrEmpty(m_currentRecord.Name))
                   {
                       ClearUI();

                       //update the previous button
                       m_indicator = m_recordList.Count - 1;
                       string tlabel = Indicator2Position(m_indicator) + "/" + m_recordList.Count.ToString();
                       UpdateIndicator(m_indicator, -1, -1, tlabel);

                       return;
                   }

                   SaveCurrentRecord();
                   UpdateAppStatus();
                   
                   m_indicator = m_recordList.Count - 1;

                   int previous = m_indicator;
                   int current = -1;
                   int next = -1;
                   string label = Indicator2Position(m_indicator) + "/" + m_recordList.Count.ToString();
                   UpdateIndicator(previous, current, next, label);

                   UpdateSmartBuffer();
                   ClearUI();
                   nameText.Focus();
               }
               else
               {
                   ShowMesage(@"请检查，纪录需要完整输入。");
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
               UpdateIndicator( previous, current,next, lableStatus);
           }
          
            

        }

        private void UpdateAppStatus()
        {
            m_fileChanged = true;
            UpdateAppTitle(m_filepath,m_fileChanged);
        }

        private void UpdateSmartBuffer()
        {
           if( m_isCatched )
               return;
            m_smartbufferlist.AddRecord(m_currentRecord.People);
        }


        private void UpdateIndicator(int previous, int current, int next, string label)
        {
            UpdateInputUI(current);
            if( previous >= 0)
            {
                PreviousRecord.Text = @"上一个: " + m_recordList[previous].BasicInfo();
                //PreviousRecord.Text = m_recordList[previous].BasicInfo();
                
            }

            if( next > 0 )
            {
                NextRecord.Text = @"下一个: " + m_recordList[next].BasicInfo(); 
            }

            if (! ReferenceEquals( label, null))
            {
                indicatorLable.Text = label;            
            }
        }

        private void UpdateInputUI(int position)
        {
            if (position >= 0)
            {
                Record current = m_recordList[position];

                nameText.Text = current.Name;
                numberText.Text = current.No;
                ageText.Text = current.Age.ToString();
                SexBox.Text = current.Sex;
                addressText.Text = current.Address;

                calenderTimePicker.Text = current.Date;

                DiagnosisBox.Text = current.Diagnose;
                allCostText.Text = current.AllCost.ToString("F2");
                compensatePayText.Text = current.Compensation.ToString("F2");
                selfPayText.Text = current.SelfPay.ToString("F2");
            }
        }
       
        private void SaveCurrentRecord()
        {
            UpdateCurrentDate();
            Record r =new Record(m_currentRecord);
            m_recordList.Add(r);
            m_diagnosisList.Add(r.Diagnose);
        }

        private void UpdateCurrentDate()
        {
            m_currentRecord.Date = this.calenderTimePicker.Text;
        }

        private void ClearUI()
        {
            this.nameText.Clear();
            this.ageText.Clear();
            this.SexBox.Text="";
            this.addressText.Clear();
            this.numberText.Clear();

            this.DiagnosisBox.Text="";
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
                string temp = numberText.Text.Trim();
                if (temp.Length == 13)
                {
                    m_noLenght = 0;
                    m_currentRecord.No = numberText.Text.Trim();
                    addressText.Focus();
                }
                else
                {
                    m_noLenght++;
                    if (m_noLenght >= 3)
                    {
                        ShowMesage(@"医疗号长度应该是13位:现在长度为:" + temp.Length + ". 请确认");
                    }
                }

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
                float age;
                if( !float.TryParse(ageText.Text.Trim(),out age))
                {
                    ShowMesage(@"年龄必须是数值");
                    ageText.Text = "";
                    return;
                }
                m_currentRecord.Age = age;
                SexBox.Text = "女";
                SexBox.Focus();
            }
        }


        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CheckAppChanged(m_filepath, m_recordList.Count,m_fileChanged))
            {
                if (MessageBox.Show("还没有保存当前输入，创建新文件会丢失已经输入信息。\r\n" +
                                  " 你确认丢掉已输入信息而打开另外一个文件吗?", "保存提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return ;
                }
            }


            //step1 open file and save the filepath
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv(*.csv)|*.csv|all(*.*)|*.*";
            
            if ( !String.IsNullOrEmpty(m_filepath))
                ofd.InitialDirectory = m_filepath;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                m_filepath = ofd.FileName;
            }
            else
            {
                return;
            }

            try
            {
                //step2 initialize the recordlist
                 m_recordList.Clear();
                 m_diagnosisList.Clear();
                
                 ReaderCSV(m_filepath);
                 foreach (Record record in m_recordList)
                 {
                     m_diagnosisList.Add(record.Diagnose);
                 }
                //m_currentRecord = m_recordList.Last();
            }
            catch(Exception val)
            {
                ShowMesage(val.Message + "\r\n"+ 
                    "问题：该文件被其他应用程序已打开" +"\r\n"+
                    "建议：关掉其他应用程序，重新打开");
                return;
            }
            

            //step3 update UI
            if( m_recordList.Count > 0)
            {
                m_indicator = m_recordList.Count - 1;
                UpdateInputUI(m_indicator);
                UpdateAppTitle(m_filepath,m_fileChanged);

                //step4 update the indicator
                int previous = m_indicator - 1;
                if (previous < 0)
                    previous = 0;

                //step5 update the indicator
                int next = -1; // don't initial the next button

                string label = Indicator2Position(m_indicator).ToString() + "/" + m_recordList.Count.ToString();
                UpdateIndicator(previous, m_indicator, next, label);


                //enable UI
                EnableInput(true);
            }



        }

        private bool CheckAppChanged(string filePath, int recordCount, bool changed)
        {
            // check the current whether it has already open new file
            // create new file and input data but no save so far
            if ((String.IsNullOrEmpty(filePath) && recordCount != 0) ||
                changed == true)
            {
                return true;
            }
            return false;
        }

        private void UpdateAppTitle(string filepath, bool changed)
        {
            string save = "";
            if (changed)
                save = "(*)";
            this.Text = "小助手: " + filepath + save;
        }

        private void ReaderCSV(string filePath)
        {
            string path = Path.GetDirectoryName(filePath);
            if ( !Directory.Exists(path))
                return;

            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StreamReader(filePath, Encoding.GetEncoding("gb2312")), true))
            {
                int fieldCount = csv.FieldCount;

                int igore = 3; // don't read the header line
                               // igore the 2-4 line ( 0 , 1, 2, 3)
                int lineNum = 1 ;
                while (csv.ReadNextRecord())
                {
                    lineNum++;
                   if (igore > 0) // igore header in the first 4 lines
                    {
                        igore--;
                        continue;
                    }
                          
                    // create one record
                   // //乡村名称	合疗证号	患者姓名	年龄	性别	就诊时间	诊 断	 总医药费	药品费	检查费	治疗费	材料费	自付	补偿
          
                    string address = csv[0].Trim().Replace("?","");
                    string no = csv[1].Trim().Replace("?","");
                    string name = csv[2].Trim().Replace("?","");

                    if ( string.IsNullOrEmpty(address) || string.IsNullOrEmpty(no) || string.IsNullOrEmpty(name))
                        continue;

                    float age = 0.0f;
                    if( !float.TryParse(csv[3].Trim().Replace("?",""),out age))
                    {
                        ShowMesage(lineNum, "年龄不合法", csv[3].Trim().Replace("?", ""));
                    }

                    string sex = csv[4].Trim().Replace("?","");
                    PeopleInfo p = new PeopleInfo(name,no,age,address,sex);

                    string date = csv[5].Trim().Replace("?","");
                    string diagose = csv[6].Trim().Replace("?","");

                    float allcost = 0.0f;
                    if (!float.TryParse(csv[7].Trim().Replace("?",""),out allcost))
                    {
                        ShowMesage(lineNum, "总费用不合法", csv[7].Trim());
                    }
                    //float selfPay = csv[12];

                    float compenation = 0.0f;
                    if (!float.TryParse(csv[13].Trim().Replace("?", ""),out compenation))
                    {
                        ShowMesage(lineNum, "补偿费用不合法", csv[13].Trim());
                    }

                    Record r = new Record(p,diagose,allcost,compenation,date);
              
                    m_recordList.Add(r);
                }
                
            }
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
                if (next > m_recordList.Count - 1)
                    next = m_recordList.Count - 1; 
            }
            else
            {
                current = m_indicator + 1;
                previous = m_indicator;
                if (previous == -1)
                    previous = 0;

                next = m_indicator + 2;
                if (next >= m_recordList.Count - 1)
                    next = -1;

                
            }

            string label = Indicator2Position(m_indicator).ToString() + "/" + m_recordList.Count;
            UpdateIndicator(previous, current, next, label);
        }

        private int Indicator2Position(int indicator)
        {
            return indicator + 1;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(m_filepath))
            {
                GetFilePath();
            }


            if (!String.IsNullOrEmpty(m_filepath))
            {
                try
                {
                    SaveFile(m_filepath);
                }
                catch (Exception val)
                {
                    ShowMesage(val.Message + "\r\n" +
                     "问题：该文件被其他应用程序已打开" + "\r\n" +
                     "建议：关掉其他应用程序，重新打开");
                    return;
                }
                m_fileChanged = false;
                UpdateAppTitle(m_filepath, m_fileChanged);
            }
        }

        private void GetFilePath()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv(*.csv)|*.csv";
            sfd.AddExtension = true;
            sfd.ValidateNames = true;
            sfd.CheckPathExists = true; 

            sfd.ShowDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                m_filepath = sfd.FileName;
            }
        }

        private void SaveFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));

            //step1:  write header

            //,,普集街,卫生院（村卫生室或诊所）新型农村合作医疗门诊统筹补偿登记表,,,,,,,,,,,,,,,,,,,,,,,,
            //2012,,,年                                  ,1,月,卫生院    （村卫生室或诊所 ）              ,,,代号,1119,,,,,,,,,,,,,,,,,
            //,填报单位： （盖章）,,年                                  ,,,,,,,,,,,,,,,,,,,,,,,,
            //乡村名称	合疗证号	患者姓名	年龄	性别	就诊时间	诊 断	 总医药费	药品费	检查费	治疗费	材料费	自付	补偿
            string line1 = @",,普集街,卫生院（村卫生室或诊所）新型农村合作医疗门诊统筹补偿登记表,,,,,,,,,,,";
            string line2 = @"2012,,,年                                  ,1,月,卫生院    （村卫生室或诊所 ）             ,,,,代号,1119,,,";
            string line3 = @",填报单位： （盖章）,,年                                  ,,,,,,,,,,";

                            //普中, 0110130030345,赵麦芳,80,女, 2012/1/14,高冠心,17.70 ,,,,,5.70 ,12.00 ,,,,,,,,,,,,,,
            string line4 = @"乡村名称,合疗证号,患者姓名,年龄,性别,就诊时间,诊断,总医药费,药品费,检查费,治疗费,材料费,自付,补偿,,";

            streamWriter.WriteLine(line1);
            streamWriter.WriteLine(line2);
            streamWriter.WriteLine(line3);
            streamWriter.WriteLine(line4);

            //write data
            foreach (Record r in m_recordList)
            {
                streamWriter.WriteLine(r.ToString());
            }
            streamWriter.Flush();
            fs.Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // create new file and input data but no save so far
            if(( String.IsNullOrEmpty(m_filepath) && m_recordList.Count != 0 ) ||
                 m_fileChanged == true)
            {
              
                if (MessageBox.Show("还没有保存文件，需要退出吗?","保存提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            

            //releaes the system resource

            Application.Exit();

            // system will automate to save the smart buffer to file.
        }

        private void SaveAsStripMenuItem2_Click(object sender, EventArgs e)
        {
            GetFilePath();
            if(!String.IsNullOrEmpty(m_filepath))
            {
                try
                {
                    SaveFile(m_filepath);
                }
                catch (Exception val)
                {
                    ShowMesage(val.Message + "\r\n" +
                     "问题：该文件被其他应用程序已打开" + "\r\n" +
                     "建议：关掉其他应用程序，重新打开");
                    return;
                }
                
                m_fileChanged = false;
                UpdateAppTitle(m_filepath,m_fileChanged);
            }
        }

        private void statisticsPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int peopleCount = m_recordList.Count;
            float allCost = 0.0f;
            float compentationCost = 0.0f;
            float selfCost =0.0f;
            foreach (Record r in m_recordList)
            {
                allCost += r.AllCost;
                compentationCost += r.Compensation;
            }
            selfCost = allCost - compentationCost;
            MessageBox.Show("人    数：" + peopleCount.ToString("F2") + "\r\n" +
                            "总费用：" + allCost.ToString("F2") + "\r\n" +
                            "补    偿：" + compentationCost.ToString("F2") + "\r\n" +
                            "自付费：" + selfCost.ToString("F2"),
                            "统计信息", MessageBoxButtons.OK);

        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMesage("升级后实现");
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作    者：张亚光 \r\n" +
                            "设    计：吕宾 \r\n" +
                            "推广者：张美红 张光", "作者介绍", MessageBoxButtons.OK);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // create new file and input data but no save so far
            if ((String.IsNullOrEmpty(m_filepath) && m_recordList.Count != 0) ||
                 m_fileChanged == true)
            {

                if (MessageBox.Show("还没有保存文件，需要退出吗?", "保存提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;

                }
            }
        }

        private void introductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show( "农村医疗合作信息录入助手简介：\r\n"+ @"该软件简称:'小助手'，"+
                "帮你快速实现医疗信息录入并生成报表，其特点准确，高效。" + "让你轻松跨越数字鸿沟！",
                "软件介绍", MessageBoxButtons.OK);

        }

        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 12288)
            {
                e.KeyChar = (char)32;
            }

            if ((int)e.KeyChar >= 65280 && (int)e.KeyChar <= 65375)
            {
                e.KeyChar =(char)((int)e.KeyChar -65248);
            }
        }

        private void allCostText_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks> 
        private string DoubleToHalf(string dstring)
        {
            char[] c = dstring.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if ( c[i] == 12288)
                {
                    c[i] = (char)32;
                }
                else if ( c[i] > 65280 && c[i] < 65375)
                {
                    c[i] = (char)((int)c[i] - 65248);
                }
            }
            return new string(c);
        }

        private void noText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (numberText.Text.Trim().Count() == 13)
            {
                numberText.Text = numberText.Text.Trim().Substring(0, 13);
                e.KeyChar =' ';
            }
            Text_KeyPress(sender, e);

        }


        private void SexBox_KeyUp(object sender, KeyEventArgs e)
        {
            if( (int)e.KeyValue == 13 )
            {
                if (SexBox.Text == "男" || SexBox.Text == "女")
                {
                    this.m_currentRecord.Sex = SexBox.Text;
                    this.DiagnosisBox.Focus();
                }
            }
        }

        private void DiagnosisBox_KeyUp(object sender, KeyEventArgs e)
        {
            if((int)e.KeyValue == 13 && !String.IsNullOrEmpty(DiagnosisBox.Text.Trim()))
            {
                m_currentRecord.Diagnose = DiagnosisBox.Text.Trim();
                allCostText.Focus();
            }
            
        }
    }
}
