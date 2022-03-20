using Neurocomputing.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurocomputing.Basics
{
    internal class LayerConfig
    {
        public int Size { get; set; }
        public int PrevLayerSize { get; set; }
        public IActivationFunction ActivationFunction { get; set; }
    }
}
