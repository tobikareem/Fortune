namespace Flight.Model;

/// <summary>
/// An FlightStop object.
/// </summary>
public class FlightStop
{
    internal FlightStop() { }

    /// <summary>
    /// Gets or sets the type of the iataCode.
    /// </summary>
    /// <value>The type of the iataCode.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public string Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrivalAt.
    /// </summary>
    /// <value>The type of the arrivalAt.</value>
    public string ArrivalAt { get; set; }

    /// <summary>
    /// Gets or sets the type of the departureAt.
    /// </summary>
    /// <value>The type of the departureAt.</value>
    public string DepartureAt { get; set; }
}