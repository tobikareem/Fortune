namespace Flight.Model;

/// <summary>
/// An Tax object.
/// </summary>
public class Tax
{
    internal Tax() { }

    /// <summary>
    /// Gets or sets the type of the amount.
    /// </summary>
    /// <value>The type of the amount.</value>
    public string Amount { get; set; }

    /// <summary>
    /// Gets or sets the type of the code.
    /// </summary>
    /// <value>The type of the code.</value>
    public string Code { get; set; }

}