namespace Flight.Model;

/// <summary>
/// An SeatMap object.
/// </summary>
public class SeatMap : Resource
{
    internal SeatMap() { }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the self.
    /// </summary>
    /// <value>The type of the self.</value>
    public Link Self { get; set; }

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
    /// Gets or sets the type of the operating.
    /// </summary>
    /// <value>The type of the operating.</value>
    public OperatingFlight Operating { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraft.
    /// </summary>
    /// <value>The type of the aircraft.</value>
    public AircraftEquipment Aircraft { get; set; }

    /// <summary>
    /// Gets or sets the type of the class.
    /// </summary>
    /// <value>The type of the class.</value>
    public string SeatMapClass { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferId.
    /// </summary>
    /// <value>The type of the flightOfferId.</value>
    public string FlightOfferId { get; set; }

    /// <summary>
    /// Gets or sets the type of the segmentId.
    /// </summary>
    /// <value>The type of the segmentId.</value>
    public string SegmentId { get; set; }

    /// <summary>
    /// Gets or sets the type of the decks.
    /// </summary>
    /// <value>The type of the decks.</value>
    public List<Deck> Decks { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraftCabinAmenities.
    /// </summary>
    /// <value>The type of the aircraftCabinAmenities.</value>
    public AircraftCabinAmenities AircraftCabinAmenities { get; set; }

    /// <summary>
    /// Gets or sets the type of the availableSeatsCounters.
    /// </summary>
    /// <value>The type of the availableSeatsCounters.</value>
    public List<AvailableSeatsCounter> AvailableSeatsCounters { get; set; }
}