namespace TwentyQ.Core;

public class Neuron
{
    public double[] Weights { get; set; } = Array.Empty<double>();
    public double Bias;

    // Batch training: accumulated gradients (pending changes)
    private double[] _weightGradients = Array.Empty<double>();
    private double _biasGradient = 0;
    private int _accumulatedCount = 0;

    public Neuron(double[] weights, double bias)
    {
        this.Weights = weights;
        this.Bias = bias;
        this._weightGradients = new double[weights.Length];
    }

    /// <summary>
    /// Original training method - updates weights immediately (stochastic)
    /// </summary>
    public void Train(double[] inputs, double learningRate, double error)
    {
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] += learningRate * error * inputs[i];
        }
        Bias += learningRate * error;
    }

    /// <summary>
    /// Batch training step 1: Accumulate gradients WITHOUT applying them
    /// </summary>
    public void AccumulateGradients(double[] inputs, double error)
    {
        for (int i = 0; i < Weights.Length; i++)
        {
            _weightGradients[i] += error * inputs[i];
        }
        _biasGradient += error;
        _accumulatedCount++;
    }

    /// <summary>
    /// Batch training step 2: Apply averaged gradients and reset
    /// </summary>
    public void ApplyGradients(double learningRate)
    {
        if (_accumulatedCount == 0) return;

        for (int i = 0; i < Weights.Length; i++)
        {
            // Apply the AVERAGE gradient
            Weights[i] += learningRate * (_weightGradients[i] / _accumulatedCount);
            _weightGradients[i] = 0; // Reset for next batch
        }

        Bias += learningRate * (_biasGradient / _accumulatedCount);
        _biasGradient = 0;
        _accumulatedCount = 0;
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

