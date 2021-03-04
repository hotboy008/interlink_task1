using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
