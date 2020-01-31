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
    public partial class AddBook : Form
    {
        Books b = new Books();
       
        public AddBook()
        {
           
            InitializeComponent();
            AddPublication ap = new AddPublication();
            foreach (DataGridViewRow row in ap.dataGridView1.Rows)
            {
                comboBox1.Items.Add(row.Cells[0].Value.ToString());

            }
            AddBranch ab = new AddBranch();
            foreach (DataGridViewRow row in ab.dataGridView1.Rows )
            {
                comboBox2.Items.Add(row.Cells[0].Value.ToString());
            }
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int issQuantity = 0;
            if (b.CreateBooks(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text, textBox4.Text, int.Parse(textBox5.Text), int.Parse(textBox5.Text),issQuantity))
            {
                MessageBox.Show("Successfully Book Added");
                textBox1.Text = textBox2.Text=textBox3.Text= textBox4.Text= textBox5.Text=string.Empty;

            }
            else
            {
                MessageBox.Show("Error in adding book");
            }
        }
    }
}
