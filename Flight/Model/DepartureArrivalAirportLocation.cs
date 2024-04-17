namespace Flight.Model;

/// <summary>
/// An DepartureArrivalAirportLocation object.
/// </summary>
public class DepartureArrivalAirportLocation
{
    internal DepartureArrivalAirportLocation() { }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the address.
    /// </summary>
    /// <value>The type of the address.</value>
    public Address Address { get; set; }
}