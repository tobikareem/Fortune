namespace Flight.Model;

/// <summary>
/// An Itineraries object.
/// </summary>
public class Itineraries
{
    internal Itineraries() { }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public string Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the segments.
    /// </summary>
    /// <value>The type of the segments.</value>
    public List<Segment> Segments { get; set; }
}