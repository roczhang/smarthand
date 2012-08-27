using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app
{
    class CostFormular
    {
        private float m_allcost;
        private float m_compentation;
        private float m_ratio = 0.7f;
        private float m_remainder = 1;
        //private float m_selfPay;
        public CostFormular(float allcost,float ratio,float remainder )
        {
            m_ratio = ratio;
            m_allcost = allcost;
            m_remainder = remainder;
            if ( m_allcost *ratio > 20.0f )
            {
                m_compentation = 20.00f;
            }
            else
            {
                double t = (m_allcost * m_ratio + 0.501f);
                m_compentation = (float)System.Math.Floor(t) + m_remainder;  
              
            }
        }

        public float AllCost
        {
            get { return m_allcost; }
        }
        
        public  float SelfCost
        {
            get { return m_allcost - m_compentation;  }
        }

        public  float Compentation
        {
            get { return m_compentation; }
        }
    }
}
