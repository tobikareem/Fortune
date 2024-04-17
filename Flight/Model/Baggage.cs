namespace Flight.Model;

/// <summary>
/// An Baggage object.
/// </summary>
public class Baggage
{
    internal Baggage() { }

    /// <summary>
    /// Gets or sets the type of the quantity.
    /// </summary>
    /// <value>The type of the quantity.</value>
    public string Quantity { get; set; }

    /// <summary>
    /// Gets or sets the type of the weight.
    /// </summary>
    /// <value>The type of the weight.</value>
    public Weight Weight { get; set; }
}