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
    public partial class LoginForm : Form
    {
        //MySQLDb sqldb;

        private LoggedInUser user;
        private Spankomatic spankForm;

        public LoginForm(Spankomatic form)
        {
            spankForm = form;
          //  sqldb = new MySQLDb();

            //this.user = user;

            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQLDb.ConnectToDsekDb();
            bool authenticated = MySQLDb.AuthenticateUser(textBoxUser.Text, textBoxPassword.Text);
            MySQLDb.CloseConnection();

            label4.Font = new Font("Tahoma", 12.0F);
            if (authenticated)
            {
                user = new LoggedInUser(textBoxUser.Text);
                spankForm.OnLogIn(textBoxUser.Text);

                this.Close();
            }
            else
            {
                label4.Text = "Nej, du får INTE logga in här!";
                label4.ForeColor = Color.Red;
            }
        }

    }
}
