namespace Flight.Model;

/// <summary>
/// An LocationValue object.
/// </summary>
public class LocationValue
{
    internal LocationValue() { }

    /// <summary>
    /// Gets or sets the type of the cityCode.
    /// </summary>
    /// <value>The type of the cityCode.</value>
    public string CityCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the countryCode.
    /// </summary>
    /// <value>The type of the countryCode.</value>
    public string CountryCode { get; set; }
}