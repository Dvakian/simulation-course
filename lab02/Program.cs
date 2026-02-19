using System;
using System.Runtime.CompilerServices;



void main()
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