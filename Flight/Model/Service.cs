namespace Flight.Model;

/// <summary>
/// An Service object.
/// </summary>
public class Service
{
    internal Service() { }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the price.
    /// </summary>
    /// <value>The type of the price.</value>
    public ElementaryPrice Price { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookableByTraveler.
    /// </summary>
    /// <value>The type of the bookableByTraveler.</value>
    public bool BookableByTraveler { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookableByItinerary.
    /// </summary>
    /// <value>The type of the bookableByItinerary.</value>
    public bool BookableByItinerary { get; set; }

    /// <summary>
    /// Gets or sets the type of the segmentIds.
    /// </summary>
    /// <value>The type of the segmentIds.</value>
    public List<string> SegmentIds { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerIds.
    /// </summary>
    /// <value>The type of the travelerIds.</value>
    public List<string> TravelerIds { get; set; }
}