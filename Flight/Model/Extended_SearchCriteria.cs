namespace Flight.Model;

/// <summary>
/// An Extended_SearchCriteria object.
/// </summary>
public class ExtendedSearchCriteria
{
    internal ExtendedSearchCriteria() { }

    /// <summary>
    /// Gets or sets the type of the excludeAllotments.
    /// </summary>
    /// <value>The type of the excludeAllotments.</value>
    public bool ExcludeAllotments { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightFilters.
    /// </summary>
    /// <value>The type of the flightFilters.</value>
    public FlightFiltersLight FlightFilters { get; set; }

    /// <summary>
    /// Gets or sets the type of the includeClosedContent.
    /// </summary>
    /// <value>The type of the includeClosedContent.</value>
    public string IncludeClosedContent { get; set; }

    /// <summary>
    /// Gets or sets the type of the class.
    /// </summary>
    /// <value>The type of the class.</value>
    public string BookedClass { get; set; }
}