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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPublication a = new AddPublication();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBook ab = new AddBook();
            ab.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBranch abr = new AddBranch();
            abr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookReport br = new BookReport();
            br.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudent ass = new AddStudent();
            ass.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StudentReport sr = new StudentReport();
            sr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //BookIssue bs = new BookIssue();
            //bs.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Return_Book rb = new Return_Book();
            rb.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IssueReport ir = new IssueReport();
            ir.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Panalty pl = new Panalty();
            pl.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            this.Hide();
            cp.Show();
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LogIn ln = new LogIn();
            this.Hide();
            ln.Show();
        }
        
    }
}
