using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurocomputing.Functions
{
    public class Sigmoid : IActivationFunction
    {
        public double Activate(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        public double Derivate(double x)
        {
            var f = Activate(x);
            return f * (1 - f);
        }
    }
}
