using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Globalization;

namespace console
{
    class Program
    {
        static void ReadCsv()
        {
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StreamReader(@"C:/Users/zhangroc/app/test-wps.csv", Encoding.GetEncoding("gb2312")), true))
            {
                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                FileStream fs = new FileStream("log.csv", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);

                while (csv.ReadNextRecord())
                {
                    string line = string.Format("{0},{1}",csv[0],csv[1]);                  
                    Console.WriteLine(line);
                    streamWriter.WriteLine(line);
                    streamWriter.Flush();

                    //for (int i = 0; i < fieldCount; i++)
                    //{
                    //    Console.WriteLine("{0},{1}",csv[i],cvs[]);

                    //    streamWriter.WriteLine(csv[i]);
                    //    streamWriter.Flush();

                    //}
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            //ReadCsv();

            string test = "一二三张亚光天天向上好好学习";

            if (test == "张亚光")
                Console.WriteLine("正确");

             //test.
            string test2 = test.Replace("张亚光","吕宾");

            Console.WriteLine(test);
            Console.WriteLine(test2);
            Console.WriteLine();
        }
    }
}
