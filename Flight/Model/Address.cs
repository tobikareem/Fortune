namespace Flight.Model;

/// <summary>
/// An Address object.
/// </summary>
public class Address
{
    internal Address() { }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>The category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the lines.
    /// </summary>
    /// <value>The lines.</value>
    public List<string> Lines { get; set; }

    /// <summary>
    /// Gets or sets the postalCode.
    /// </summary>
    /// <value>The postalCode.</value>
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the countryCode.
    /// </summary>
    /// <value>The countryCode.</value>
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the cityName.
    /// </summary>
    /// <value>The cityName.</value>
    public string CityName { get; set; }

    /// <summary>
    /// Gets or sets the stateCode.
    /// </summary>
    /// <value>The stateCode.</value>
    public string StateCode { get; set; }

    /// <summary>
    /// Gets or sets the postalBox.
    /// </summary>
    /// <value>The postalBox.</value>
    public string PostalBox { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>The state.</value>
    public string State { get; set; }

    /// <summary>
    /// Gets or sets the stateName.
    /// </summary>
    /// <value>The stateName.</value>
    public string StateName { get; set; }
}