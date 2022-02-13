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
        int a = 10, b = 20, c = 30, d = 40;

        void Grafic_Update() 
        {
            Random rand = new Random();
            int rnd = rand.Next(0, 4);
            switch (rnd)
            {
                case 0:
                    a += 10;
                    break;
                case 1:
                    b += 10;
                    break;
                case 2:
                    c += 10;
                    break;
                case 3:
                    d += 10;
                    break;
            }
            chart1.Series["Govno"].Points.DataBindXY(new string[] { "Приход", "Расход", "Сырье", "Остаток" }, new int[] { a, b, c, d });
            //chart1.Series["Govno"].Points.DataBindY(new int[] { 20,20,30,40 });

            if (a == 100 || b == 100 || c == 100 || d == 100)
            {
                timer1.Stop();
                MessageBox.Show("У вас кризис. Поздравляю!", "Пиздец", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            b = int.Parse(textBox2.Text);
            c = int.Parse(textBox3.Text);
            d = int.Parse(textBox4.Text);
            chart1.Series["Govno"].Points.AddXY("Приход", a);
            chart1.Series["Govno"].Points.AddXY("Расход", b);
            chart1.Series["Govno"].Points.AddXY("Сырье", c);
            chart1.Series["Govno"].Points.AddXY("Остаток", d);
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.Visible = true;
            label1.Visible = true;
            button4.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
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
            timer1.Interval = 6000 - trackBar1.Value;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grafic_Update();
        }
    }
}
