using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Func
{
    [TestFixture]
    class TestCounter
    {
        [Test]
        public static void TestGetDerivative()
        {
            Func<double,double> f = x => x * x * x;
            double res = Counters.GetDerivative(f, 1);
            Assert.AreEqual(3, res, 0.01);
        }

        [Test]
        public static void TestSecondGetDerivative()
        {
            Func<double, double> f = x => x * x * x;
            double res = Counters.GetSecondDerivative(f, 1);
            Assert.AreEqual(6, res, 0.01);
        }
    }
}
