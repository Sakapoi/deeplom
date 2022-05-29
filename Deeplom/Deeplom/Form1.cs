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

        int material_counter = 0;
        int manufacturer_counter = 0;
        int consumer_counter = 0;
        int trade_counter = 0;

        void Grafic_Update() 
        {
            Economy_events.day++;
            Random rand = new Random();
            Economy_events.result += "---------------- День " + Economy_events.day + " ----------------\n";

            if (Economy_events.day == 1)//1
            {
                InputData.vs_initial_amount_of_money = rand.Next(InputData.vs_initial_amount_of_money_min, InputData.vs_initial_amount_of_money_max + 1);
                InputData.vzv_initial_amount_of_money = rand.Next(InputData.vzv_initial_amount_of_money_min, InputData.vzv_initial_amount_of_money_max + 1);
                InputData.vst_initial_amount_of_money = rand.Next(InputData.vst_initial_amount_of_money_min, InputData.vst_initial_amount_of_money_max + 1);
                InputData.ttp_initial_amount_of_money = rand.Next(InputData.ttp_initial_amount_of_money_min, InputData.ttp_initial_amount_of_money_max + 1);

                InputData.vs_process_cycle_time = rand.Next(InputData.vs_process_cycle_time_min, InputData.vs_process_cycle_time_max + 1);
                InputData.vs_markup_percentage = rand.Next(InputData.vs_markup_percentage_min, InputData.vs_markup_percentage_max + 1);
                InputData.vzv_process_cycle_time = rand.Next(InputData.vzv_process_cycle_time_min, InputData.vzv_process_cycle_time_max + 1);
                InputData.vzv_markup_percentage = rand.Next(InputData.vzv_markup_percentage_min, InputData.vzv_markup_percentage_max + 1);
                InputData.vst_process_cycle_time = rand.Next(InputData.vst_process_cycle_time_min, InputData.vst_process_cycle_time_max + 1);
                InputData.vst_markup_percentage = rand.Next(InputData.vst_markup_percentage_min, InputData.vst_markup_percentage_max + 1);

                Сharacteristics.material_remainder = InputData.vs_initial_amount_of_money;
                Сharacteristics.manufacturer_remainder = InputData.vzv_initial_amount_of_money;
                Сharacteristics.consumer_remainder = InputData.vst_initial_amount_of_money;
                Сharacteristics.trade_remainder = InputData.ttp_initial_amount_of_money;
                Сharacteristics.commercial_remainder = InputData.commercial_bank_amount;
                Сharacteristics.bank_stock = InputData.national_Bank_total_amount;
                Сharacteristics.bank_remainder = InputData.national_Bank_total_amount;
            }

            Сharacteristics.material_coming = 0;
            Сharacteristics.manufacturer_coming = 0;
            Сharacteristics.consumer_coming = 0;
            Сharacteristics.trade_coming = 0;
            Сharacteristics.budget_coming = 0;
            Сharacteristics.commercial_coming = 0;
            Сharacteristics.buyers_coming = 0;

            Сharacteristics.material_consumption = 0;
            Сharacteristics.manufacturer_consumption = 0;
            Сharacteristics.consumer_consumption = 0;
            Сharacteristics.trade_consumption = 0;
            Сharacteristics.budget_consumption = 0;
            Сharacteristics.commercial_consumption = 0;
            Сharacteristics.buyers_consumption = 0;
            Сharacteristics.bank_consumption = 0;

            if (Сharacteristics.material_raw > 0)//2
            {
                Сharacteristics.material_coming = Сharacteristics.material_raw * InputData.vs_markup_percentage / 100;//заработал деньги за товар
               
                Сharacteristics.manufacturer_remainder -= Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;//отнимаем деньги у купивших товар
                Сharacteristics.consumer_remainder -= Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;
                Сharacteristics.trade_remainder -= Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;

                Сharacteristics.manufacturer_consumption += Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;//делаем расход купившим товар
                Сharacteristics.consumer_consumption += Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;
                Сharacteristics.trade_consumption += Сharacteristics.material_raw * InputData.vs_markup_percentage / 300;

                Сharacteristics.material_raw = 0;//продал товар, его не стало

                Economy_events.result += Economy_events.material + Economy_events.ev10;
                Economy_events.result += Economy_events.manufacturer + Economy_events.ev8;
                Economy_events.result += Economy_events.consumer + Economy_events.ev8;
                Economy_events.result += Economy_events.trade + Economy_events.ev8;
            }
            else
            {
                if (material_counter == InputData.vs_process_cycle_time)
                {
                    Сharacteristics.material_consumption += Сharacteristics.material_remainder / 10;//потратил деньги на производство сырья
                    Сharacteristics.material_remainder -= Сharacteristics.material_remainder / 10;
                    Сharacteristics.material_raw += (Сharacteristics.material_remainder + Сharacteristics.material_remainder / 10);//произвели товар(думаю)
                    material_counter = 0;

                    Economy_events.result += Economy_events.material + Economy_events.ev6;
                }
                else 
                    material_counter++;
            }

            if (Сharacteristics.manufacturer_raw > 0)//2
            {
                Сharacteristics.manufacturer_coming += Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 100;//заработал деньги за товар

                Сharacteristics.material_remainder -= Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;
                Сharacteristics.consumer_remainder -= Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;
                Сharacteristics.trade_remainder -= Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;

                Сharacteristics.material_consumption += Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;
                Сharacteristics.consumer_consumption += Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;
                Сharacteristics.trade_consumption += Сharacteristics.manufacturer_raw * InputData.vzv_markup_percentage / 300;

                Сharacteristics.manufacturer_raw = 0;//продал товар, его не стало

                Economy_events.result += Economy_events.manufacturer + Economy_events.ev10;
                Economy_events.result += Economy_events.material + Economy_events.ev8;
                Economy_events.result += Economy_events.consumer + Economy_events.ev8;
                Economy_events.result += Economy_events.trade + Economy_events.ev8;
            }
            else
            {
                if (manufacturer_counter == InputData.vzv_process_cycle_time)
                {
                    Сharacteristics.manufacturer_consumption += Сharacteristics.manufacturer_remainder / 10;//потратил деньги на производство сырья
                    Сharacteristics.manufacturer_remainder -= Сharacteristics.manufacturer_remainder / 10;
                    Сharacteristics.manufacturer_raw += (Сharacteristics.manufacturer_remainder + Сharacteristics.manufacturer_remainder / 10);//произвели товар(думаю)
                    
                    Сharacteristics.manufacturer_coming = 0;

                    Economy_events.result += Economy_events.manufacturer + Economy_events.ev6;
                }
                else
                    manufacturer_counter++;
            }

            if (Сharacteristics.consumer_raw > 0)//2
            {
                Сharacteristics.consumer_coming += Сharacteristics.consumer_raw * InputData.vst_markup_percentage / 100;//заработал деньги за товар

                Сharacteristics.trade_remainder -= Сharacteristics.consumer_raw * InputData.vst_markup_percentage / 100;

                Сharacteristics.trade_consumption += Сharacteristics.consumer_raw * InputData.vst_markup_percentage / 100;

                Сharacteristics.consumer_raw = 0;//продал товар, его не стало

                Economy_events.result += Economy_events.consumer + Economy_events.ev10;
                Economy_events.result += Economy_events.trade + Economy_events.ev8;
            }
            else
            {
                if (consumer_counter == InputData.vst_process_cycle_time)
                {
                    Сharacteristics.consumer_consumption += Сharacteristics.consumer_remainder / 10;//потратил деньги на производство сырья
                    Сharacteristics.consumer_remainder -= Сharacteristics.consumer_remainder / 10;
                    Сharacteristics.consumer_raw += (Сharacteristics.consumer_remainder + Сharacteristics.consumer_remainder / 10);//произвели товар(думаю)
                    consumer_counter = 0;

                    Economy_events.result += Economy_events.consumer + Economy_events.ev6;
                }
                else
                    consumer_counter++;
            }

            if (Сharacteristics.trade_raw > 0)//2
            {
                Сharacteristics.trade_coming += Сharacteristics.trade_raw / 10;//заработал деньги за товар

                Сharacteristics.material_consumption += Сharacteristics.trade_raw / 70;
                Сharacteristics.consumer_consumption += Сharacteristics.trade_raw / 70;
                Сharacteristics.manufacturer_consumption += Сharacteristics.trade_raw / 70;
                Сharacteristics.budget_consumption += Сharacteristics.trade_raw / 70;
                Сharacteristics.commercial_consumption += Сharacteristics.trade_raw / 70;
                Сharacteristics.buyers_consumption += Сharacteristics.buyers_remainder * InputData.money_spending_percentage / 100;
                Сharacteristics.bank_consumption += Сharacteristics.trade_raw / 70;

                Сharacteristics.material_remainder -= Сharacteristics.trade_raw / 70;
                Сharacteristics.consumer_remainder -= Сharacteristics.trade_raw / 70;
                Сharacteristics.manufacturer_remainder -= Сharacteristics.trade_raw / 70;
                Сharacteristics.budget_remainder -= Сharacteristics.trade_raw / 70;
                Сharacteristics.commercial_remainder -= Сharacteristics.trade_raw / 70;
                Сharacteristics.buyers_remainder -= Сharacteristics.buyers_remainder * InputData.money_spending_percentage / 100;
                Сharacteristics.bank_remainder -= Сharacteristics.trade_raw / 70;

                Сharacteristics.trade_raw = 0;//продал товар, его не стало

                Economy_events.result += Economy_events.trade + Economy_events.ev10;
                Economy_events.result += Economy_events.material + Economy_events.ev8;
                Economy_events.result += Economy_events.consumer + Economy_events.ev8;
                Economy_events.result += Economy_events.manufacturer + Economy_events.ev8;
                Economy_events.result += Economy_events.budget + Economy_events.ev8;
                Economy_events.result += Economy_events.commercial + Economy_events.ev8;
                Economy_events.result += Economy_events.buyers + Economy_events.ev8;
                Economy_events.result += Economy_events.bank + Economy_events.ev8;
            }
            else
            {
                if (trade_counter == 1)
                {
                    Сharacteristics.trade_consumption += Сharacteristics.trade_remainder / 10;//потратил деньги на производство сырья
                    Сharacteristics.trade_remainder -= Сharacteristics.trade_remainder / 10;
                    Сharacteristics.trade_raw += (Сharacteristics.trade_remainder + Сharacteristics.trade_remainder / 10);//произвели товар(думаю)
                    trade_counter = 0;

                    Economy_events.result += Economy_events.trade + Economy_events.ev6;
                }
                else
                    trade_counter++;
            }

            if (Сharacteristics.material_coming > 0)//3
            {
                Сharacteristics.material_remainder += Сharacteristics.material_coming -
                    (Сharacteristics.material_coming * InputData.tax_money_percentage / 100
                    + Сharacteristics.material_coming * InputData.pay_wages_percentage / 100);//заплатил налоги и зп

                Сharacteristics.budget_coming += Сharacteristics.material_coming - Сharacteristics.material_coming * InputData.tax_money_percentage / 100;
                Сharacteristics.budget_remainder += Сharacteristics.material_coming - Сharacteristics.material_coming * InputData.tax_money_percentage / 100;

                Economy_events.result += Economy_events.material + Economy_events.ev1;
                Economy_events.result += Economy_events.material + Economy_events.ev2;
            }

            if (Сharacteristics.manufacturer_coming > 0)//3 5
            {
                Сharacteristics.manufacturer_remainder += Сharacteristics.manufacturer_coming -
                    (Сharacteristics.manufacturer_coming * InputData.tax_money_percentage / 100
                    + Сharacteristics.manufacturer_coming * InputData.pay_wages_percentage / 100);//заплатил налоги и зп

                Сharacteristics.budget_coming += Сharacteristics.manufacturer_coming - Сharacteristics.manufacturer_coming * InputData.tax_money_percentage / 100;
                Сharacteristics.budget_remainder += Сharacteristics.manufacturer_coming - Сharacteristics.manufacturer_coming * InputData.tax_money_percentage / 100;

                Economy_events.result += Economy_events.manufacturer + Economy_events.ev1;
                Economy_events.result += Economy_events.manufacturer + Economy_events.ev2;
            }

            if (Сharacteristics.consumer_coming > 0)//3
            {
                Сharacteristics.consumer_remainder += Сharacteristics.consumer_coming -
                    (Сharacteristics.consumer_coming * InputData.tax_money_percentage / 100
                    + Сharacteristics.consumer_coming * InputData.pay_wages_percentage / 100);//заплатил налоги и зп

                Сharacteristics.budget_coming += Сharacteristics.consumer_coming - Сharacteristics.consumer_coming * InputData.tax_money_percentage / 100;
                Сharacteristics.budget_remainder += Сharacteristics.consumer_coming - Сharacteristics.consumer_coming * InputData.tax_money_percentage / 100;

                Economy_events.result += Economy_events.consumer + Economy_events.ev1;
                Economy_events.result += Economy_events.consumer + Economy_events.ev2;
            }

            if (Сharacteristics.trade_coming > 0)//3
            {
                Сharacteristics.trade_remainder += Сharacteristics.trade_coming -
                    (Сharacteristics.trade_coming * InputData.tax_money_percentage / 100
                    + Сharacteristics.trade_coming * InputData.pay_wages_percentage / 100);//заплатил налоги и зп

                Сharacteristics.budget_coming += Сharacteristics.trade_coming - Сharacteristics.trade_coming * InputData.tax_money_percentage / 100;
                Сharacteristics.budget_remainder += Сharacteristics.trade_coming - Сharacteristics.trade_coming * InputData.tax_money_percentage / 100;

                Economy_events.result += Economy_events.trade + Economy_events.ev1;
                Economy_events.result += Economy_events.trade + Economy_events.ev2;
            }

            if (Сharacteristics.material_remainder < (InputData.vs_initial_amount_of_money / 10))//кредит у комбанка
            {
                Сharacteristics.material_remainder += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;
                Сharacteristics.commercial_remainder -= Сharacteristics.commercial_remainder / 10;

                Сharacteristics.commercial_consumption += Сharacteristics.commercial_remainder / 10;
                Сharacteristics.material_coming += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;

                Economy_events.result += Economy_events.material + Economy_events.ev3;
            }

            if (Сharacteristics.manufacturer_remainder < (InputData.vzv_initial_amount_of_money / 10))//кредит у комбанка
            {
                Сharacteristics.manufacturer_remainder += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;
                Сharacteristics.commercial_remainder -= Сharacteristics.commercial_remainder / 10;

                Сharacteristics.commercial_consumption += Сharacteristics.commercial_remainder / 10;
                Сharacteristics.manufacturer_coming += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;

                Economy_events.result += Economy_events.manufacturer + Economy_events.ev3;
            }

            if (Сharacteristics.consumer_remainder < (InputData.vst_initial_amount_of_money / 10))//кредит у комбанка
            {
                Сharacteristics.consumer_remainder += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;
                Сharacteristics.commercial_remainder -= Сharacteristics.commercial_remainder / 10;

                Сharacteristics.commercial_consumption += Сharacteristics.commercial_remainder / 10;
                Сharacteristics.consumer_coming += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;

                Economy_events.result += Economy_events.consumer + Economy_events.ev3;
            }

            if (Сharacteristics.trade_remainder < (InputData.ttp_initial_amount_of_money / 10))//кредит у комбанка
            {
                Сharacteristics.trade_remainder += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;
                Сharacteristics.commercial_remainder -= Сharacteristics.commercial_remainder / 10;

                Сharacteristics.commercial_consumption += Сharacteristics.commercial_remainder / 10;
                Сharacteristics.trade_coming += InputData.commercial_bank_amount * InputData.interest_on_loans / 70;

                Economy_events.result += Economy_events.trade + Economy_events.ev3;
            }

            if (Сharacteristics.commercial_remainder < (InputData.commercial_bank_amount / 10))//кредит у нацбанка
            {
                Сharacteristics.commercial_remainder += InputData.national_Bank_total_amount * InputData.national_Bank_rate / 70;
                Сharacteristics.bank_remainder -= Сharacteristics.bank_remainder / 7;

                Сharacteristics.bank_consumption += Сharacteristics.bank_remainder / 7;
                Сharacteristics.commercial_coming += InputData.national_Bank_total_amount * InputData.national_Bank_rate / 70;

                Economy_events.result += Economy_events.commercial + Economy_events.ev3;
            }

            if (Сharacteristics.budget_remainder > 300)
            {
                Сharacteristics.buyers_coming += Сharacteristics.budget_remainder / 2;
                Сharacteristics.buyers_remainder += Сharacteristics.budget_remainder / 2;

                Сharacteristics.budget_consumption += Сharacteristics.budget_remainder;
                Сharacteristics.budget_remainder = 0;

                Economy_events.result += Economy_events.budget + Economy_events.ev7;
                Economy_events.result += Economy_events.budget + Economy_events.ev9;
            }

            if (rand.Next(1, 100) < InputData.likelihood_of_an_emergency)
            {
                Сharacteristics.budget_consumption += Сharacteristics.budget_remainder / 2;
                Сharacteristics.budget_remainder -= Сharacteristics.budget_remainder / 2;

                Economy_events.result += Economy_events.budget + Economy_events.ev5;
            }

            if (Сharacteristics.bank_remainder < (InputData.national_Bank_total_amount / 10))//закончились деньги в нацбанке
            {
                Сharacteristics.bank_stock += 100;
                Сharacteristics.bank_emission += 100;
                Сharacteristics.bank_remainder += 100;

                Economy_events.result += Economy_events.bank + Economy_events.ev4;
            }

            chart1.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Сировина", "Остача" }, new int[] { Сharacteristics.material_coming, Сharacteristics.material_consumption, Сharacteristics.material_raw, Сharacteristics.material_remainder });

            //chart1.Series["Data"].Points.DataBindXY(new string[] { "Прихід" }, new int[] { Сharacteristics.material_coming });
            //chart1.Series["Data1"].Points.DataBindXY(new string[] { "Витрати" }, new int[] { Сharacteristics.material_consumption });
            //chart1.Series["Data2"].Points.DataBindXY(new string[] { "Сировина" }, new int[] { Сharacteristics.material_raw });
            //chart1.Series["Data3"].Points.DataBindXY(new string[] { "Остача" }, new int[] { Сharacteristics.material_remainder });

            chart2.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Сировина", "Остача" }, new int[] { Сharacteristics.manufacturer_coming, Сharacteristics.manufacturer_consumption, Сharacteristics.manufacturer_raw, Сharacteristics.manufacturer_remainder });
            chart3.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Сировина", "Остача" }, new int[] { Сharacteristics.consumer_coming, Сharacteristics.consumer_consumption, Сharacteristics.consumer_raw, Сharacteristics.consumer_remainder });
            chart4.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Сировина", "Остача" }, new int[] { Сharacteristics.trade_coming, Сharacteristics.trade_consumption, Сharacteristics.trade_raw, Сharacteristics.trade_remainder });
            chart6.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Остача" }, new int[] { Сharacteristics.budget_coming, Сharacteristics.budget_consumption, Сharacteristics.budget_remainder });
            chart7.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Остача" }, new int[] { Сharacteristics.commercial_coming, Сharacteristics.commercial_consumption, Сharacteristics.commercial_remainder });
            chart5.Series["Data"].Points.DataBindXY(new string[] { "Прихід", "Витрати", "Остача" }, new int[] { Сharacteristics.buyers_coming, Сharacteristics.buyers_consumption, Сharacteristics.buyers_remainder });
            chart8.Series["Data"].Points.DataBindXY(new string[] { "Запас", "Витрати", "Ємісія", "Остача" }, new int[] { Сharacteristics.bank_stock, Сharacteristics.bank_consumption, Сharacteristics.bank_emission, Сharacteristics.bank_remainder });

            if (Сharacteristics.bank_emission == 1000)//кризис
            {
                Economy_events.result += "---------------- Кінець програми ----------------\n";
                timer1.Stop();
                MessageBox.Show("У країні настала криза!", "Увага", MessageBoxButtons.OK);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Grafic_Update();
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
            //chart1.Series["Data"].Points[1].Color = Color.Red;
            chart1.ChartAreas[0].AxisY.Maximum = 1000;

            //Виробник засобів виробництва
            chart2.Series["Data"].Points.AddXY("Прихід", Сharacteristics.manufacturer_coming);
            chart2.Series["Data"].Points.AddXY("Витрати", Сharacteristics.manufacturer_consumption);
            chart2.Series["Data"].Points.AddXY("Сировина", Сharacteristics.manufacturer_raw);
            chart2.Series["Data"].Points.AddXY("Остача", Сharacteristics.manufacturer_remainder);
            chart2.ChartAreas[0].AxisY.Maximum = 1000;

            //Виробник споживчих товарів
            chart3.Series["Data"].Points.AddXY("Прихід", Сharacteristics.consumer_coming);
            chart3.Series["Data"].Points.AddXY("Витрати", Сharacteristics.consumer_consumption);
            chart3.Series["Data"].Points.AddXY("Сировина", Сharacteristics.consumer_raw);
            chart3.Series["Data"].Points.AddXY("Остача", Сharacteristics.consumer_remainder);
            chart3.ChartAreas[0].AxisY.Maximum = 1000;

            //Торгівля та Послуги
            chart4.Series["Data"].Points.AddXY("Прихід", Сharacteristics.trade_coming);
            chart4.Series["Data"].Points.AddXY("Витрати", Сharacteristics.trade_consumption);
            chart4.Series["Data"].Points.AddXY("Сировина", Сharacteristics.trade_raw);
            chart4.Series["Data"].Points.AddXY("Остача", Сharacteristics.trade_remainder);
            chart4.ChartAreas[0].AxisY.Maximum = 1000;

            //Покупці споживчих товарі
            chart5.Series["Data"].Points.AddXY("Прихід", Сharacteristics.buyers_coming);
            chart5.Series["Data"].Points.AddXY("Витрати", Сharacteristics.buyers_consumption);
            chart5.Series["Data"].Points.AddXY("Остача", Сharacteristics.buyers_remainder);
            chart5.ChartAreas[0].AxisY.Maximum = 1000;

            //Бюджет
            chart6.Series["Data"].Points.AddXY("Прихід", Сharacteristics.budget_coming);
            chart6.Series["Data"].Points.AddXY("Витрати", Сharacteristics.budget_consumption);
            chart6.Series["Data"].Points.AddXY("Остача", Сharacteristics.budget_remainder);
            chart6.ChartAreas[0].AxisY.Maximum = 1000;

            //Комерційні банки
            chart7.Series["Data"].Points.AddXY("Прихід", Сharacteristics.commercial_coming);
            chart7.Series["Data"].Points.AddXY("Витрати", Сharacteristics.commercial_consumption);
            chart7.Series["Data"].Points.AddXY("Остача", Сharacteristics.commercial_remainder);
            chart7.ChartAreas[0].AxisY.Maximum = 1000;

            //Нацбанк
            chart8.Series["Data"].Points.AddXY("Запас", Сharacteristics.bank_stock);
            chart8.Series["Data"].Points.AddXY("Витрати", Сharacteristics.bank_consumption);
            chart8.Series["Data"].Points.AddXY("Ємісія", Сharacteristics.bank_emission);
            chart8.Series["Data"].Points.AddXY("Остача", Сharacteristics.bank_remainder);
            chart8.ChartAreas[0].AxisY.Maximum = 2000;

            розпочатиПокроковеМоделюванняToolStripMenuItem.Enabled = true;
            зупинитиПокроковеМоделюванняToolStripMenuItem.Enabled = false;

            timer1.Interval = 1000 / InputData.speed;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void дузнатисяБільшеПроПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void виробникиСировиниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
            this.Hide();
        }

        private void виробникиЗасобівВиробництваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 newForm = new Form6();
            newForm.Show();
            this.Hide();
        }

        private void виробникиСпоживчихТоварівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 newForm = new Form7();
            newForm.Show();
            this.Hide();
        }

        private void торгівляТаПослугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 newForm = new Form8();
            newForm.Show();
            this.Hide();
        }

        private void іншіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 newForm = new Form9();
            newForm.Show();
            this.Hide();
        }
    }
}
