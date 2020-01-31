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
    public partial class AddPublication : Form
    {
        Publication p = new Publication();

      

        public AddPublication()
        {
            InitializeComponent();
            dataGridView1.DataSource = p.GetAllPublication();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = p.GetAllPublication();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p.CreatePublication(textBox1.Text))
            {
                GridUpdate();
                MessageBox.Show("Successfully Publication Added");
                textBox1.Text = null;

            }

            else
            {
                MessageBox.Show("Error in creating");
            }
            

            
           
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("All Books of thip Publication Will be delete.Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
               p.P_Name = textBox2.Text;
               p.DeletePublicationBooks(textBox2.Text);
                if (p.DeletePublication(p.P_Name))
                {
                    GridUpdate();
                    MessageBox.Show("Successfully Publication deleted");
                }
            }
            else
            {
                MessageBox.Show("Error in deleting");
            }
            textBox2.Text = null;
        }
    }
}
