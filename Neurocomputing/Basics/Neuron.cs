using Neurocomputing.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Neurocomputing.Basics
{
    class Neuron
    {
        private IActivationFunction _activatorFunc;
        public double[] Inputs { get; set; }
        public double[] Weights { get; set; }
        public double Bias { get; set; }

        public double Output { get; private set; }

        public Neuron(IActivationFunction activatorFunc, double[] weights)
        {
            _activatorFunc = activatorFunc;
            Weights = weights;
        }

        public double Summator()
        {
            double sum = 0;

            for (int i = 0; i < Inputs.Length; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            sum += Bias;

            return sum;
        }

        public void Activate()
        {
            double sum = Summator();

            Output = _activatorFunc.Activate(sum);
        }

        public void RandomizeWeights(Random rnd)
        {
            for(int i = 0; i < Weights.Length; i++)
                Weights[i] = rnd.NextDouble() * 8 - 4;
        }
    }
}
