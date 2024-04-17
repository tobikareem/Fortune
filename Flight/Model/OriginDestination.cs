namespace Flight.Model;

/// <summary>
/// An OriginDestination object.
/// </summary>
public class OriginDestination
{
    public OriginDestination() { }

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
    /// Gets or sets the type of the originRadius.
    /// </summary>
    /// <value>The type of the originRadius.</value>
    public int OriginRadius { get; set; }

    /// <summary>
    /// Gets or sets the type of the alternativeOriginsCodes.
    /// </summary>
    /// <value>The type of the alternativeOriginsCodes.</value>
    public List<string> AlternativeOriginsCodes { get; set; }

    /// <summary>
    /// Gets or sets the type of the destinationLocationCode.
    /// </summary>
    /// <value>The type of the destinationLocationCode.</value>
    public string DestinationLocationCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the destinationRadius.
    /// </summary>
    /// <value>The type of the destinationRadius.</value>
    public int DestinationRadius { get; set; }

    /// <summary>
    /// Gets or sets the type of the alternativeDestinationsCodes.
    /// </summary>
    /// <value>The type of the alternativeDestinationsCodes.</value>
    public List<string> AlternativeDestinationsCodes { get; set; }

    /// <summary>
    /// Gets or sets the type of the departureDateTimeRange.
    /// </summary>
    /// <value>The type of the departureDateTimeRange.</value>
    public DateTimeRange DepartureDateTimeRange { get; set; }

    /// <summary>
    /// Gets or sets the type of the arrivalDateTimeRange.
    /// </summary>
    /// <value>The type of the arrivalDateTimeRange.</value>
    public DateTimeRange ArrivalDateTimeRange { get; set; }

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