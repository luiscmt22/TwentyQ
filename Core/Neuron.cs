namespace TwentyQ.Core;

public class Neuron
{
    public double[] Weights { get; set; } = Array.Empty<double>();
    public double Bias;

    public Neuron(double[] weights, double bias)
    {
        this.Weights = weights;
        this.Bias = bias;
    }

    public void Train(double[] inputs, double expectedOutput, double learningRate)
    {
        var output = Compute(inputs);
        var error = expectedOutput - output;
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] += learningRate * error * inputs[i];
        }
        Bias += learningRate * error;
    }

    public double Compute(double[] inputs)
    {
        var output = 0.0;

        for (int i = 0; i < inputs.Length; i++)
        {
            output += inputs[i] * Weights[i];
        }
        
        return ActivationFunction(output + Bias);
    }

    private double ActivationFunction(double input)
    {
        return 1/(1 + Math.Exp(-input));
    }

}

