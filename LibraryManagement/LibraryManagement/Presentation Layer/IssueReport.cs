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
    public partial class IssueReport : Form
    {
        Issued iss = new Issued();
        public IssueReport()
        {
            InitializeComponent();
            dataGridView1.DataSource = iss.GetAllIssueBooks();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = iss.GetAllIssueBooks(textBox1.Text);
        }
    }
}
