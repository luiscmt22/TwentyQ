namespace TwentyQ.Core;

public class NeuralNetwork
{
    public List<Neuron> Neurons { get; set; } = new List<Neuron>();

    public NeuralNetwork(List<Neuron> neurons)
    {
        this.Neurons = neurons;
    }

    public double[] Compute(double[] inputs)
    {
        var outputs = new double[Neurons.Count];
        var i = 0;
        foreach (var neuron in Neurons)
        {
            outputs[i] = neuron.Compute(inputs);
            i++;
        }
        return outputs;
    }

    public void Train(double[] inputs, double[] expectedOutputs, double learningRate)
    {
        var i = 0;
        foreach (var neuron in Neurons)
        {
            neuron.Train(inputs, expectedOutputs[i], learningRate);
            i++;
        }
    }
}

