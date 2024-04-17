namespace Flight.Model;

/// <summary>
/// An GetFlightOffersQuery object.
/// </summary>
public class GetFlightOffersQuery
{
    public GetFlightOffersQuery() { }

    /// <summary>
    /// Gets or sets the type of the currencyCode.
    /// </summary>
    /// <value>The type of the currencyCode.</value>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the originDestinations.
    /// </summary>
    /// <value>The type of the originDestinations.</value>
    public List<OriginDestination> OriginDestinations { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelers.
    /// </summary>
    /// <value>The type of the travelers.</value>
    public List<TravelerInfo> Travelers { get; set; }

    /// <summary>
    /// Gets or sets the type of the sources.
    /// </summary>
    /// <value>The type of the sources.</value>
    public List<SourcesFlight> Sources { get; set; }

    /// <summary>
    /// Gets or sets the type of the searchCriteria.
    /// </summary>
    /// <value>The type of the searchCriteria.</value>
    public SearchCriteria SearchCriteria { get; set; }
}