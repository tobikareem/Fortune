namespace Flight.Model;

/// <summary>
/// An SearchCriteriaLight object.
/// </summary>
public class SearchCriteriaLight
{
    internal SearchCriteriaLight() { }

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
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public int Doors { get; set; }
}