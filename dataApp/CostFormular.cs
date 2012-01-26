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
        private float ratio = 0.7f;
        //private float m_selfPay;
        public CostFormular(float allcost)
        {
            m_allcost = allcost;
            if ( m_allcost *ratio > 20.0f )
            {
                m_compentation = 20.00f;
            }
            else
            {
                double t = (m_allcost*ratio + 0.501f);
                m_compentation = (float)System.Math.Floor(t);  
            }
        }

        public CostFormular(float allcost, float compentation)
        {
            m_allcost = allcost;
            m_compentation = compentation;
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
