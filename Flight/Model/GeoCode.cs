namespace Flight.Model;

/// <summary>
/// An GeoCode object.
/// </summary>
public class GeoCode
{
    internal GeoCode() { }

    /// <summary>
    /// Gets or sets the type of the latitude.
    /// </summary>
    /// <value>The type of the latitude.</value>
    public string Latitude { get; set; }

    /// <summary>
    /// Gets or sets the type of the longitude.
    /// </summary>
    /// <value>The type of the longitude.</value>
    public string Longitude { get; set; }

}