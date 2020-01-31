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
    public partial class AddBranch : Form
    {
        Branch b = new Branch();
        public AddBranch()
        {
            InitializeComponent();
            dataGridView1.DataSource = b.GetAllBranchs();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = b.GetAllBranchs();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (b.CreateBranch(textBox1.Text))
                {
                    GridUpdate();
                    MessageBox.Show("Successfully Branch Created");
                    textBox1.Text = null;
                
            }

            else
            {
                MessageBox.Show("Error in creating");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("All books are in this branch will be delete.Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                b.DeleteBranchBooks(textBox2.Text);
                b.Name = textBox2.Text;
                if (b.DeleteBranch(b.Name))
                {
                   
                    GridUpdate();
                    MessageBox.Show("Successfully Branch deleted");
                }
            }
            else
            {
                MessageBox.Show("Error in deleting");
            }
            textBox2.Text =string.Empty;
        }
   
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }



    }
}
