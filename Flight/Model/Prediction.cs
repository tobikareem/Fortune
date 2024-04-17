namespace Flight.Model;

/// <summary>
/// An Period object as returned by the Prediction APIs.
/// </summary>
public class Prediction : Resource
{
    internal Prediction() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the sub.
    /// </summary>
    /// <value>The type of the sub.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the result.
    /// </summary>
    /// <value>The type of the result.</value>
    public string Result { get; set; }

    /// <summary>
    /// Gets or sets the type of the probability.
    /// </summary>
    /// <value>The type of the probability.</value>
    public string Probability { get; set; }
}