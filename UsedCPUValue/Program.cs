using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCPUValue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            Scrap scrap = new Scrap();
            list = scrap.grab_page_return_list_of_strings("https://www.cpubenchmark.net/high_end_cpus.html", "tr");
            
        }
    }
}
