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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        void Grafic_Update() 
        {
            Economy_events.day++;
            Random rand = new Random();
            Economy_events.result += "---------------- День " + Economy_events.day + " ----------------\n";

            for (int i = 0; i < rand.Next(1, 4); i++)
            {

                int rnd = rand.Next(0, 8);
                switch (rnd)
                {
                    case 0:
                        Сharacteristics.material_coming += 10;
                        Economy_events.result += Economy_events.material;
                        break;
                    case 1:
                        Сharacteristics.material_consumption += 10;
                        Economy_events.result += Economy_events.manufacturer;
                        break;
                    case 2:
                        Сharacteristics.material_raw += 10;
                        Economy_events.result += Economy_events.consumer;
                        break;
                    case 3:
                        Сharacteristics.material_remainder += 10;
                        Economy_events.result += Economy_events.trade;
                        break;
                    case 4:
                        Economy_events.result += Economy_events.budget;
                        break;
                    case 5:
                        Economy_events.result += Economy_events.commercial;
                        break;
                    case 6:
                        Economy_events.result += Economy_events.buyers;
                        break;
                    case 7:
                        Economy_events.result += Economy_events.bank;
                        break;
                }

                Economy_events.result += " - ";

                rnd = rand.Next(0, 10);
                switch (rnd)
                {
                    case 0:
                        Economy_events.result += Economy_events.ev1;
                        break;
                    case 1:
                        Economy_events.result += Economy_events.ev2;
                        break;
                    case 2:
                        Economy_events.result += Economy_events.ev3;
                        break;
                    case 3:
                        Economy_events.result += Economy_events.ev4;
                        break;
                    case 4:
                        Economy_events.result += Economy_events.ev5;
                        break;
                    case 5:
                        Economy_events.result += Economy_events.ev6;
                        break;
                    case 6:
                        Economy_events.result += Economy_events.ev7;
                        break;
                    case 7:
                        Economy_events.result += Economy_events.ev8;
                        break;
                    case 8:
                        Economy_events.result += Economy_events.ev9;
                        break;
                    case 9:
                        Economy_events.result += Economy_events.ev10;
                        break;
                }

                Economy_events.result += "\n";
            }

            chart1.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Сировина", "Остача" }, new int[] { Сharacteristics.material_coming, Сharacteristics.material_consumption, Сharacteristics.material_raw, Сharacteristics.material_remainder });

            if (Сharacteristics.material_coming == 100 || Сharacteristics.material_consumption == 100 || Сharacteristics.material_raw == 100 || Сharacteristics.material_remainder == 100)
            {
                timer1.Stop();
                //MessageBox.Show("У вас кризис. Поздравляю!", "qwe", MessageBoxButtons.OK);
                Economy_events.result += "                       Кінець моделювання\n";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Grafic_Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //timer1.Interval = 6000 - trackBar1.Value;
            timer1.Start();
        }

        private void переглянутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
        }

        private void розпочатиПокроковеМоделюванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            розпочатиПокроковеМоделюванняToolStripMenuItem.Enabled = false;
            зупинитиПокроковеМоделюванняToolStripMenuItem.Enabled = true;
        }

        private void зупинитиПокроковеМоделюванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            розпочатиПокроковеМоделюванняToolStripMenuItem.Enabled = true;
            зупинитиПокроковеМоделюванняToolStripMenuItem.Enabled = false;
        }

        private void змоделювати1КрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafic_Update();
        }

        private void змінитиВхідніДаніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();
                DialogResult result = MessageBox.Show("Зупинити покрокове моделювання та змінити вхідні дані?", "Увага", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Form2 newForm = new Form2();
                    newForm.Show();
                    this.Hide();
                }
                else
                    timer1.Start();
            }
            else
            {
                Form2 newForm = new Form2();
                newForm.Show();
                this.Hide();
            }
            
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //виробник сировини
            chart1.Series["Data"].Points.AddXY("Прихід", Сharacteristics.material_coming);
            chart1.Series["Data"].Points.AddXY("Витрати", Сharacteristics.material_consumption);
            chart1.Series["Data"].Points.AddXY("Сировина", Сharacteristics.material_raw);
            chart1.Series["Data"].Points.AddXY("Остача", Сharacteristics.material_remainder);
            chart1.ChartAreas[0].AxisY.Maximum = 100;

            //Виробник засобів виробництва
            chart2.Series["Data"].Points.AddXY("Прихід", Сharacteristics.manufacturer_coming);
            chart2.Series["Data"].Points.AddXY("Витрати", Сharacteristics.manufacturer_consumption);
            chart2.Series["Data"].Points.AddXY("Сировина", Сharacteristics.manufacturer_raw);
            chart2.Series["Data"].Points.AddXY("Остача", Сharacteristics.manufacturer_remainder);
            chart2.ChartAreas[0].AxisY.Maximum = 100;

            //Виробник споживчих товарів
            chart3.Series["Data"].Points.AddXY("Прихід", Сharacteristics.consumer_coming);
            chart3.Series["Data"].Points.AddXY("Витрати", Сharacteristics.consumer_consumption);
            chart3.Series["Data"].Points.AddXY("Сировина", Сharacteristics.consumer_raw);
            chart3.Series["Data"].Points.AddXY("Остача", Сharacteristics.consumer_remainder);
            chart3.ChartAreas[0].AxisY.Maximum = 100;

            //Торгівля та Послуги
            chart4.Series["Data"].Points.AddXY("Прихід", Сharacteristics.trade_coming);
            chart4.Series["Data"].Points.AddXY("Витрати", Сharacteristics.trade_consumption);
            chart4.Series["Data"].Points.AddXY("Сировина", Сharacteristics.trade_raw);
            chart4.Series["Data"].Points.AddXY("Остача", Сharacteristics.trade_remainder);
            chart4.ChartAreas[0].AxisY.Maximum = 100;

            //Бюджет
            chart5.Series["Data"].Points.AddXY("Прихід", Сharacteristics.budget_coming);
            chart5.Series["Data"].Points.AddXY("Витрати", Сharacteristics.budget_consumption);
            chart5.Series["Data"].Points.AddXY("Остача", Сharacteristics.budget_remainder);
            chart5.ChartAreas[0].AxisY.Maximum = 100;

            //Комерційні банки
            chart6.Series["Data"].Points.AddXY("Прихід", Сharacteristics.commercial_coming);
            chart6.Series["Data"].Points.AddXY("Витрати", Сharacteristics.commercial_consumption);
            chart6.Series["Data"].Points.AddXY("Остача", Сharacteristics.commercial_remainder);
            chart6.ChartAreas[0].AxisY.Maximum = 100;

            //Покупці споживчих товарі
            chart7.Series["Data"].Points.AddXY("Прихід", Сharacteristics.buyers_coming);
            chart7.Series["Data"].Points.AddXY("Витрати", Сharacteristics.buyers_consumption);
            chart7.Series["Data"].Points.AddXY("Остача", Сharacteristics.buyers_remainder);
            chart7.ChartAreas[0].AxisY.Maximum = 100;

            //Нацбанк
            chart8.Series["Data"].Points.AddXY("Запас", Сharacteristics.bank_stock);
            chart8.Series["Data"].Points.AddXY("Витрати", Сharacteristics.bank_consumption);
            chart8.Series["Data"].Points.AddXY("Ємісія", Сharacteristics.bank_emission);
            chart8.Series["Data"].Points.AddXY("Остача", Сharacteristics.bank_remainder);
            chart8.ChartAreas[0].AxisY.Maximum = 100;

            розпочатиПокроковеМоделюванняToolStripMenuItem.Enabled = true;
            зупинитиПокроковеМоделюванняToolStripMenuItem.Enabled = false;

            timer1.Interval = 1000 / InputData.speed;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grafic_Update();
        }

        private void дузнатисяБільшеПроПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }
    }
}
