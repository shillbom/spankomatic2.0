using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spankomatic
{
    public partial class InkopslistaForm : Form
    {
        private BindingList<Inkop> inkopslistaBinding;

        public InkopslistaForm()
        {
            List<Inkop> inkopslista = MySQLDb.GetAllInkop();
            inkopslistaBinding = new BindingList<Inkop>(inkopslista);
            
            InitializeComponent();
        }

        private void InkopslistaForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inkopslistaBinding;
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxWhat.Text == "" || textBoxQuantity.Text == "")
            {
                MessageBox.Show("Noob! Du måste ju skriva nåt i båda textfälten!");
            }
            else 
            { 
                Inkop inkop = new Inkop();
                inkop.article = textBoxWhat.Text;
                inkop.quantity = textBoxQuantity.Text;
                inkop.purchased = false;
                MySQLDb.SubmitInkop(inkop);

                List<Inkop> inkopslista = MySQLDb.GetAllInkop();
                inkopslistaBinding = new BindingList<Inkop>(inkopslista);
                dataGridView1.DataSource = inkopslistaBinding;
    
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSaveExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            bool value = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

            Inkop inkop = new Inkop();
            inkop.id = id;
            inkop.purchased = value;

            MySQLDb.UpdatePurchasedInkop(inkop);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

    }
}
