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
    public partial class Panalty : Form
    {
        //Students s = new Students();
        public Panalty()
        {
            InitializeComponent();
          //  dataGridView1.DataSource = s.GetDepartmentPStudent(comboBox1.Text);
        }
        void GridUpdate()
        {
            //dataGridView1.DataSource = s.GetDepartmentPStudent(comboBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // GridUpdate();
        }


    }
}
