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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputData.vst_initial_amount_of_money_min = int.Parse(textBox3.Text);
            InputData.vst_initial_amount_of_money_max = int.Parse(textBox4.Text);
            InputData.vst_process_cycle_time_min = int.Parse(textBox5.Text);
            InputData.vst_process_cycle_time_max = int.Parse(textBox6.Text);
            InputData.vst_markup_percentage_min = int.Parse(textBox7.Text);
            InputData.vst_markup_percentage_max = int.Parse(textBox8.Text);

            Random rand = new Random();
            InputData.vst_process_cycle_time = rand.Next(InputData.vst_process_cycle_time_min, InputData.vst_process_cycle_time_max + 1);
            InputData.vst_markup_percentage = rand.Next(InputData.vst_markup_percentage_min, InputData.vst_markup_percentage_max + 1);

            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox3.Text = InputData.vst_initial_amount_of_money_min.ToString();
            textBox4.Text = InputData.vst_initial_amount_of_money_max.ToString();
            textBox5.Text = InputData.vst_process_cycle_time_min.ToString();
            textBox6.Text = InputData.vst_process_cycle_time_max.ToString();
            textBox7.Text = InputData.vst_markup_percentage_min.ToString();
            textBox8.Text = InputData.vst_markup_percentage_max.ToString();
        }
    }
}
