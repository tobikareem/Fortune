namespace Flight.Model;

/// <summary>
/// An GetFlightAvailabilitiesQuery object.
/// </summary>
public class GetFlightAvailabilitiesQuery
{
    internal GetFlightAvailabilitiesQuery() { }

    /// <summary>
    /// Gets or sets the type of the originDestinations.
    /// </summary>
    /// <value>The type of the originDestinations.</value>
    public List<ExtendedOriginDestinationLight> OriginDestinations { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelers.
    /// </summary>
    /// <value>The type of the travelers.</value>
    public List<TravelerInfo> Travelers { get; set; }

    /// <summary>
    /// Gets or sets the type of the sources.
    /// </summary>
    /// <value>The type of the sources.</value>
    public List<Source> Sources { get; set; }

    /// <summary>
    /// Gets or sets the type of the searchCriteria.
    /// </summary>
    /// <value>The type of the searchCriteria.</value>
    public ExtendedSearchCriteria SearchCriteria { get; set; }
}