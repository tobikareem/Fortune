namespace Flight.Model;

/// <summary>
/// An Departure object.
/// </summary>
public class DepartureArrival
{
    internal DepartureArrival() { }

    /// <summary>
    /// Gets or sets the type of the subType.
    /// </summary>
    /// <value>The type of the subType.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the iataCode.
    /// </summary>
    /// <value>The type of the iataCode.</value>
    public string IataCode { get; set; }
}