using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datalibrary
{
   public class PeopleInfo
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

       public string Name
       {
           get { return m_name;  }
           set { m_name = value;  }
       }

       public string No
       {
           get { return m_no;  }
           set { m_no = value; }
       }

       public float Age
       {
           get { return m_age;  }
           set { m_age = value; }
       }

       public string Address
       {
           get { return m_address;  }
           set { m_address = value;  }
       }
        
       public string Sex
       {
           get { return m_sex;  }
           set { m_sex = value; }

       }
        private string m_name="";
        private string m_no = "";
        private float m_age = 0;
        private string m_address = "";
        private string m_sex = "";
    }
}
