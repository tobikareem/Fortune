namespace Flight.Model;

/// <summary>
/// An ConnectionRestriction object.
/// </summary>
public class ConnectionRestriction
{
    internal ConnectionRestriction() { }

    /// <summary>
    /// Gets or sets the type of the maxNumberOfConnections.
    /// </summary>
    /// <value>The type of the maxNumberOfConnections.</value>
    public int MaxNumberOfConnections { get; set; }

    /// <summary>
    /// Gets or sets the type of the airportChangeAllowed.
    /// </summary>
    /// <value>The type of the airportChangeAllowed.</value>
    public bool AirportChangeAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the technicalStopsAllowed.
    /// </summary>
    /// <value>The type of the technicalStopsAllowed.</value>
    public bool TechnicalStopsAllowed { get; set; }
}