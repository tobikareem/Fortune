namespace Flight.Model;

/// <summary>
/// An AvailableSeatsCounter object.
/// </summary>
public class AvailableSeatsCounter
{
    internal AvailableSeatsCounter() { }

    /// <summary>
    /// Gets or sets the type of the travelerId.
    /// </summary>
    /// <value>The type of the travelerId.</value>
    public string TravelerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the value.
    /// </summary>
    /// <value>The type of the value.</value>
    public int Value { get; set; }
}