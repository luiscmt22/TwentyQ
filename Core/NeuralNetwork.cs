using Microsoft.EntityFrameworkCore.Query.Internal;

namespace TwentyQ.Core;

public class NeuralNetwork
{
    public List<List<Neuron>> Layers { get; set; } = new List<List<Neuron>>();

    public NeuralNetwork(List<List<Neuron>> layers)
    {
        this.Layers = layers;
    }
    
    public double[] Compute(double[] inputs)
    {
        var outputs = new double[] { };
        foreach (var layer in Layers)
        {
            outputs = ComputeSingleLayer(inputs, layer);
            inputs = outputs;
        }
        return outputs;
    }

    public double[] ComputeSingleLayer(double[] inputs, List<Neuron> layer)
    {
        var outputs = new double[layer.Count];
        var i = 0;
        foreach (var neuron in layer)
        {
            outputs[i] = neuron.Compute(inputs);
            i++;
        }
        return outputs;
    }

    public void Train(double[] inputs, double[] expectedOutputs, double learningRate)
    {
        // ===== STEP 1: FORWARD PASS (save outputs for later) =====
        var hiddenLayer = Layers[0];
        var outputLayer = Layers[1];

        var hiddenOutputs = ComputeSingleLayer(inputs, hiddenLayer);
        var finalOutputs = ComputeSingleLayer(hiddenOutputs, outputLayer);

        // ===== STEP 2: CALCULATE OUTPUT LAYER ERRORS =====
        // error = (expected - actual) × sigmoid_derivative(output)
        // sigmoid_derivative(x) = x × (1 - x)
        var outputErrors = new double[outputLayer.Count];
        for (int i = 0; i < outputLayer.Count; i++)
        {
            var output = finalOutputs[i];
            var rawError = expectedOutputs[i] - output;
            outputErrors[i] = rawError * output * (1 - output);  // Scale by derivative
        }

        // ===== STEP 3: CALCULATE HIDDEN LAYER ERRORS (backpropagation!) =====
        var hiddenErrors = new double[hiddenLayer.Count];

        for (int h = 0; h < hiddenLayer.Count; h++)
        {
            // Sum of downstream errors weighted by connections
            double sum = 0.0;
            for (int o = 0; o < outputLayer.Count; o++)
            {
                sum += outputErrors[o] * outputLayer[o].Weights[h];
            }
            // Scale by this neuron's sigmoid derivative
            var hiddenOutput = hiddenOutputs[h];
            hiddenErrors[h] = sum * hiddenOutput * (1 - hiddenOutput);
        }

        // ===== STEP 4: UPDATE WEIGHTS =====
        // Train output layer (uses hiddenOutputs as inputs)
        for (int i = 0; i < outputLayer.Count; i++)
        {
            outputLayer[i].Train(hiddenOutputs, outputErrors[i], learningRate);
        }

        // Train hidden layer (uses original inputs)
        for (int i = 0; i < hiddenLayer.Count; i++)
        {
            hiddenLayer[i].Train(inputs, hiddenErrors[i], learningRate);
        }
    }
}

