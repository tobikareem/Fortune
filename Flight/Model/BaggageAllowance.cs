namespace Flight.Model;

/// <summary>
/// An BaggageAllowance object.
/// </summary>
public class BaggageAllowance
{
    internal BaggageAllowance() { }

    /// <summary>
    /// Gets or sets the type of the quantity.
    /// </summary>
    /// <value>The type of the quantity.</value>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the type of the weight.
    /// </summary>
    /// <value>The type of the weight.</value>
    public int Weight { get; set; }

    /// <summary>
    /// Gets or sets the type of the weightUnit.
    /// </summary>
    /// <value>The type of the weightUnit.</value>
    public string WeightUnit { get; set; }
}