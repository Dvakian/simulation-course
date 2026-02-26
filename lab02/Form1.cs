using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            inputRho.Minimum = 0; inputRho.Maximum = 100000;
            inputC.Minimum = 0; inputC.Maximum = 100000;
            inputLambda.Minimum = 0; inputLambda.Maximum = 100000;
            inputL.Minimum = 0; inputL.Maximum = 100000;
            inputTime.Minimum = 0; inputTime.Maximum = 100000;
            inputStartT.Minimum = -10000; inputStartT.Maximum = 10000;
            inputTLeft.Minimum = -1000; inputTLeft.Maximum = 1000000;
            inputTRight.Minimum = -1000; inputTRight.Maximum = 1000000;

            inputH.Value = 0.01M; inputTau.Value = 0.01M;
            inputRho.Value = 11340; inputC.Value = 130;
            inputLambda.Value = 35.1M; inputL.Value = 0.05M;
            inputTime.Value = 100; inputStartT.Value = 23;
            inputTLeft.Value = 6000; inputTRight.Value = 23;


        }

        double h, tau, rho, c, lambda, L, time, T0, TLeft, TRight;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("aboba");

            inputH.Value = 0.01M; inputTau.Value = 0.01M; 
            inputRho.Value = 2500; inputC.Value = 920; 
            inputLambda.Value = 1.18M; inputL.Value = 0.05M; 
            inputTime.Value = 100; inputStartT.Value = -5;
            inputTLeft.Value = -5; inputTRight.Value = 150;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            h = (double)inputH.Value; tau = (double)inputTau.Value;
            rho = (double)inputRho.Value; c = (double)inputC.Value; lambda = (double)inputLambda.Value;
            L = (double)inputL.Value; time = (double)inputTime.Value;
            T0 = (double)inputStartT.Value; TLeft = (double)inputTLeft.Value; TRight = (double)inputTRight.Value;

            int N = (int)(L / h) + 1, M = (int)(time / tau);

            double[] T = new double[N], alpha = new double[N], beta = new double[N];

            for (int i = 0; i < N; i++)
                T[i] = T0;

            double Ai = lambda / (h * h), Bi = 2 * lambda / (h * h) + (rho * c / tau);
            double Ci = Ai;

            T[0] = TLeft;
            T[T.Length - 1] = TRight;

            timer.Start();

            for (int k = 0; k < M; k++) 
            {
                alpha[0] = 0.0;
                beta[0] = TLeft;

                for (int i = 1; i < N; i++) 
                {
                    double Fi = -(rho * c) / tau * T[i];

                    alpha[i] = Ai / (Bi - Ci * alpha[i - 1]);
                    beta[i] = (Ci * beta[i - 1] - Fi) / (Bi - Ci * alpha[i - 1]);
                }

                for (int i = N - 2; i > 0; i--)
                    T[i] = alpha[i] * T[i + 1] + beta[i];

                if (k % 100 == 0 || k == M - 1)
                {
                    chart1.Series[0].Points.Clear();
                    for (int i = 0; i < N; i++)
                        chart1.Series[0].Points.AddXY(i * h, T[i]);
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = L;
                    Application.DoEvents();
                }
            }
            timer.Stop();

            int center = N / 2;
            double TCenter = T[center];
            double realTime = timer.Elapsed.TotalSeconds;
            dataGridView1.Rows.Add(h, tau, TCenter, realTime);
            dataGridView1.DefaultCellStyle.Format = "F4";
        }
    }
}