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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputData.ttp_initial_amount_of_money_min = int.Parse(textBox3.Text);
            InputData.ttp_initial_amount_of_money_max = int.Parse(textBox4.Text);
            InputData.ttp_percentage_of_purchases_goods = int.Parse(textBox9.Text);

            
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox3.Text = InputData.ttp_initial_amount_of_money_min.ToString();
            textBox4.Text = InputData.ttp_initial_amount_of_money_max.ToString();
            textBox9.Text = InputData.ttp_percentage_of_purchases_goods.ToString();
        }
    }
}
