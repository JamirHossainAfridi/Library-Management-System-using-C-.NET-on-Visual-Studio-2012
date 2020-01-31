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
    public partial class LogIn : Form
    {

        Users us = new Users();
        public LogIn()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string username =textBox1.Text ="Admin";
            //string pass =textBox2.Text ="admin";
            if (textBox1.Text == "Admin" && textBox2.Text == "admin")
            {
                //MessageBox.Show();
                Index i = new Index();
                this.Hide();
                i.Show();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password");
            }
 
        }
    }
}
