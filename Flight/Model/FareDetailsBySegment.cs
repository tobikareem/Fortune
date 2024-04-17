namespace Flight.Model;

/// <summary>
/// An FareDetailsBySegment object.
/// </summary>
public class FareDetailsBySegment
{
    internal FareDetailsBySegment() { }

    /// <summary>
    /// Gets or sets the type of the segmentId.
    /// </summary>
    /// <value>The type of the segmentId.</value>
    public string SegmentId { get; set; }

    /// <summary>
    /// Gets or sets the type of the cabin.
    /// </summary>
    /// <value>The type of the cabin.</value>
    public string Cabin { get; set; }

    /// <summary>
    /// Gets or sets the type of the fareBasis.
    /// </summary>
    /// <value>The type of the fareBasis.</value>
    public string FareBasis { get; set; }

    /// <summary>
    /// Gets or sets the type of the brandedFare.
    /// </summary>
    /// <value>The type of the brandedFare.</value>
    public string BrandedFare { get; set; }

    /// <summary>
    /// Gets or sets the type of the class.
    /// </summary>
    /// <value>The type of the class.</value>
    public string Class { get; set; }

    /// <summary>
    /// Gets or sets the type of the isAllotment.
    /// </summary>
    /// <value>The type of the isAllotment.</value>
    public bool IsAllotment { get; set; }

    /// <summary>
    /// Gets or sets the type of the allotmentDetails.
    /// </summary>
    /// <value>The type of the allotmentDetails.</value>
    public AllotmentDetails AllotmentDetails { get; set; }

    /// <summary>
    /// Gets or sets the type of the sliceDiceIndicator.
    /// </summary>
    /// <value>The type of the sliceDiceIndicator.</value>
    public string SliceDiceIndicator { get; set; }

    /// <summary>
    /// Gets or sets the type of the includedCheckedBags.
    /// </summary>
    /// <value>The type of the includedCheckedBags.</value>
    public BaggageAllowance IncludedCheckedBags { get; set; }

    /// <summary>
    /// Gets or sets the type of the additionalServices.
    /// </summary>
    /// <value>The type of the additionalServices.</value>
    public AdditionalServicesRequest AdditionalServices { get; set; }
}