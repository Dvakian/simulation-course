using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Parent = pictureBox1;
            chart1.Dock = DockStyle.None;
            chart1.BackColor = Color.FromArgb(100, Color.White);
            chart1.BringToFront();

            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].BorderColor = Color.Transparent;

            inputAngle.Value = 45;
            inputSpeed.Value = 10;
            inputSize.Value = 0.1M;
            inputWeight.Value = 1;
            inputDT.Value = 0.0001M;

            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Legends.Add("Legend");
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            labelMaxHeight.Text = "Max Height: -";
            labelRange.Text = "Range: -";
            labelFinalSpeed.Text = "Speed: —";
        }

        private void inputSpeed_ValueChanged(object sender, EventArgs e) { }

        private void inputDT_ValueChanged(object sender, EventArgs e) { }

        const decimal g = 9.81M, C = 0.15M, rho = 1.29M;
        decimal dt, t, x, y, v0, cosa, sina, S, m, k, vx, vy;
        private void button1_Click(object sender, EventArgs e)
        {
            dt = inputDT.Value;
            if (dt == 0)
                dt = 0.0001M;

            string name = $"dt = {dt}";
            if (chart1.Series.IndexOf(name) >= 0)
                chart1.Series.Remove(chart1.Series[name]);

            Series s = new Series(name);
            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 2;
            s.Legend = "Legend";
            chart1.Series.Add(s);

            x = 0; y = inputHeight.Value; v0 = inputSpeed.Value;

            double a = (double)inputAngle.Value * Math.PI / 180;
            cosa = (decimal)Math.Cos(a);
            sina = (decimal)Math.Sin(a);

            S = inputSize.Value;
            m = inputWeight.Value;
            k = 0.5M * C * rho * S / m;

            vx = v0 * cosa; vy = v0 * sina;

            //chart1.Series[0].Points.AddXY(x, y);
            s.Points.AddXY(x, y);

            decimal maxY = y;
            while (true)
            {
               // decimal xPrev = x, yPrev = y;

                decimal v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));

                vx = vx - k * vx * v * dt;
                vy = vy - (g + k * vy * v) * dt;

                x = x + vx * dt;
                y = y + vy * dt;


                if (y <= 0)
                {
                 //   decimal r = yPrev / (yPrev - y);
                   // decimal xHit = xPrev + (x - xPrev) * r;

                    //s.Points.AddXY(xHit, 0);
                    s.Points.AddXY(x, 0);
                    break;
                }

                if (y > maxY)
                    maxY = y;

                s.Points.AddXY(x, y);
            }

            decimal vFinal = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            labelMaxHeight.Text = $"Max Height: {maxY:F3}";
            labelRange.Text = $"Range: {x:F3}";
            labelFinalSpeed.Text = $"Speed: {vFinal:F3}";

        }
        private void button6_Click(object sender, EventArgs e)
        {
            inputDT.Value = 0.001M;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputDT.Value = 0.01M;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputDT.Value = 0.1M;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputDT.Value = 1;
        }
    }
}