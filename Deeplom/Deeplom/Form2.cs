using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deeplom
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = InputData.speed;
            InputData.tax_money_percentage = int.Parse(textBox1.Text);
            InputData.pay_wages_percentage = int.Parse(textBox2.Text);
            InputData.interest_on_loans = int.Parse(textBox3.Text);
            InputData.national_Bank_rate = int.Parse(textBox4.Text);
            InputData.loan_repayment_period = int.Parse(textBox5.Text);
            InputData.simulation_period_interval = int.Parse(textBox6.Text);

            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            InputData.speed = trackBar1.Value;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            trackBar1.Value = InputData.speed;
            textBox1.Text = InputData.tax_money_percentage.ToString();
            textBox2.Text = InputData.pay_wages_percentage.ToString();
            textBox3.Text = InputData.interest_on_loans.ToString();
            textBox4.Text = InputData.national_Bank_rate.ToString();
            textBox5.Text = InputData.loan_repayment_period.ToString();
            textBox6.Text = InputData.simulation_period_interval.ToString();
        }
    }
}
