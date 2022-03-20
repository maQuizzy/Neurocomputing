using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurocomputing.Functions;

namespace Neurocomputing.Basics
{
    class Layer
    {
        private Neuron[] _neurons;

        public double[] Outputs { 
            get
            {
                return _neurons.Select(n => n.Output).ToArray();
            } 
        }

        public LayerConfig Config { get; }

        public Layer(LayerConfig config)
        {
            Config = config;
            FillNeuronsList();
        }

        public void SetInputs(double[] inputs)
        {
            foreach (var neuron in _neurons)
            {
                neuron.Inputs = inputs;
            }
        }

        public double[] Compute()
        {
            double[] output = new double[_neurons.Length];

            for (int i = 0; i < _neurons.Length; i++)
            {
                _neurons[i].Activate();
                output[i] = _neurons[i].Output;
            }

            return output;
        }

        public void RandomizeWeights(Random rnd)
        {
            foreach (var neuron in _neurons)
                neuron.RandomizeWeights(rnd);
        }


        private void FillNeuronsList()
        {
            _neurons = new Neuron[Config.Size];

            for (int i = 0; i < _neurons.Length; i++)
            {
                var weights = new double[Config.PrevLayerSize];
                _neurons[i] = new Neuron(Config.ActivationFunction, weights);
            }

        }

        public double[] ComputeError(double[] errors, double[] prevLayerOutputs, double learningRate)
        {
            var weightsDeltas = new double[errors.Length];

            var outputErrors = new double[Config.PrevLayerSize];

            for (int i = 0; i < _neurons.Length; i++)
            {
                weightsDeltas[i] = GetWeightsDelta(errors[i]);

                for(int j = 0; j < _neurons[i].Weights.Length; j++)
                {
                    _neurons[i].Weights[j] = _neurons[i].Weights[j] - prevLayerOutputs[j] * weightsDeltas[i] * learningRate;
                    outputErrors[j] += weightsDeltas[i] * _neurons[i].Weights[j];
                }
            }

            return outputErrors;

        }

        private double GetWeightsDelta(double error)
        {
            return error * Config.ActivationFunction.Derivate(error);
        }

    }
}
