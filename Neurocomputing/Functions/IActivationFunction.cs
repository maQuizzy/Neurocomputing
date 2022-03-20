using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurocomputing.Functions
{
    public interface IActivationFunction
    {
        double Activate(double x);
        double Derivate(double x);
    }
}
