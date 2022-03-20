using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurocomputing.Basics;

namespace Neurocomputing.Networks
{
    class LayerNetwork
    {
        private Layer[] _hiddenLayers;
        public double[] InputLayer { get; set; }
        public double[] Output { get; private set; }

        public double MSE { get; private set; }

        public LayerNetwork(LayerConfig[] layerConfigs)
        {
            _hiddenLayers = new Layer[layerConfigs.Length];
            FillLayersList(layerConfigs);
        }

        public void Compute()
        {
            _hiddenLayers[0].SetInputs(InputLayer);

            var output = _hiddenLayers[0].Compute();

            for (int i = 1; i < _hiddenLayers.Length; i++)
            {
                _hiddenLayers[i].SetInputs(output);
                output = _hiddenLayers[i].Compute();
            }

            Output = output;
        }

        public void RandomizeWeights()
        {
            var rnd = new Random();

            foreach(var layer in _hiddenLayers)
                layer.RandomizeWeights(rnd);
        }

        private void FillLayersList(LayerConfig[] layerConfigs)
        {
            for (int i = 0; i < layerConfigs.Length; i++)
            {
                _hiddenLayers[i] = new Layer(layerConfigs[i]);
            }
        }

        public void Train(int epochCount, double learningRate, TrainData trainData)
        {
            double[] MSEs = new double[trainData.Inputs.Length];
            RandomizeWeights();

            for (int i = 0; i < epochCount; i++)
            {
                double percentage = (double)i / epochCount * 100;

                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"Progress: {percentage:0.#}% Error = {MSE}");

                for(int j = 0; j < trainData.Inputs.Length; j++)
                {
                    var trainInput = trainData.Inputs[j];
                    var trainOutput = trainData.Outputs[j];
                    InputLayer = trainInput;
                    Compute();
                    MSEs[j] = GetOneTrainSetMSE(trainOutput, Output);

                    BackPropogation(trainOutput, learningRate);
                }


                MSE = GetEpochMSE(MSEs);
            }

            Console.WriteLine();
        }

        private void BackPropogation(double[] trainOutput, double learningRate)
        {
            var error = trainOutput.Select((trainOut, i) => Output[i] - trainOut).ToArray();

            for(int i = _hiddenLayers.Length - 1; i >= 0; i--)
            {
                double[] outputs = i == 0 ? InputLayer : _hiddenLayers[i - 1].Outputs;

                error = _hiddenLayers[i].ComputeError(error, outputs, learningRate);
            }


        }

        private double GetOneTrainSetMSE(double[] trainOutput, double[] actualOutput)
        {
            double mse = 0;

            for(int i = 0; i < trainOutput.Length; i++)
            {
                mse += Math.Pow(actualOutput[i] - trainOutput[i], 2);
            }

            return mse;
        }

        private double GetEpochMSE(double[] MSEs)
        {
            double mse = 0;

            for(int i = 0; i < MSEs.Length; i++)
            {
                mse += MSEs[i];
            }

            return mse /= MSEs.Length;
        }

    }
}
