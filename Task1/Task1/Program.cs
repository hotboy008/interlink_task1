using System;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static string TransformDate(string date)
        {
            string temp = "";

            switch (date.Substring(0, 3))
            {
                case "Jun":
                    temp = date.Replace("Jun", "06");
                    temp = temp.Replace(" ", "-");
                    break;

                case "Jul":
                    temp = date.Replace("Jul", "07");
                    temp = temp.Replace(" ", "-");
                    break;

                default:
                    break;
            }

            return temp;
        }

        static void CalcCSV(string srcFile, string destFile)
        {
            StreamReader sr = new StreamReader(srcFile);
            StreamWriter sw = new StreamWriter(destFile, true, System.Text.Encoding.Default);
            string[] buff = new string[File.ReadAllLines(srcFile).Length];
            string used = "";
            string date = "";
            int hoursCount = 0;
            int count = 0;

            for (int i = 0; !sr.EndOfStream; i++)
            {
                buff[i] = sr.ReadLine();
            }

            sr.BaseStream.Position = 1;

            sw.Write("Name,Date");

            for (int i = 1; i < buff.Length; i++)
            {
                if (!date.Contains(buff[i].Substring(buff[i].IndexOf(',') + 1, 11)))
                {
                    sw.Write("," + TransformDate(buff[i].Substring(buff[i].IndexOf(',') + 1, 11)));
                    Console.WriteLine("," + TransformDate(buff[i].Substring(buff[i].IndexOf(',') + 1, 11)));
                    date += buff[i];
                }
            }

            while (!sr.EndOfStream)
            {
                string emploee = sr.ReadLine();
                if (!used.Contains(emploee.Substring(0, emploee.IndexOf(','))))
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        if (buff[i].Substring(0, buff[i].IndexOf(',')) == emploee.Substring(0, emploee.IndexOf(',')))
                        {

                            if (hoursCount > 0)
                            {
                                hoursCount--;
                            }

                            if (count == 0)
                            {
                                sw.Write(buff[i].Substring(0, buff[i].IndexOf(',')));
                            }

                            try
                            {
                                sw.Write("," + buff[i].Substring(buff[i].LastIndexOf(",") + 1, 3));
                            }
                            catch
                            {
                                sw.Write("," + buff[i].Substring(buff[i].LastIndexOf(",") + 1, 1));
                            }
                            count++;
                        }
                    }

                    used += emploee.Substring(0, emploee.IndexOf(','));

                    if (hoursCount > 0)
                    {
                        sw.Write(string.Concat(Enumerable.Repeat(",0", hoursCount)));
                    }

                    sw.Write("\n");
                    hoursCount = 6;
                    count = 0;
                }

            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            string srcFile = "acme_worksheet.csv";
            string destFile = "result.txt";

            try
            {
                CalcCSV(srcFile, destFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.ReadLine();
            }

            Console.WriteLine("Done...");
            Console.ReadLine();
        }
    }
}
