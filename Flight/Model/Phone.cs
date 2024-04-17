namespace Flight.Model;

/// <summary>
/// An Phone object.
/// </summary>
public class Phone
{
    internal Phone() { }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>The category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the countryCode.
    /// </summary>
    /// <value>The countryCode.</value>
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the number.
    /// </summary>
    /// <value>The number.</value>
    public string Number { get; set; }
}