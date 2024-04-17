namespace Flight.Model;

/// <summary>
/// An FlightSegment object.
/// </summary>
public class FlightSegment
{
    internal FlightSegment() { }

    /// <summary>
    /// Gets or sets the type of the departure.
    /// </summary>
    /// <value>The type of the departure.</value>
    public FlightEndPoint Departure { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrival.
    /// </summary>
    /// <value>The type of the arrival.</value>
    public FlightEndPoint Arrival { get; set; }

    /// <summary>
    /// Gets or sets the type of the carrierCode.
    /// </summary>
    /// <value>The type of the carrierCode.</value>
    public string CarrierCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraft.
    /// </summary>
    /// <value>The type of the aircraft.</value>
    public AircraftEquipment Aircraft { get; set; }

    /// <summary>
    /// Gets or sets the type of the operating.
    /// </summary>
    /// <value>The type of the operating.</value>
    public OperatingFlight Operating { get; set; }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public string Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the stops.
    /// </summary>
    /// <value>The type of the stops.</value>
    public FlightStop Stops { get; set; }
}