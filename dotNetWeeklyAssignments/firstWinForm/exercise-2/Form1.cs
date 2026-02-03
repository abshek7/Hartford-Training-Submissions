using System;
using System.Windows.Forms;

namespace exercise_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dob = dateTimePicker1.Value;
            TimeSpan tm = (DateTime.Now - dob);

            int age = (tm.Days / 365);
            textBox1.Text = age.ToString() + " Yrs.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}