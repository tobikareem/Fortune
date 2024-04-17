namespace Flight.Model;

/// <summary>
/// An ContactAddress object.
/// </summary>
public class ContactAddress
{
    internal ContactAddress() { }

    /// <summary>
    /// Gets or sets the type of the lines.
    /// </summary>
    /// <value>The type of the lines.</value>
    public List<string> Lines { get; set; }

    /// <summary>
    /// Gets or sets the type of the postalCode.
    /// </summary>
    /// <value>The type of the postalCode.</value>
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the countryCode.
    /// </summary>
    /// <value>The type of the countryCode.</value>
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the cityName.
    /// </summary>
    /// <value>The type of the cityName.</value>
    public string CityName { get; set; }

    /// <summary>
    /// Gets or sets the type of the stateName.
    /// </summary>
    /// <value>The type of the stateName.</value>
    public string StateName { get; set; }

    /// <summary>
    /// Gets or sets the type of the postalBox.
    /// </summary>
    /// <value>The type of the postalBox.</value>
    public string PostalBox { get; set; }
}