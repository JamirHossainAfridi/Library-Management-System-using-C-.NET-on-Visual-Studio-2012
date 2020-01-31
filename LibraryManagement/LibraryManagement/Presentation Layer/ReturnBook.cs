using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Business_Logic_Layer;

namespace LibraryManagement
{
    public partial class Return_Book : Form
    {
        Issued iss = new Issued();
        Students s = new Students();
        Books b = new Books();
        public Return_Book()
        {
            InitializeComponent();
           
            dataGridView1.DataSource = iss.GetAllIssueBooks();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = iss.GetAllIssueBooks();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != string.Empty && textBox8.Text != string.Empty)
            {

                if (iss.DeleteIssue(textBox7.Text, textBox8.Text))
                {
                    MessageBox.Show("Book return Successfully ...");
                }
                GridUpdate();
                b.IsssueQuantity(textBox8.Text);
                s.UpdatePanalty(textBox7.Text, int.Parse(textBox10.Text));
                
                
            }
            else
            {
                MessageBox.Show("No book are selected ...");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = iss.GetIssueBooks(textBox1.Text);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void Return_Book_Load(object sender, EventArgs e)
        {
            iss.UpdatePanalty();
        }


    }
}
