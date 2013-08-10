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
    public partial class RegisterJobbare : Form
    {
        //MySQLDb sqldb;

        public RegisterJobbare()
        {
            //sqldb = new MySQLDb();

            InitializeComponent();
        }

        private void RegisterJobbare_Load(object sender, EventArgs e)
        {
            dataGridViewAddedUsers.ColumnCount = 2;
            dataGridViewAddedUsers.Columns[0].Width = (int)(dataGridViewAddedUsers.Width * 0.7);
            dataGridViewAddedUsers.Columns[1].Width = (int)(dataGridViewAddedUsers.Width * 0.3);
            dataGridViewAddedUsers.ScrollBars = ScrollBars.Vertical;

            dataGridViewSenaste.ColumnCount = 2;
            dataGridViewSenaste.Columns[0].Width = (int)(dataGridViewAddedUsers.Width * 0.7);
            dataGridViewSenaste.Columns[1].Width = (int)(dataGridViewAddedUsers.Width * 0.3);
            dataGridViewSenaste.ScrollBars = ScrollBars.Vertical;

            labelError.Top = 160;
            MySqlConnection conn = MySQLDb.ConnectToCafeDb();

            string sql = "SELECT personId,COUNT(*) as count FROM `cafe_workingpeople` WHERE date >= DATE_SUB(NOW( ) , INTERVAL 3 MONTH) GROUP BY personId ORDER BY count DESC LIMIT 0, 15";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                comboBoxCommonUsers.Items.Add(MySQLDb.GetUserFromId(rdr.GetInt32(0)));
            }
            rdr.Close();

            sql = "SELECT personId, date FROM `cafe_workingpeople` ORDER BY date DESC LIMIT 0, 15";
            cmd = new MySqlCommand(sql, conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int user = rdr.GetInt32(0);
                string date = rdr.GetString(1);

                date = date.Substring(0, Math.Min(date.Length, 10));
                dataGridViewSenaste.Rows.Add(MySQLDb.GetUserFromId(user), date);
            }
            rdr.Close();


            MySQLDb.CloseConnection();

            

        }

        private void dataGridViewAddedUsers_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewAddedUsers.ClearSelection();
        }

        private bool userAlreadyInList(User user) {
            for (int i = 0; i < dataGridViewAddedUsers.RowCount - 1; i++)
            {
                if (user.Equals((User)dataGridViewAddedUsers.Rows[i].Cells[0].Value) && dateTimePicker1.Text == dataGridViewAddedUsers.Rows[i].Cells[1].Value.ToString())
                    return true;
            }

            return false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != "")
            {
                User user = MySQLDb.GetUserFromLogin(textBoxLogin.Text);

                if (user == null) {
                    labelError.Text = "Användaren kunde inte hittas!";
                }
                else if (!userAlreadyInList(user))
                {
                    labelError.Text = "";
                    dataGridViewAddedUsers.Rows.Add(user, dateTimePicker1.Text);
                }
                else
                    labelError.Text = "Användaren redan i listan!";

                textBoxLogin.Text = "";
            }
            else if (comboBoxCommonUsers.SelectedIndex > -1) {
                User  user = (User) comboBoxCommonUsers.Items[comboBoxCommonUsers.SelectedIndex];
                if (!userAlreadyInList(user))
                {
                    labelError.Text = "";
                    dataGridViewAddedUsers.Rows.Add(user, dateTimePicker1.Text);
                }
                else
                    labelError.Text = "Användaren redan i listan!";

                comboBoxCommonUsers.SelectedIndex = -1;
            }

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = MySQLDb.ConnectToCafeDb();

            string sql = "SELECT MAX(id) FROM `cafe_workingpeople`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            int firstNewId = Convert.ToInt32(result) + 1;


            for (int i = 0; i < dataGridViewAddedUsers.RowCount; i++)
            {
                User user = (User) dataGridViewAddedUsers.Rows[i].Cells[0].Value;
                string date = dataGridViewAddedUsers.Rows[i].Cells[1].Value.ToString();
                string sqlstring = "INSERT INTO `cafe_workingpeople` (id, date, personId) VALUES (\'" + firstNewId.ToString() + "\', \'" + date + "\', \'" + user.id.ToString() + "\')";
                cmd = new MySqlCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                firstNewId++;                
            }

            MySQLDb.CloseConnection();

            this.Close();
        }

        private void RegisterJobbare_Shown(object sender, EventArgs e)
        {
            textBoxLogin.Focus();
        }
    }
}
