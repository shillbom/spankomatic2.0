using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace Spankomatic
{
    public partial class Spankomatic : Form
    {
        //MySQLDb sqldb;
        

        public Spankomatic()
        {
            InitializeComponent();

            //sqldb = new MySQLDb();

            labelTotalPrice.Left = this.Width - 10 - labelTotalPrice.Width;
            textBoxSearchString.Text = "";

            this.Controls.Add(dataGridView1);
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "Artikel";
            dataGridView1.Columns[1].HeaderText = "Pris";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;

            dataGridViewButtons.ColumnCount = 3;
            this.Column1.Width = dataGridViewButtons.Width / 3;
            this.Column2.Width = dataGridViewButtons.Width / 3;
            this.Column3.Width = dataGridViewButtons.Width / 3;

            ActiveControl = textBoxSearchString;

            MySQLDb.GetArticleTable();
        }

        private void calculateTotalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                totalPrice += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            }

            labelTotalPrice.Text = "Totalpris: " + totalPrice.ToString() + ".00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQLDb.ConnectToCafeDb();

            if (textBoxSearchString.Text != "")
            {
                Regex regex = new Regex(@"^\d+$");


                if (regex.IsMatch(textBoxSearchString.Text))   //Om värdet är numeriskt
                {
                    Article a = MySQLDb.EANToArticle(textBoxSearchString.Text);
                    if (a != null)
                    {
                        dataGridView1.Rows.Add(a.name, a.price / 100);

                        calculateTotalPrice();

                    }
                }
            }

            else
            {  //Tom textbox == Skickar transaktionen till databasen
                Sale sale;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
                {
                    sale = MySQLDb.ArticleNameToSale(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    sale.arbetsGladje = false;

                    MySQLDb.RecordSale(sale);
                }

                dataGridView1.RowCount = 1;
                dataGridView1.Rows.Clear();
                labelTotalPrice.Text = "Totalpris: 0.00";

            }

            MySQLDb.CloseConnection();

            textBoxSearchString.Text = "";
        }


        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registreraSomArbetsglädjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale sale;

            MySQLDb.ConnectToCafeDb();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                sale = MySQLDb.ArticleNameToSale(dataGridView1.Rows[i].Cells[0].Value.ToString());
                sale.arbetsGladje = true;

                MySQLDb.RecordSale(sale);
            }

            MySQLDb.CloseConnection();

            dataGridView1.RowCount = 1;
            dataGridView1.Rows.Clear();
            labelTotalPrice.Text = "Totalpris: 0.00";
        }

        private void labelTotalPrice_TextChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(delegate
            {
                labelTotalPrice.Invalidate();
                labelTotalPrice.Refresh();
                labelTotalPrice.Left = this.Width - 10 - labelTotalPrice.Width;
            }));
        }

        private void Spankomatic_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Spankomatic_KeyDown(object sender, KeyEventArgs e)
        {
       /*     if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) 
            {
                labelSearchString.Text = labelSearchString.Text + e.KeyCode.ToString().ToLower();
            }
            else if (e.KeyCode == Keys.Oem6)
            {
                labelSearchString.Text = labelSearchString.Text + "å";
            }
            else if (e.KeyCode == Keys.Oem7)
            {
                labelSearchString.Text = labelSearchString.Text + "ä";
            }
            else if (e.KeyCode == Keys.Oemtilde)
            {
                labelSearchString.Text = labelSearchString.Text + "ö";
            }
            else if (e.KeyCode == Keys.Space)
            {
                labelSearchString.Text = labelSearchString.Text + " ";
            }
            else if (e.KeyCode == Keys.Back) 
            { 
                if (labelSearchString.Text.Length > 0)
                    labelSearchString.Text = labelSearchString.Text.Remove(labelSearchString.Text.Length - 1);
            }*/

            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.Rows.Count > 1)
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                calculateTotalPrice();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.RowCount = 1;
                dataGridView1.Rows.Clear();
                calculateTotalPrice();

                textBoxSearchString.Text = "";
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    RegisterSales();
                }
                else
                    OnEnter();
            }
            else if (e.KeyCode == Keys.Right)
            {
                int row = dataGridViewButtons.SelectedCells[0].RowIndex;
                int col = dataGridViewButtons.SelectedCells[0].ColumnIndex;

                dataGridViewButtons.Rows[row].Cells[col].Selected = false;

                if (col < 2)
                    col++;
                else if (row != dataGridViewButtons.Rows.Count - 1)
                {
                    col = 0;
                    row++;
                }

                dataGridViewButtons.Rows[row].Cells[col].Selected = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                int row = dataGridViewButtons.SelectedCells[0].RowIndex;
                int col = dataGridViewButtons.SelectedCells[0].ColumnIndex;

                dataGridViewButtons.Rows[row].Cells[col].Selected = false;

                if (col > 0)
                    col--;
                else if (row != 0)
                {
                    col = 2;
                    row--;
                }

                dataGridViewButtons.Rows[row].Cells[col].Selected = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                int row = dataGridViewButtons.SelectedCells[0].RowIndex;
                int col = dataGridViewButtons.SelectedCells[0].ColumnIndex;

                dataGridViewButtons.Rows[row].Cells[col].Selected = false;

                if (row != dataGridViewButtons.Rows.Count - 1)
                    row++;

                dataGridViewButtons.Rows[row].Cells[col].Selected = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                int row = dataGridViewButtons.SelectedCells[0].RowIndex;
                int col = dataGridViewButtons.SelectedCells[0].ColumnIndex;

                dataGridViewButtons.Rows[row].Cells[col].Selected = false;

                if (row != 0)
                    row--;

                dataGridViewButtons.Rows[row].Cells[col].Selected = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MySQLDb.ConnectToCafeDb();
            List<string> stringList = MySQLDb.GetAllArticleNameThatContainsString(textBoxSearchString.Text);
            //MySQLDb.CloseConnection();

            dataGridViewButtons.Rows.Clear();

            if (stringList.Count > 0)
            {
                //if (stringList.Count > 2)
                dataGridViewButtons.Rows.Add(16);
                if (stringList.Count / 3 > 16)
                {
                    dataGridViewButtons.Rows.Add(stringList.Count / 3 - 16);
                }

                for (int i = 0; i < stringList.Count; ++i)
                {
                    dataGridViewButtons.Rows[i / 3].Cells[i % 3].Value = stringList[i];
                }

                //dataGridViewButtons.Rows[0].Cells[0].Value = "---";
                dataGridViewButtons.Invalidate();
                dataGridViewButtons.Refresh();
            }
        }

        private void dataGridViewButtons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)dataGridViewButtons.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                string s = cell.Value.ToString();
                //MySQLDb.ConnectToCafeDb();
                Article a = MySQLDb.ArticleNameToArticle(s);
                //MySQLDb.CloseConnection();
                if (a != null)
                {
                    dataGridView1.Rows.Add(a.name, a.price / 100);

                    calculateTotalPrice();
                }
            }

            this.ActiveControl = textBoxSearchString;
        }

        private void hämtaUtmackbarsbiljetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mackForm mackForm = new mackForm();
            mackForm.Show();
        }

        private void RegisterSales()
        {
            Sale sale;
            MySQLDb.ConnectToCafeDb();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                sale = MySQLDb.ArticleNameToSale(dataGridView1.Rows[i].Cells[0].Value.ToString());
                sale.arbetsGladje = false;

                MySQLDb.RecordSale(sale);
            }

            MySQLDb.CloseConnection();

            dataGridView1.RowCount = 1;
            dataGridView1.Rows.Clear();
            labelTotalPrice.Text = "Totalpris: 0.00";
        }

        private void OnEnter()
        {
            //MySQLDb.ConnectToCafeDb();

            //if (textBox1.Text != "")    //Nåt står i textboxen...
            //{
            Regex regex = new Regex(@"^\d+$");


            if (textBoxSearchString.Text != "" && regex.IsMatch(textBoxSearchString.Text.Trim()))   //Om värdet är numeriskt så är det förhoppningsvis en EAN-kod
            {
                Article a = MySQLDb.EANToArticle(textBoxSearchString.Text);
                if (a != null)
                {
                    dataGridView1.Rows.Add(a.name, a.price / 100);
                    calculateTotalPrice();
                }
            }
            else
            {                      //Om det inte är numeriskt är det varunamn... då vill vi hitta den artikel som är markerad i gridviewen
                if (dataGridViewButtons.SelectedCells[0].Value != null && dataGridViewButtons.SelectedCells[0].Value.ToString() != "")
                {
                    //MySQLDb.ConnectToCafeDb();
                    Article a = MySQLDb.ArticleNameToArticle(dataGridViewButtons.SelectedCells[0].Value.ToString());
                    //MySQLDb.CloseConnection();

                    if (a != null)
                    {
                        dataGridView1.Rows.Add(a.name, a.price / 100);
                        calculateTotalPrice();
                    }

                    //textBox1.Focus();
                    textBoxSearchString.SelectionStart = 0;
                    textBoxSearchString.SelectionLength = textBoxSearchString.Text.Length;
                }

            }
            //           }

            /*         else
                     {  //Tom textbox == Skickar transaktionen till databasen
                

                     }
                     */
            //MySQLDb.CloseConnection();

            //textBox1.Text = "";
        }

        private void registerSalesButton_Click(object sender, EventArgs e)
        {
            RegisterSales();
            textBoxSearchString.Focus();
        }

        private bool RunCommand(string cmd, string args, bool wait)
        {
            if (cmd == null) return false;
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            myproc.EnableRaisingEvents = false;
            myproc.StartInfo.FileName = cmd;
            myproc.StartInfo.Arguments = args;
            
            if (myproc.Start())
            {
                //Using WaitForExit( ) allows for the host program
                //to wait for the command its executing before it continues
                if (wait) myproc.WaitForExit();
                else myproc.Close();

                myproc.StandardError.ReadToEnd();
                myproc.StandardOutput.ReadToEnd();

                return true;
            }
            else return false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterJobbare regjob = new RegisterJobbare();
            regjob.Show();
        }

        private void loggaInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.Show();
        }

        private void registrerajobbareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterJobbare registerJobbare = new RegisterJobbare();
            registerJobbare.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        public void OnLogIn(string user)
        {
            this.labelLoggedIn.Text = user;
            this.loggaInToolStripMenuItem.Enabled = false;
            this.loggautToolStripMenuItem.Enabled = true;
            this.registrerajobbareToolStripMenuItem.Enabled = true;
            this.fipplaMedInköpslistanToolStripMenuItem.Enabled = true;
            
        }

        public void OnLogOut()
        { 
            this.labelLoggedIn.Text = "";
            this.loggaInToolStripMenuItem.Enabled = true;
            this.loggautToolStripMenuItem.Enabled = false;
            this.registrerajobbareToolStripMenuItem.Enabled = false;
            this.fipplaMedInköpslistanToolStripMenuItem.Enabled = false;
        }

        private void loggautToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnLogOut();
        }

        private void labelSearchString_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxSearchString.Focus();
        }

        private void dataGridViewButtons_Click(object sender, EventArgs e)
        {
            textBoxSearchString.Focus();
        }

        private void fipplaMedInköpslistanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InkopslistaForm inkopsform = new InkopslistaForm();
            inkopsform.Show();
        }

        private void Spankomatic_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxSearchString.Focus();
        }
    }
}
        



