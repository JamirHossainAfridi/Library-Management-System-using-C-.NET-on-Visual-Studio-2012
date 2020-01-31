using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Business_Logic_Layer;


namespace LibraryManagement
{
    public partial class IssueBook : Form
    {
        Books b = new Books();
        Issued iss = new Issued();
        Return_Book rb = new Return_Book();
         

        public IssueBook(string id, string name, string department)
        {
            InitializeComponent();
            textBox9.Text = id;
            textBox10.Text = name;
            textBox11.Text = department;
        }
        void GridUPdate()
        {
            dataGridView1.DataSource=b.GetBooks(textBox12.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentReport sr = new StudentReport();
            this.Hide();
            sr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            GridUPdate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
      
        private void button2_Click_1(object sender, EventArgs e)
        {
            int date = int.Parse(DateTime.Now.ToString("dd")) + 7;
            string issueDate=DateTime.Now.ToString("dd-MM-yyyy");
            string retDate = DateTime.Now.ToString(date+"-MM-yyyy");
            textBox13.Text = retDate;
            iss.Panalty = 0;


            if (textBox1.Text != string.Empty)
            {
                if(int.Parse(textBox8.Text)>0)
                {
                    if (iss.CreatIssue(textBox9.Text, textBox10.Text, textBox11.Text, textBox1.Text, issueDate, retDate,iss.Panalty))
                    {
                        b.AvilableQuantity(textBox1.Text);
                        GridUPdate();
                        MessageBox.Show("Book Issued Successfully...");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Book are not Issued ...");
 
                    }
                
                }
                else
                {
                    MessageBox.Show("There are no available Book....");
                }
            }
            else
            {
                MessageBox.Show("No Book are Selected...");
            }

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            int date = int.Parse(DateTime.Now.ToString("dd")) + 7;
            string issueDate = DateTime.Now.ToString("dd-MM-yyyy");
            string retDate = DateTime.Now.ToString(date + "-MM-yyyy");
            textBox13.Text = retDate;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StudentReport sr = new StudentReport();
            this.Hide();
            sr.Show();
        }

    }
}
