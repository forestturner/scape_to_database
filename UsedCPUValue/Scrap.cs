﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsedCPUValue
{
    class Scrap
    {
         HtmlWeb web = new HtmlWeb();
        /// <summary>
        /// parameters = two strings (url of webpage and Node)
        /// </summary>
        /// <returns></returns>
        public List<string> grab_page_return_list_of_strings(string url,string node)
        {
            List<string> list = new List<string>();
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response);
            var test = doc.DocumentNode.SelectNodes(node);
            foreach(var i in test)
            {
                list.Add(i.InnerText);
                Console.WriteLine(i.InnerText);
            }
            return list;
        }
        public List<CPUData> GameRankingsFromPage()//int pageNum)
        {
            string url = "https://www.cpubenchmark.net/high_end_cpus.html#";

            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response);

            var nameNodes = doc.DocumentNode.SelectNodes("//*[@id]/a");
            var scoreNodes = doc.DocumentNode.SelectNodes("//*[@id]/div/text()");

            var names = nameNodes.Select(node => node.InnerText).ToList();
            var scores = scoreNodes.Select(node => node.InnerText).ToList();

            List<CPUData> toReturn = new List<CPUData>();
            int j = 0;
            for (int i = 0; i < 500; i++)
            {
               
                string temp_s = scores[j];;

                Char[] ch = temp_s.ToCharArray();
                char n1 = '\n';
                char n2 = ' ';

                while (ch[0].CompareTo(n1) == 0 || ch[0].CompareTo(n2) == 0)
                {

                    temp_s = scores[j];
                    ch = temp_s.ToCharArray();
                    j++;
                }

                     toReturn.Add(new CPUData() { CPU_NAME = names[i], CPU_RATING = scores[j-1]});
             }
            return toReturn;
        }
    }
}


/*
 * using System;
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
  var nameNodes = doc.DocumentNode.SelectNodes("//*[@id]/a");
            var scoreNodes = doc.DocumentNode.SelectNodes("//*[@id]/div/text()");
            //If these are null it means the name/score nodes couldn't be found on the html page
          //  if (nameNodes == null || scoreNodes == null ) //numReviewNodes == null)
            //    return new List<GameReview>();

            var names = nameNodes.Select(node => node.InnerText).ToList();
            var scores = scoreNodes.Select(node => node.InnerText).ToList();
            //var numReviews = numReviewNodes.Select(node => node.LastChild.InnerText).ToList();

            List<GameReview> toReturn = new List<GameReview>();
            int j = 0;
            for (int i = 0; i < 500; i++)
            {
               
                string temp_s = scores[j];;
               // int blah = Convert.ToInt32(temp_s);
                //Console.WriteLine(blah);
                Char[] ch = temp_s.ToCharArray();
                char n1 = '\n';
                char n2 = ' ';
              //  textBox1.AppendText("score = before while loop = "+ scores[j-1]);
                while (ch[0].CompareTo(n1) == 0 || ch[0].CompareTo(n2) == 0)
                {
                    //textBox1.AppendText("noo");
                       // ("noob");
                    temp_s = scores[j];
                    ch = temp_s.ToCharArray();
                    //textBox1.AppendText(j.ToString());
                    //textBox1.AppendText("------------");
                    j++;
                    //textBox1.AppendText(j.ToString());
                   // textBox1.AppendText("max size = " + scores.Count);
                    
                   // ch = temp_s.ToCharArray();
                }
                //if (Convert.ToInt32(scores[j]) > 0)
                //{
                Console.WriteLine("noob");
                    toReturn.Add(new GameReview() { Name = names[i], Score = scores[j-1] });//, NumReviews = numReviews[i] });
             }
        
               // toReturn.Add(new GameReview() { Name = names[i], Score = scores[i] });//, NumReviews = numReviews[i] });

            return toReturn;
        }
 
 
 */