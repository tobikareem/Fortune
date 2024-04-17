namespace Flight.Model;

/// <summary>
/// An OriginDestinationLight object.
/// </summary>
public class OriginDestinationLight
{
    internal OriginDestinationLight() { }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the originLocationCode.
    /// </summary>
    /// <value>The type of the originLocationCode.</value>
    public string OriginLocationCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the destinationLocationCode.
    /// </summary>
    /// <value>The type of the destinationLocationCode.</value>
    public string DestinationLocationCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the includedConnectionPoints.
    /// </summary>
    /// <value>The type of the includedConnectionPoints.</value>
    public List<ConnectionPoints> IncludedConnectionPoints { get; set; }

    /// <summary>
    /// Gets or sets the type of the excludedConnectionPoints.
    /// </summary>
    /// <value>The type of the excludedConnectionPoints.</value>
    public List<ConnectionPoints> ExcludedConnectionPoints { get; set; }
}