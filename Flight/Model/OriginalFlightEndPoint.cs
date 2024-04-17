namespace Flight.Model;

/// <summary>
/// An OriginalFlightEndPoint object.
/// </summary>
public class OriginalFlightEndPoint
{
    internal OriginalFlightEndPoint() { }

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

}