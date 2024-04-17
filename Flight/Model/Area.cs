namespace Flight.Model;

/// <summary>
/// An Area object.
/// </summary>
public class Area
{
    internal Area() { }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the iataCode.
    /// </summary>
    /// <value>The type of the iataCode.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the iataCode.
    /// </summary>
    /// <value>The type of the iataCode.</value>
    public GeoCode GeoCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the areaType.
    /// </summary>
    /// <value>The type of the areaType.</value>
    public string AreaType { get; set; }
}