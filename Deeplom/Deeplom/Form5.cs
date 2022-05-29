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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputData.vs_initial_amount_of_money_min = int.Parse(textBox1.Text);
            InputData.vs_initial_amount_of_money_max = int.Parse(textBox2.Text);
            InputData.vs_process_cycle_time_min = int.Parse(textBox4.Text);
            InputData.vs_process_cycle_time_max = int.Parse(textBox5.Text);
            InputData.vs_markup_percentage_min = int.Parse(textBox6.Text);
            InputData.vs_markup_percentage_max = int.Parse(textBox7.Text);

            Random rand = new Random();
            InputData.vs_process_cycle_time = rand.Next(InputData.vs_process_cycle_time_min, InputData.vs_process_cycle_time_max + 1);
            InputData.vs_markup_percentage = rand.Next(InputData.vs_markup_percentage_min, InputData.vs_markup_percentage_max + 1);

            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = InputData.vs_initial_amount_of_money_min.ToString();
            textBox2.Text = InputData.vs_initial_amount_of_money_max.ToString();
            textBox4.Text = InputData.vs_process_cycle_time_min.ToString();
            textBox5.Text = InputData.vs_process_cycle_time_max.ToString();
            textBox6.Text = InputData.vs_markup_percentage_min.ToString();
            textBox7.Text = InputData.vs_markup_percentage_max.ToString();
        }
    }
}
