using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalibrary;

namespace DataLibrary
{
    public class Record : PeopleInfo
    {
        public Record(string name, string no, float age, string address, string sex,string diagose, float allcost, float selfPay, string date):
            base(name,no,age,address,sex)
        {
            m_diagnose = diagose;
            m_allcost = allcost;
            m_selfPay = selfPay;
            m_date = date;
        }

        private string m_diagnose="";
        private float m_allcost=0;
        private float m_selfPay=0;
        private string m_date = "";
        //private float m_compensatePay

        public string Diagnose
        {
            get { return m_diagnose; }
        }

        public float AllCost
        {
            get { return m_allcost; }
        }
        
        public float SelfPay
        {
            get { return m_selfPay; }
        }
        public float ComponationPay
        {
            get { return m_allcost - m_selfPay; }
        }
        public string Date
        {
            get { return m_date;  }
        }
    }
}
