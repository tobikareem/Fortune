namespace Flight.Model;

/// <summary>
/// An FlightFiltersLight object.
/// </summary>
public class FlightFiltersLight
{
    internal FlightFiltersLight() { }

    /// <summary>
    /// Gets or sets the type of the carrierRestrictions.
    /// </summary>
    /// <value>The type of the carrierRestrictions.</value>
    public CarrierRestrictions CarrierRestrictions { get; set; }

    /// <summary>
    /// Gets or sets the type of the cabinRestrictions.
    /// </summary>
    /// <value>The type of the cabinRestrictions.</value>
    public List<CabinRestriction> CabinRestrictions { get; set; }

    /// <summary>
    /// Gets or sets the type of the connectionRestriction.
    /// </summary>
    /// <value>The type of the connectionRestriction.</value>
    public ConnectionRestriction ConnectionRestriction { get; set; }
}