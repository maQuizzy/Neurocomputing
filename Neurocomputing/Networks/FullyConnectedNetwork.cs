using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurocomputing.Networks
{
    //class FullyConnectedNetwork
    //{
    //    private Neuron[] _neurons;

    //    public FullyConnectedNetwork(int size, Func<double,double>[] activatorFuncs)
    //    {
    //        FillNeuronsList(size, activatorFuncs);
    //    }

    //    public void SetInputs(double[] inputs)
    //    {
    //        foreach (var neuron in _neurons)
    //        {
    //            neuron.Inputs = inputs;
    //        }
    //    }

    //    public double[] Compute()
    //    {
    //        double[] outputs = new double[_neurons.Length];

    //        for (int i = 0; i < _neurons.Length; i++)
    //        {
    //            _neurons[i].Activate();
    //            outputs[i] = _neurons[i].Output;
    //        }

    //        UpdateNeuronsInputs(outputs);

    //        return outputs;
    //    }

    //    private void FillNeuronsList(int size, Func<double, double>[] activatorFuncs)
    //    {
    //        _neurons = new Neuron[size];

    //        for (int i = 0; i < _neurons.Length; i++)
    //        {
    //            _neurons[i] = new Neuron(activatorFuncs[i]);
    //        }

    //    }

    //    private void UpdateNeuronsInputs(double[] inputs)
    //    {
    //        foreach(var neutron in _neurons)
    //        {
    //            neutron.Inputs = inputs;
    //        }
    //    }

    //}
}
