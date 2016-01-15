using UsedCPUValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsedCPUValue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CPUData> list = new List<CPUData>();
            Scrap scrap = new Scrap();
            ////*[@id="rt2368"]/div/text()
            ////*[@id="rt2069"]/div/text()
            //*/div/text()
            //list = scrap.grab_page_return_list_of_strings("https://www.cpubenchmark.net/high_end_cpus.html#", "//*/div/text()");
            list = scrap.GameRankingsFromPage();
            foreach (CPUData cpu in list)
            {
                DBconnection.addCPU(cpu);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Chart());
        }
    }
}






           // foreach (string s in list)
            //{
            //    Console.WriteLine(s);
            //}
            //Chart chart = new Chart();
            
    
       // public static CPUData scrap_and_return()
        //{

       // }
