using System;
using System.Collections.Generic;
using System.Text;

namespace Func
{
    public class Counters
    {
        public static double Count(double a, double b, Func<double, double> f, double delta)
        {
            double x = (a + b) / 2;
            double fa = f(a);
            if (fa == 0) return a;

            double fb = f(b);
            if (fb == 0) return b;
            if (fa * fb > 0) throw new Exception();
            double fx = f(x);
            while (Math.Abs(a -b) > delta && Math.Abs(fa - fb) > delta)
            {
                if (fx == 0) return x;
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
            }
            fa = Math.Abs(fa);
            fb = Math.Abs(fb);
            fx = Math.Abs(fx);
            if (fa < fb && fa < fx)
            {
                return a;
            }
            if (fb < fa && fb < fx)
            {
                return b;
            }
            return x;
        }
    }
}
