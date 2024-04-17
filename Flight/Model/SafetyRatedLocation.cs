namespace Flight.Model;

/// <summary>
/// An SafetyRatedLocation object.
/// </summary>
public class SafetyRatedLocation : Resource
{
    internal SafetyRatedLocation() { }

    /// <summary>
    /// Gets or sets the type of the safetyScore.
    /// </summary>
    /// <value>The type of the safetyScore.</value>
    public SafetyScore SafetyScore { get; set; }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the self.
    /// </summary>
    /// <value>The type of the self.</value>
    public Link Self { get; set; }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

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
    /// Gets or sets the type of the geoCode.
    /// </summary>
    /// <value>The type of the geoCode.</value>
    public GeoCode GeoCode { get; set; }
}