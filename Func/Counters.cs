using System;
using System.Collections.Generic;
using System.Text;

namespace Func
{
    public class Counters
    {
        public static double Count(double a, double b, Func<double, double> f, double delta)
        {
            double fa = f(a);
            if (fa == 0) return a;

            double fb = f(b);
            if (fb == 0) return b;
            if (fa * fb > 0) throw new Exception();

            double x = (a + b) / 2;
            double fx = f(x);
            if (fx == 0) return x;

            while (Math.Abs(a -b) > delta && Math.Abs(fa - fb) > delta)
            {
                if(fa*fx < 0)
                {
                    b = x;
                    fb = fx;
                }
                else
                {
                    a = x;
                    fa = fx;
                }
                x = (a + b) / 2;
                fx = f(x);
                if (fx == 0) return x;
            }
            fa = Math.Abs(fa);
            fb = Math.Abs(fb);
            fx = Math.Abs(fx);
            if (fa <= fb && fa <= fx)
            {
                return a;
            }
            if (fb <= fa && fb <= fx)
            {
                return b;
            }
            return x;
        }

        public static double CountNewton(double a, double b, Func<double, double> f, double delta)
        {
            double x0, x1;
            if (CountStartX(f, a) > 0) x0 = a;
            else if (CountStartX(f, b) > 0) x0 = b;
            else throw new ArgumentException();
            x1 = CountNextX(f, x0);
            while(Math.Abs(x0 - x1) > delta)
            {
                x0 = x1;
                x1 = CountNextX(f, x0);
            }
            return x1;
        }

        public static double GetDerivative(Func<double, double> f,double x)
        {
            double d = 0.00001;
            return (f(x + d) - f(x)) / d;
        }

        public static double GetSecondDerivative(Func<double, double> f, double x)
        {
            double d = 0.00001;
            double dfx = GetDerivative(f, x + d) - GetDerivative(f, x);
            return dfx / d;
        }

        static double CountStartX(Func<double, double> f, double x) =>
            f(x) * GetSecondDerivative(f, x);

        static double CountNextX(Func<double, double> f, double x) =>
            x - f(x) / GetDerivative(f, x); 
    }    
}
