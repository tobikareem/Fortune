namespace Flight.Model;

/// <summary>
/// An ContactPhone object.
/// </summary>
public class ContactPhone
{
    internal ContactPhone() { }

    /// <summary>
    /// Gets or sets the type of the deviceType.
    /// </summary>
    /// <value>The type of the deviceType.</value>
    public string DeviceType { get; set; }

    /// <summary>
    /// Gets or sets the type of the countryCallingCode.
    /// </summary>
    /// <value>The type of the countryCallingCode.</value>
    public string CountryCallingCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }
}