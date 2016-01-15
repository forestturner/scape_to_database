using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCPUValue
{
    public class CPUData
    {
        private int CPU_number;    
        private string CPU_name;
        private string CPU_rating;
        //private string CPU_lowest_price_found_on_ebay;
       // private string CPU_value;

   

        public CPUData() { }

        public int CPU_NUMBER
        {
            get { return CPU_number; }
            set { CPU_number = value; }
        }
       // public string CPU_VALUE
       // {
       //     get { return CPU_value; }
       //     set { CPU_value = value; }
       // }
      //  public string CPU_LOWEST_PRICE_FOUND_ON_EBAY
      //  {
      //      get { return CPU_lowest_price_found_on_ebay; }
       //     set { CPU_lowest_price_found_on_ebay = value; }
      //  }
        public string CPU_RATING
        {
            get { return CPU_rating; }
            set { CPU_rating = value; }
        }
        public string CPU_NAME
        {
            get { return CPU_name; }
            set { CPU_name = value; }
        }
    }
}
