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
    public partial class StudentReport : Form
    {
        Students s = new Students();
        Issued iss = new Issued();
        public StudentReport()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.GetAllStudent();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = s.GetAllStudent(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
              MessageBox.Show("NO student are Selected...");
            }
            else
            {
                
                IssueBook ib = new IssueBook(textBox2.Text, textBox3.Text, comboBox1.Text);
                this.Hide();
                ib.Show();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("No Student are select for delete");
            }
            else if (textBox2.Text != string.Empty)
            {
                DialogResult res = MessageBox.Show("Are You sure to Update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.Yes))
                {
                    if (s.UpdateStudent(textBox3.Text, comboBox1.Text, textBox4.Text, textBox7.Text, int.Parse(textBox8.Text), textBox2.Text))
                    {
                        MessageBox.Show("Student info update successfully");
                        textBox2.Text = textBox5.Text = textBox3.Text = textBox7.Text = textBox8.Text = comboBox1.Text = textBox4.Text = string.Empty;
                        GridUpdate();

                    }
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("No Student are select for delete");
            }

            else if (textBox2.Text != string.Empty)
            {
                DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res.Equals(DialogResult.Yes))
                {

                    if (s.DeleteStudent(textBox2.Text))
                    {

                        MessageBox.Show("Successfully Student info delete");
                        textBox2.Text = textBox5.Text = textBox3.Text = textBox7.Text = textBox8.Text = comboBox1.Text = textBox4.Text = string.Empty;
                        GridUpdate();
                    }
                }
            }

            else
            {
                MessageBox.Show("Error in deleting");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            GridUpdate();
        }

        private void StudentReport_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.UpdateStudentPanalty(textBox2.Text);
            GridUpdate();
        }
    }
}
