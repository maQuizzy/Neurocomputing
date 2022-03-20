using System;
using Neurocomputing.Networks;
using Neurocomputing.Basics;
using Neurocomputing.Functions;

namespace Neurocomputing
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] inputs =
            {
                new double [] { 0.0d, 0.0d, 0.0d },
                new double [] { 0.0d, 1.0d, 0.0d },
                new double [] { 1.0d, 0.0d, 1.0d },
                new double [] { 1.0d, 1.0d, 1.0d },
                new double [] { 0.0d, 0.0d, 1.0d },
            };

            double[][] outputs =
            {
                new double[] { 0.5d },
                new double[] { 1.0d },
                new double[] { 0.0d },
                new double[] { 0.3d },
                new double[] { 0.7d }
            };

            var activationFunction = new Sigmoid();

            var network = new LayerNetwork(new LayerConfig[]
            {
                new LayerConfig
                {
                    ActivationFunction = activationFunction,
                    Size = 2,
                    PrevLayerSize = 3
                },
                new LayerConfig
                {
                    ActivationFunction = activationFunction,
                    Size = 1,
                    PrevLayerSize = 2
                }
            });

            network.Train(5000, 0.1, new TrainData
            {
                Inputs = inputs,
                Outputs = outputs

            });

            Console.WriteLine("Testing:");
            for (int i = 0; i < inputs.Length; i++)
            {
                network.InputLayer = inputs[i];
                network.Compute();
                Console.WriteLine($"Output: {network.Output[0]} \t Expected: {outputs[i][0]}");
            }

            Console.ReadLine();
        }
    }
}
