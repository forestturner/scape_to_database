using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsedCPUValue
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
           // List<CPUData> cpu_list;
            try
            {
                
                List<CPUData> cpu_list =  DBconnection.GetCPU();
                foreach (CPUData data in cpu_list)
                {
                    listView1.Items.Add(data.CPU_NAME);
                    listView1.Items.Add(data.CPU_RATING);
                }
            
                //if (cpu_list.Count > 0)
                //{
                   // CPUData cpu;
                   // for (int i = 1; i < cpu_list.Count; i++)
                   // {
                   //     cpu = cpu_list[i];
                   //     listView1.Items[i].SubItems.Add(cpu.CPU_NAME);
                    //    listView1.Items[i].SubItems.Add(cpu.CPU_RATING);
                        //listView1.Items[i].SubItems.Add(cpu.CPU_LOWEST_PRICE_FOUND_ON_EBAY.ToString());
                       // listView1.Items[i].SubItems.Add(cpu.CPU_VALUE.ToString());
                  //  }
                
               // else { MessageBox.Show("there are no CPUs.", "ALERT"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().ToString()); }
        }
    }
}
