using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class ChangePassword : Form
    {
       
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            LogIn ln = new LogIn();
            this.Hide();
            ln.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Index i = new Index();
            this.Hide();
            i.Show();
        }
    }
}
