using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalibrary;

namespace DataLibrary
{
    public struct Record 
    {
        private string m_diagnose;
        private float m_allcost;
        private float m_compensation;
        private string m_date;
        private PeopleInfo m_p;

        public Record(string name, string no, float age, string address, string sex, string diagose, float allcost,
                      float compensation, string date)
                          
        {
            m_diagnose = diagose;
            m_allcost = allcost;
            m_compensation = compensation;
            m_date = date;
            m_p = new PeopleInfo(name,no,age,address,sex);

        }

        public Record(PeopleInfo p, string diagose, float allcost, float compensation, string date)
        {
            m_p = p;
            m_diagnose = diagose;
            m_allcost = allcost;
            m_compensation = compensation;
            m_date = date;
        }

        public Record(Record record)
        {
            m_p = record.People;
            m_diagnose = record.Diagnose;
            m_allcost = record.AllCost;
            m_compensation = record.Compensation;
            m_date = record.Date;
        }


        

        public string Diagnose
        {
            get { return m_diagnose; }
            set { m_diagnose = value; }
        }

        public float AllCost
        {
            get { return m_allcost; }
            set { m_allcost = value; }
        }

        public float Compensation
        {
            get { return m_compensation; }
            set { m_compensation = value; }
        }

        public float SelfPay
        {
            get { return m_allcost - m_compensation; }
        }

        public string Date
        {
            get { return m_date; }
            set { m_date = value; }
        }

        public PeopleInfo People
        {
            get { return m_p; }
            set { m_p = value; }
        }

        public string Name
        {
            get { return m_p.Name; }
            set { m_p.Name = value; }
        }

        public string No
        {
            get { return m_p.No; }
            set { m_p.No = value;  }
        }

        public float Age
        {
            get { return m_p.Age; }
            set { m_p.Age = value;  }
        }
        public string Address
        {
            get { return m_p.Address; }
            set { m_p.Address = value; }
        }
        public string Sex
        {
            get { return m_p.Sex; }
            set { m_p.Sex = value;  }
        }
        public void Clear()
        {
            m_p.Clear();
            this.Diagnose = "";
            this.AllCost = 0.0f;
            this.Compensation = 0.0f;
        }

        public  string BasicInfo()
        {
            return m_p.Name + " " + m_p.No + " " + AllCost.ToString() + " " + Compensation.ToString();
        }

        public new string ToString()
        { 
            //乡村名称	合疗证号	患者姓名	年龄	性别	就诊时间	诊 断	 
            //总医药费	药品费	检查费	治疗费	材料费	自付	补偿

            //普?中?,0110130030345,赵?麦?芳?,80,女?,2012/1/14,高?冠?心?,17.70 ,,,,,5.70 ,12.00 ,,,,,,,,,,,,,,
            return m_p.Address + "," + m_p.No + "," + m_p.Name + "," + m_p.Age.ToString() + "," + m_p.Sex + "," +
                   Date + "," + Diagnose + "," + AllCost.ToString() + ",,,,," + 
                   SelfPay.ToString() +","+ Compensation.ToString()+",";
        }
    }


}