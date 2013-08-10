using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Spankomatic
{
    public partial class Statistics : Form
    {
        //MySQLDb sqldb;

        public Statistics()
        {
            //sqldb = new MySQLDb();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("AAAAAAAAAAA");
            //List<int> days;
            //List<int> numCola;

            MySqlConnection conn = MySQLDb.ConnectToCafeDb();
            string sql = "SELECT timestamp FROM `cafe_sales` WHERE articleId = 1 AND timestamp > \'2013-01-01 00:00:00\'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int curDateDayOfYear = DateTime.Today.DayOfYear;
            
            int date;   //Day of year

            List<int> daysList = new List<int>();
            
            for (int i = 0; i <= curDateDayOfYear; i++ )
            {
                daysList.Add(0);
            }


            while (rdr.Read())
            {                
                date = rdr.GetDateTime(0).DayOfYear;
                daysList[date]++;   
            }
            rdr.Close();

            MySQLDb.CloseConnection();
            /*
            chart1.Series.Add("Cola");
            for (int i = 0; i < 100; i++) {
                chart1.Series["Cola"].Points.AddXY(i, i * i);
            }*/
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
