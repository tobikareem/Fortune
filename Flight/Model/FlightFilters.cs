namespace Flight.Model;

/// <summary>
/// An FlightFilters object.
/// </summary>
public class FlightFilters
{
    public FlightFilters() { }

    /// <summary>
    /// Gets or sets the type of the crossBorderAllowed.
    /// </summary>
    /// <value>The type of the crossBorderAllowed.</value>
    public bool CrossBorderAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the moreOvernightsAllowed.
    /// </summary>
    /// <value>The type of the moreOvernightsAllowed.</value>
    public bool MoreOvernightsAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the returnToDepartureAirport.
    /// </summary>
    /// <value>The type of the returnToDepartureAirport.</value>
    public bool ReturnToDepartureAirport { get; set; }

    /// <summary>
    /// Gets or sets the type of the railSegmentAllowed.
    /// </summary>
    /// <value>The type of the railSegmentAllowed.</value>
    public bool RailSegmentAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the busSegmentAllowed.
    /// </summary>
    /// <value>The type of the busSegmentAllowed.</value>
    public bool BusSegmentAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the maxFlightTime.
    /// </summary>
    /// <value>The type of the maxFlightTime.</value>
    public int MaxFlightTime { get; set; }

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