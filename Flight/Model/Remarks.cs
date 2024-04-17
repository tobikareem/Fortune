namespace Flight.Model;

/// <summary>
/// An Remarks object.
/// </summary>
public class Remarks
{
    internal Remarks() { }

    /// <summary>
    /// Gets or sets the type of the general.
    /// </summary>
    /// <value>The type of the general.</value>
    public List<GeneralRemark> General { get; set; }

    /// <summary>
    /// Gets or sets the type of the airline.
    /// </summary>
    /// <value>The type of the airline.</value>
    public List<AirlineRemark> Airline { get; set; }
}