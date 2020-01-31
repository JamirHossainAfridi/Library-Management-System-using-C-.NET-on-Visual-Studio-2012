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
    public partial class BookReport : Form
    {
        Books b = new Books();
        public BookReport()
        {
            InitializeComponent();
            AddBranch ab = new AddBranch();
           dataGridView1.DataSource = b.GetAllBooks();
        }
        public void GridUpdate()
        {
            dataGridView1.DataSource = b.GetAllBooks();
            textBox1.Text = null;
            textBox14.Text = null;
            textBox13.Text = null;
            textBox12.Text = null;
            textBox8.Text = null;
            textBox11.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GridUpdate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("No book are selected for delete");
            }

            else if (textBox1.Text != string.Empty)
            {
                DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res.Equals(DialogResult.Yes))
                {
                   
                    if (b.DeleteBook(textBox1.Text))
                    {

                        MessageBox.Show("Successfully Book deleted");
                        GridUpdate();
                    }
                }
            }
           
            else
            {
                MessageBox.Show("Error in deleting");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (textBox1.Text != string.Empty)
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Please enter numbers of book ...");
                }
                else if (!int.TryParse(textBox2.Text, out i))
                {
                    MessageBox.Show("Please enter valid amount books you want to add...");
                }
                else if (b.AddQuantity(int.Parse(textBox2.Text), textBox1.Text))
                {

                    MessageBox.Show(+int.Parse(textBox2.Text) + " Books Added Successfully");
                    GridUpdate();
                }
            }
            
            else
            {
                MessageBox.Show("No Book are selected...");
            }
            textBox2.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            if (textBox1.Text != string.Empty )
            {
                if (textBox3.Text == string.Empty)
                {
                    MessageBox.Show("Please enter numbers of book ...");
                }
                else if (!int.TryParse(textBox3.Text, out i))
                {
                    MessageBox.Show("Please enter valid amount books you want to delete...");
                }

                else if (int.Parse(textBox11.Text) >= int.Parse(textBox3.Text))
                {
                    if (int.Parse(textBox10.Text) >= int.Parse(textBox3.Text))
                    {
                        DialogResult res = MessageBox.Show("Are You Sure Delete " + int.Parse(textBox3.Text) + " Books?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res.Equals(DialogResult.Yes))
                        {

                            if (b.DeleteQuantity(int.Parse(textBox3.Text), textBox1.Text))
                            {
                                GridUpdate();
                                MessageBox.Show(int.Parse(textBox3.Text) + " Books Delete Successfully");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There are not much available books....");
                    }
                }
                else
                {
                    MessageBox.Show("Error in Deleting.There are not much available books for delete");
                }

            }
            else if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("No book are selected for delete");
  
            }
        
            //else
            //{
            //    MessageBox.Show("Error in Decreasing.There is not much available books for delete");
            //}
            textBox3.Text = string.Empty;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = b.GetAllBooks(textBox4.Text);
        }

       

    }
}
