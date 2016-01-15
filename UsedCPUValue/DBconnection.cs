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
        public static void addCPU(CPUData cpu)//string CPU_name,int CPU_rating,float CPU_lowest_price_found_on_ebay,float CPU_value)
        {
            string CPU_name                         = cpu.CPU_NAME;
            string CPU_rating                       = cpu.CPU_RATING;
         //   string  CPU_lowest_price_found_on_ebay   = cpu.CPU_LOWEST_PRICE_FOUND_ON_EBAY;
        //    string  CPU_value                        = cpu.CPU_VALUE;
           // string insert_statement                 = "INSERT INTO CPU(CPU_name, CPU_rating,CPU_lowest_price_found_on_ebay,CPU_value) VALUES (@CPU_name, @CPU_rating,@CPU_lowest_price_found_on_ebay,@CPU_value)";
            string insert_statement = "INSERT INTO CPU(CPU_name, CPU_rating) VALUES (@CPU_name, @CPU_rating)";
            SqlConnection conn = getConnection();
            SqlCommand insert_command = new SqlCommand(insert_statement, conn);
            insert_command.Parameters.AddWithValue("@CPU_name", CPU_name);
            insert_command.Parameters.AddWithValue("@CPU_rating", CPU_rating);
           // insert_command.Parameters.AddWithValue("@CPU_lowest_price_found_on_ebay", CPU_lowest_price_found_on_ebay);
          //  insert_command.Parameters.AddWithValue("@CPU_value", CPU_value);
            try { conn.Open(); insert_command.ExecuteNonQuery(); }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
        }
        public static List<CPUData>GetCPU()
        {
            List<CPUData> cpu_list = new List<CPUData>();
            SqlConnection conn = getConnection();
            string select_statement = "SELECT * FROM CPU ORDER BY CPU_rating";
            SqlCommand select_command = new SqlCommand(select_statement,conn);
            try
            {
                conn.Open();
                SqlDataReader reader = select_command.ExecuteReader();
                while(reader.Read())
                {
                    CPUData CPU = new CPUData();
                    CPU.CPU_NAME = reader["CPU_NAME"].ToString();
                    CPU.CPU_RATING = reader["CPU_RATING"].ToString();
                   // CPU.CPU_VALUE = reader["CPU_VALUE"].ToString();
                   // CPU.CPU_LOWEST_PRICE_FOUND_ON_EBAY = reader["CPU_LOWEST_PRICE_FOUND_ON_EBAY"].ToString();
                    cpu_list.Add(CPU);
                }
                reader.Close();
            }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
            return cpu_list;
        }
    }
}
/*
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GetGameRankingsData
{
    public partial class Form1 : Form
    {
        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            table = new DataTable("GameRankingsDataTable");
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Score", typeof(string));
            table.Columns.Add("NumReviews", typeof(string));
            gamesRankingDataView.DataSource = table;
        }

        private async Task<List<GameReview>> GameRankingsFromPage(int pageNum)
        {
            string url = "http://www.gamerankings.com/browse.html";
            if (pageNum != 0)
                url = "http://www.gamerankings.com/browse.html?page=" + pageNum.ToString();

            var doc = await Task.Factory.StartNew(() => web.Load(url));
            var nameNodes = doc.DocumentNode.SelectNodes("//*[@id=\"main_col\"]//div//div//table//tr//td//a");
            var scoreNodes = doc.DocumentNode.SelectNodes("//*[@id=\"main_col\"]/div//div//table//tr//td//span//b");
            var numReviewNodes = doc.DocumentNode.SelectNodes("//*[@id=\"main_col\"]/div//div[2]/table//tr//td[4]");
            //If these are null it means the name/score nodes couldn't be found on the html page
            if (nameNodes == null || scoreNodes == null || numReviewNodes == null)
                return new List<GameReview>();

            var names = nameNodes.Select(node => node.InnerText).ToList();
            var scores = scoreNodes.Select(node => node.InnerText).ToList();
            var numReviews = numReviewNodes.Select(node => node.LastChild.InnerText).ToList();

            List<GameReview> toReturn = new List<GameReview>();
            for (int i = 0; i < names.Count(); ++i)
                toReturn.Add(new GameReview() { Name = names[i], Score = scores[i], NumReviews = numReviews[i] });

            return toReturn;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            int pageNum = 0;
            var rankings = await GameRankingsFromPage(0);
            while (rankings.Count > 0)
            {
                foreach (var ranking in rankings)
                    table.Rows.Add(ranking.Name, ranking.Score, ranking.NumReviews);
                pageNum++;
                rankings = await GameRankingsFromPage(pageNum);
            }
        }
        public class GameReview
        {
            public string Name { get; set; }
            public string Score { get; set; }
            public string NumReviews { get; set; }
        }

    }
}


/*
 using GetGameRankingsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGameRankingData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
 */
