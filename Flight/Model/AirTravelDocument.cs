namespace Flight.Model;

/// <summary>
/// An AirTravelDocument object.
/// </summary>
public class AirTravelDocument
{
    internal AirTravelDocument() { }

    /// <summary>
    /// Gets or sets the type of the documentType.
    /// </summary>
    /// <value>The type of the documentType.</value>
    public string DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentNumber.
    /// </summary>
    /// <value>The type of the documentNumber.</value>
    public string DocumentNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentStatus.
    /// </summary>
    /// <value>The type of the documentStatus.</value>
    public string DocumentStatus { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerId.
    /// </summary>
    /// <value>The type of the travelerId.</value>
    public string TravelerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the segmentIds.
    /// </summary>
    /// <value>The type of the segmentIds.</value>
    public List<string> SegmentIds { get; set; }
}