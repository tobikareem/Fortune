namespace Flight.Model;

/// <summary>
/// An TravelAgency object.
/// </summary>
public class TravelAgency
{
    internal TravelAgency() { }

    /// <summary>
    /// Gets or sets the officeName.
    /// </summary>
    /// <value>The officeName.</value>
    public string OfficeName { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    /// <value>The phone.</value>
    public Phone Phone { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public Email Email { get; set; }
}