namespace Flight.Model;

/// <summary>
/// An EmergencyContact object.
/// </summary>
public class EmergencyContact
{
    internal EmergencyContact() { }

    /// <summary>
    /// Gets or sets the type of the addresseeName.
    /// </summary>
    /// <value>The type of the addresseeName.</value>
    public string AddresseeName { get; set; }

    /// <summary>
    /// Gets or sets the type of the countryCode.
    /// </summary>
    /// <value>The type of the countryCode.</value>
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }
}