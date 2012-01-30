using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLibrary
{
   public class StatisticsRecord
    {
        private Dictionary<string, int> buffer;
        public StatisticsRecord()
        {
            buffer = new Dictionary<string, int>();
        }

        public bool Add(string name)
        {
            if( buffer.ContainsKey(name))
            {
                buffer[name] = buffer[name] + 1;
            }
            else
            {
                buffer[name] = 0;
            }
            
            return true;
        }

        public IList<string> Toplist(int count)
        {
     

            Dictionary<int, IList<string>> sort = new Dictionary<int, IList<string>>();
            foreach (KeyValuePair<string, int> r in buffer)
            {
                   if(sort.ContainsKey(r.Value))
                   {
                       IList<String> rlist = sort[r.Value];
                       foreach (string s in rlist)
                       {
                           if (String.Compare(s, r.Key) != 0)
                           {
                               rlist.Add(s);
                               break;
                           }
                       }
                   }
                   else
                   {
                       IList < String >  rlist  = new List<string>();
                       rlist.Add(r.Key);
                       sort.Add(r.Value,rlist);
                   }
            }

            IList<string> toplist = new List<string>();
            foreach (KeyValuePair<int, IList<string>> pair in sort)
            {
                bool done = false;
                foreach (string s in pair.Value)
                {
                    toplist.Add(s);
                    count--;
                    if(count >0)
                    {
                        done = true;
                        break;
                    }
                }    
                if(done)
                {
                    break;
                }
            }
            return toplist;
        }


       public void Clear()
       {
           buffer.Clear();
       }
    }
}
