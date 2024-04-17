namespace Flight.Model;

/// <summary>
/// An Air object.
/// </summary>
public class Air
{
    internal Air() { }

    /// <summary>
    /// Gets or sets the type of the confirmationNumber.
    /// </summary>
    /// <value>The type of the confirmationNumber.</value>
    public string ConfirmationNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the baggages.
    /// </summary>
    /// <value>The type of the baggages.</value>
    public Baggage Baggages { get; set; }

    /// <summary>
    /// Gets or sets the type of the meal.
    /// </summary>
    /// <value>The type of the meal.</value>
    public Meal Meal { get; set; }

    /// <summary>
    /// Gets or sets the type of the departureAirportLocation.
    /// </summary>
    /// <value>The type of the departureAirportLocation.</value>
    public DepartureArrivalAirportLocation DepartureAirportLocation { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrivalAirportLocation.
    /// </summary>
    /// <value>The type of the arrivalAirportLocation.</value>
    public DepartureArrivalAirportLocation ArrivalAirportLocation { get; set; }

    /// <summary>
    /// Gets or sets the type of the departure.
    /// </summary>
    /// <value>The type of the departure.</value>
    public DepartureAir Departure { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrival.
    /// </summary>
    /// <value>The type of the arrival.</value>
    public ArrivalAir Arrival { get; set; }

    /// <summary>
    /// Gets or sets the type of the marketing.
    /// </summary>
    /// <value>The type of the marketing.</value>
    public MarketingOperating Marketing { get; set; }

    /// <summary>
    /// Gets or sets the type of the operating.
    /// </summary>
    /// <value>The type of the operating.</value>
    public MarketingOperating Operating { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraft.
    /// </summary>
    /// <value>The type of the aircraft.</value>
    public Aircraft Aircraft { get; set; }

    /// <summary>
    /// Gets or sets the type of the seats.
    /// </summary>
    /// <value>The type of the seats.</value>
    public Seat[] Seats { get; set; }
}