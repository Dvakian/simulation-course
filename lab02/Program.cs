using System;
using System.Runtime.CompilerServices;


static void Main()
{
    /*void aboba(double rho, double c, double lambda, double tau)
    {
        double h = L / N;
        double Ai = lambda / (h * h);
        double Bi = (2 * lambda / (h * h)) + (rho * c / tau);
        double Ci = Ai;

        double TL = -100.0, TR = 100.0;

        int N = 10;
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
            beta[i] = (Ci * beta[i - 1] - Fi)
                / (Bi - Ci * alpha[i - 1]);
        }

        double[] Tnext = new double[N];
        Tnext[N - 1] = TR;
        Tnext[0] = TL;

        for (int i = N - 2; i >= 1; i--)
            Tnext[i] = alpha[i] * Tnext[i + 1] + beta[i];

        var tmp = Tnext; Tn = Tnext; Tnext = tmp;

    }*/

    void Aboba(double rho, double c, double lambda, double L, int N, double tau)
    {
        double h = L / (N - 1);

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
    }

    double rho = 7800, c = 460, lambda = 46;

    double L = 0.5; //толщина пластины
    int N = 10; //кол-во узлов

    double tEnd = 2.0;
    int m = 200; //число шагов
    double tau = tEnd / m;

    Aboba(rho, c, lambda, L, N, tau);
}