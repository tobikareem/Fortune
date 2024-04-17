namespace Flight.Model;

/// <summary>
/// An Train object.
/// </summary>
public class Train
{
    internal Train() { }

    /// <summary>
    /// Gets or sets the type of the confirmNbr.
    /// </summary>
    /// <value>The type of the confirmNbr.</value>
    public string ConfirmNbr { get; set; }

    /// <summary>
    /// Gets or sets the type of the serviceProviderName.
    /// </summary>
    /// <value>The type of the serviceProviderName.</value>
    public string ServiceProviderName { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookingClass.
    /// </summary>
    /// <value>The type of the bookingClass.</value>
    public string BookingClass { get; set; }

    /// <summary>
    /// Gets or sets the type of the departure.
    /// </summary>
    /// <value>The type of the departure.</value>
    public DepartureArrival Departure { get; set; }

    /// <summary>
    /// Gets or sets the type of the departureDateTime.
    /// </summary>
    /// <value>The type of the departureDateTime.</value>
    public string DepartureDateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrivalDateTime.
    /// </summary>
    /// <value>The type of the arrivalDateTime.</value>
    public string ArrivalDateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrival.
    /// </summary>
    /// <value>The type of the arrival.</value>
    public DepartureArrival Arrival { get; set; }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public string Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrivalTrack.
    /// </summary>
    /// <value>The type of the arrivalTrack.</value>
    public string ArrivalTrack { get; set; }

    /// <summary>
    /// Gets or sets the type of the seats.
    /// </summary>
    /// <value>The type of the seats.</value>
    public Seat[] Seats { get; set; }

    /// <summary>
    /// Gets or sets the type of the vehicle.
    /// </summary>
    /// <value>The type of the vehicle.</value>
    public Vehicle Vehicle { get; set; }
}