namespace Flight.Model;

/// <summary>
/// An FareRules object.
/// </summary>
public class FareRules
{
    internal FareRules() { }

    /// <summary>
    /// Gets or sets the type of the currency.
    /// </summary>
    /// <value>The type of the currency.</value>
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the type of the rules.
    /// </summary>
    /// <value>The type of the rules.</value>
    public List<TermAndCondition> Rules { get; set; }
}