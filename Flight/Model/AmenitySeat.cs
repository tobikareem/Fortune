namespace Flight.Model;

/// <summary>
/// An AmenitySeat object.
/// </summary>
public class AmenitySeat
{
    internal AmenitySeat() { }

    /// <summary>
    /// Gets or sets the type of the legSpace.
    /// </summary>
    /// <value>The type of the legSpace.</value>
    public int LegSpace { get; set; }

    /// <summary>
    /// Gets or sets the type of the spaceUnit.
    /// </summary>
    /// <value>The type of the spaceUnit.</value>
    public string SpaceUnit { get; set; }

    /// <summary>
    /// Gets or sets the type of the tilt.
    /// </summary>
    /// <value>The type of the tilt.</value>
    public string Tilt { get; set; }

    /// <summary>
    /// Gets or sets the type of the amenityType.
    /// </summary>
    /// <value>The type of the amenityType.</value>
    public string AmenityType { get; set; }

    /// <summary>
    /// Gets or sets the type of the medias.
    /// </summary>
    /// <value>The type of the medias.</value>
    public List<Media> Medias { get; set; }
}