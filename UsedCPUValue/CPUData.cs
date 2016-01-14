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

        public int CPU_NUMBER
        {
            get { return CPU_number; }
            set { CPU_number = value; }
        }
        private string CPU_name;

        public string CPU_NAME
        {
            get { return CPU_name; }
            set { CPU_name = value; }
        }
        private int CPU_rating;

        public int CPU_RATING
        {
            get { return CPU_rating; }
            set { CPU_rating = value; }
        }
        private float CPU_lowest_price_found_on_ebay;

        public float CPU_LOWEST_PRICE_FOUND_ON_EBAY
        {
            get { return CPU_lowest_price_found_on_ebay; }
            set { CPU_lowest_price_found_on_ebay = value; }
        }
        private float CPU_value;

        public float CPU_VALUE
        {
            get { return CPU_value; }
            set { CPU_value = value; }
        }

        public CPUData() { }


    }
}
