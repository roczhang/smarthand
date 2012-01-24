using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Globalization;
using RecordLibrary;

namespace console
{
    class Program
    {
        static void CreateOrgDB(string filePath)
        {
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StreamReader(filePath, Encoding.GetEncoding("gb2312")), true))
            {
                int fieldCount = csv.FieldCount; 

                FileStream fs = new FileStream("log.csv", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);

                int lineNumber = 0;
                //int igore = 3; // igore the first 4 line ( 0 , 1, 2, 3)
                while (csv.ReadNextRecord())
                {
                    Console.Write("{0}: ", lineNumber);
                    lineNumber++;

                    //if (igore > 0) // igore the format
                    //{
                    //    igore--;
                    //    continue;

                    //}

                    if( csv.HasHeaders)
                    {
                        foreach (string header in csv.GetFieldHeaders())
                            Console.Write(header);
                    }


                    string record = "";
                    Boolean done = false;
                    for (int i = 0 ; i < 5; i++)
                    {
                        if (!String.IsNullOrEmpty(csv[0]))
                        {
                            Console.Write(" {0} ", csv[i]);
                            record = record + csv[i] + ",";
                        }
                        else
                            done = true;
                    }

                    if (!done)
                    {
                        streamWriter.WriteLine(record);
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }



                }

                streamWriter.Close();
            }
        }

        static List<string> CheckDir(DirectoryInfo di)
        {
            List<string> filelists = new List<string>();
            foreach (FileInfo fi in di.GetFiles())
            {
                //work   on   fi 
                //if (fi.FullName.EndsWith("DB.csv" ))
                {
                    filelists.Add(fi.FullName);
                    Console.WriteLine(fi.FullName);
                }
            }

            //foreach (DirectoryInfo dic in di.GetDirectories())
            //{
            //    CheckDir(dic);
            //}

            return filelists;
        } 
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\zhangroc\app\data\DB.csv";
            RecordStructure rs = new RecordStructure(filePath);

            List<PeopleInfo> recordlist = new List<PeopleInfo>();
            Boolean isfind = rs.Query("程中", ref recordlist);
            if ( isfind )
            {
                foreach (PeopleInfo p in recordlist)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}


