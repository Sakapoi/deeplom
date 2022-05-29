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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputData.money_spending_percentage = int.Parse(textBox1.Text);
            InputData.percentage_of_spending_budget_money = int.Parse(textBox2.Text);
            InputData.likelihood_of_an_emergency = int.Parse(textBox3.Text);
            InputData.commercial_bank_amount = int.Parse(textBox6.Text);
            InputData.national_Bank_total_amount = int.Parse(textBox8.Text);

            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox1.Text = InputData.money_spending_percentage.ToString();
            textBox2.Text = InputData.percentage_of_spending_budget_money.ToString();
            textBox3.Text = InputData.likelihood_of_an_emergency.ToString();
            textBox6.Text = InputData.commercial_bank_amount.ToString();
            textBox8.Text = InputData.national_Bank_total_amount.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
