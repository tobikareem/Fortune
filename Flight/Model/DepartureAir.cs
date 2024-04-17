namespace Flight.Model;

/// <summary>
/// An DepartureAir object.
/// </summary>
public class DepartureAir
{
    internal DepartureAir() { }

    /// <summary>
    /// Gets or sets the type of the iataCode.
    /// </summary>
    /// <value>The type of the iataCode.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the terminal.
    /// </summary>
    /// <value>The type of the terminal.</value>
    public string Terminal { get; set; }

    /// <summary>
    /// Gets or sets the type of the checkInEndTime.
    /// </summary>
    /// <value>The type of the checkInEndTime.</value>
    public string CheckInEndTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the localDateTime.
    /// </summary>
    /// <value>The type of the localDateTime.</value>
    public string LocalDateTime { get; set; }
}