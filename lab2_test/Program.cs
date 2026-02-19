using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_test
{
    internal class Program
    {
        static void Aboba(double rho, double c, double lambda, double L, int N,
            double tau, double h)
        {
            double Ai = lambda / (h * h);
            double Bi = (2 * lambda / (h * h)) + (rho * c / tau);
            double Ci = Ai;

            double TL = -100.0, TR = 100.0;
            double T0 = 0.0;

            double[] Tn = new double[N];
            for (int i = 0; i < N; i++)
                Tn[i] = T0;
            Tn[0] = TL;
            Tn[N - 1] = TR;

            double[] alpha = new double[N];
            double[] beta = new double[N];

            alpha[0] = 0.0;
            beta[0] = TL;

            for (int i = 1; i <= N - 2; i++)
            {
                double Fi = -1 * (rho * c / tau) * Tn[i];

                alpha[i] = Ai / (Bi - Ci * alpha[i - 1]);

                beta[i] = (Ci * beta[i - 1] - Fi) / (Bi - Ci * alpha[i - 1]);
            }

            double[] Tnext = new double[N];
            Tnext[0] = TL;
            Tnext[N - 1] = TR;

            for (int i = N - 2; i >= 1; i--)
                Tnext[i] = alpha[i] * Tnext[i + 1] + beta[i];

            var tmp = Tnext; Tn = Tnext; Tnext = tmp;

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"T[{i}] = {Tn[i]}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("aboba");
            double rho = 7800, c = 460, lambda = 46;

            double L = 0.5; //толщина пластины
            int N = 10; //кол-во узлов

            int m = 200; //число шагов
            double tau = 0.1;

            double h = 0.1;

            Aboba(rho, c, lambda, L, N, tau, h);
        }
    }
}
