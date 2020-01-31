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
    public partial class AddStudent : Form
    {
        Students s = new Students();


        int sem;
        string id;
      
        public AddStudent()
        {
            InitializeComponent();
            if (int.Parse(DateTime.Now.Date.ToString("MM")) > 4)
            {
                if (int.Parse(DateTime.Now.Date.ToString("MM")) > 8)
                {
                    sem = 3;
                }
                else
                {
                    sem = 2;
                }

            }
            else
            {
                sem = 1;
            }

          id = DateTime.Now.Date.ToString("yy")+"-"+DateTime.Now.Month+DateTime.Now.Day.ToString("d")+DateTime.Now.Hour.ToString()+DateTime.Now.Second.ToString()+"-"+sem;
            textBox1.Text = id;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int panalty =0;
            string value = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                value = radioButton1.Text;
            else
            {
                value = radioButton2.Text;
            }
            int i;
            if (int.TryParse(textBox3.Text, out i))
            {
                if (textBox3.TextLength == 11)
                {
                 if (s.CreateStudents(textBox1.Text, textBox2.Text,comboBox1.Text, value, dateTimePicker1.Value.ToString("dd-MM-yyyy"), "+88"+textBox3.Text,panalty))
            {
                MessageBox.Show("Successfully Student Added");
                textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = string.Empty;

            } 
                }
                else
                {
                    MessageBox.Show("Invalid Contact number");
                }
            }
            else
            {
                MessageBox.Show("Enter  a valid Contact number");
            }
            id = DateTime.Now.Date.ToString("yy") + "-" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Second + "-" + sem;
            textBox1.Text = id;
           
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            //Application.Exit();
        }


    }
}
