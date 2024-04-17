namespace Flight.Model;

/// <summary>
/// An Dictionaries object.
/// </summary>
public class Dictionaries
{
    internal Dictionaries() { }

    /// <summary>
    /// Gets or sets the type of the locations.
    /// </summary>
    /// <value>The type of the locations.</value>
    public LocationEntry Locations { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraft.
    /// </summary>
    /// <value>The type of the aircraft.</value>
    public AircraftEntry Aircraft { get; set; }

    /// <summary>
    /// Gets or sets the type of the currencies.
    /// </summary>
    /// <value>The type of the currencies.</value>
    public CurrencyEntry Currencies { get; set; }

    /// <summary>
    /// Gets or sets the type of the currencies.
    /// </summary>
    /// <value>The type of the currencies.</value>
    public CarrierEntry Carriers { get; set; }
}