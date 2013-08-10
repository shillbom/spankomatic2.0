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
    public partial class mackForm : Form
    {
        //MySQLDb sqldb;
        
        public mackForm()
        {
          //  this.sqldb = new MySQLDb();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQLDb.ConnectToCafeDb();
            int numBiljetter = MySQLDb.GetNumMackbarsbiljetterByLogin(this.textBox1.Text);
            MySQLDb.CloseConnection();

            this.labelAvailableTickets.Text = numBiljetter.ToString();
            button2.Enabled = numBiljetter > 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySQLDb.ConnectToCafeDb();
            MySQLDb.DeliverMackbarsBiljett(this.textBox1.Text);
            MySQLDb.CloseConnection();

            int available = Convert.ToInt32(labelAvailableTickets.Text);
            available--;
            labelAvailableTickets.Text = available.ToString();

            if (available == 0) {
                button2.Enabled = false;
            }
        }
    }
}
