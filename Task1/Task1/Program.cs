using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
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
