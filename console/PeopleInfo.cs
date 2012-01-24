using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordLibrary
{
    class PeopleInfo
    {
       public PeopleInfo(string name, string no, float age, string address, string sex)
        {
            m_name = name;
            m_no = no;
            m_age = age;
            m_address = address;
            m_sex = sex;
        }

       public static bool operator ==(PeopleInfo left, PeopleInfo right)
        {
            if( left.m_name == right.m_name && left.m_no == right.m_no)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (PeopleInfo left, PeopleInfo right)
        {
            return !(right == left);
        }

        public new string ToString()
        {
            return m_address + ":" + m_no + ":" + m_name + ":" + m_age + ":" + m_sex;
        }

        public string m_name="";
        public string m_no="";
        public float m_age=0;
        public string m_address="";
        public string m_sex="";
    }
}
