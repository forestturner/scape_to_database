using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace UsedCPUValue
{
    public static class DBconnection
    {
        public static SqlConnection getConnection()
        {
            string connection_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\forest\documents\visual studio 2013\Projects\UsedCPUValue\UsedCPUValue\CPU_database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connection_string);
            return connection;
        }
        public static void addCPU(string CPU_name,int CPU_rating,float CPU_lowest_price_found_on_ebay,float CPU_value)
        {
            string insert_statement = "INSERT INTO CPU(CPU_name, CPU_rating,CPU_lowest_price_found_on_ebay,CPU_value) VALUES (@CPU_name, @CPU_rating,@CPU_lowest_price_found_on_ebay,@CPU_value)";
            SqlConnection conn = getConnection();
            SqlCommand insert_command = new SqlCommand(insert_statement, conn);
            insert_command.Parameters.AddWithValue("@CPU_name", CPU_name);
            insert_command.Parameters.AddWithValue("@CPU_rating", CPU_rating);
            insert_command.Parameters.AddWithValue("@CPU_lowest_price_found_on_ebay", CPU_lowest_price_found_on_ebay);
            insert_command.Parameters.AddWithValue("@CPU_value", CPU_value);
            try { conn.Open(); insert_command.ExecuteNonQuery(); }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
        }
        public static List<CPUData>GetCPU()
        {
            List<CPUData> cpu_list = new List<CPUData>();
            SqlConnection conn = getConnection();
            string select_statement = "SELECT = FROM CPU ORDER BY CPU_rating";
            SqlCommand select_command = new SqlCommand(select_statement,conn);
            try
            {
                conn.Open();
                SqlDataReader reader = select_command.ExecuteReader();
                while(reader.Read())
                {
                    CPUData CPU = new CPUData();
                    
                    
                }
            }

        }
    }
}
