namespace Flight.Model;

/// <summary>
/// An CabinRestriction object.
/// </summary>
public class CabinRestriction
{
    public CabinRestriction() { }

    /// <summary>
    /// Gets or sets the type of the cabin.
    /// </summary>
    /// <value>The type of the cabin.</value>
    public string Cabin { get; set; }

    /// <summary>
    /// Gets or sets the type of the coverage.
    /// </summary>
    /// <value>The type of the coverage.</value>
    public string Coverage { get; set; }

    /// <summary>
    /// Gets or sets the type of the originDestinationIds.
    /// </summary>
    /// <value>The type of the originDestinationIds.</value>
    public List<string> OriginDestinationIds { get; set; }

}