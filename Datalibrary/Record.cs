using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalibrary;

namespace DataLibrary
{
    public class Record : PeopleInfo
    {
        public Record(string name, string no, float age, string address, string sex, string diagose, float allcost,
                      float compensation, string date) :
                          base(name, no, age, address, sex)
        {
            m_diagnose = diagose;
            m_allcost = allcost;
            m_compensation = compensation;
            m_date = date;
        }

        public Record(PeopleInfo p, string diagose, float allcost, float compensation, string date) :
            base(p.Name, p.No, p.Age, p.Address, p.Sex)
        {
            m_diagnose = diagose;
            m_allcost = allcost;
            m_compensation = compensation;
            m_date = date;
        }

        public Record(Record record)
        {
            this.People = record.People;
            m_diagnose = record.Diagnose;
            m_allcost = record.AllCost;
            m_compensation = record.Compensation;
            m_date = record.Date;

        }

        public Record() 
        {

        }

        private string m_diagnose = "";
        private float m_allcost = 0;
        private float m_compensation = 0;
        private string m_date = "";
        

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
            get { return (PeopleInfo) this; }
            set
            {
                this.Name = value.Name;
                this.No = value.No;
                this.Address = value.Address;
                this.Sex = value.Sex;
                this.Age = value.Age;
            }
        }

        public void Clear()
        {
            this.Name = "";
            this.No = "";
            this.Address = "";
            this.Sex = "";
            this.Age = 0.0f;

            this.Diagnose = "";
            this.AllCost = 0.0f;
            this.Compensation = 0.0f;
        }

        public  string BasicInfo()
        {
            return Name + " " + No + " " + AllCost.ToString() + " " + Compensation.ToString();
        }
    }


}