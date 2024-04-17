namespace Flight.Model;

/// <summary>
/// An DetailedFareRules object.
/// </summary>
public class DetailedFareRules
{
    internal DetailedFareRules() { }

    /// <summary>
    /// Gets or sets the type of the fareBasis.
    /// </summary>
    /// <value>The type of the fareBasis.</value>
    public string FareBasis { get; set; }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the fareNotes.
    /// </summary>
    /// <value>The type of the fareNotes.</value>
    public TermAndCondition FareNotes { get; set; }

    /// <summary>
    /// Gets or sets the type of the segmentId.
    /// </summary>
    /// <value>The type of the segmentId.</value>
    public int SegmentId { get; set; }
}