namespace Flight.Model;

/// <summary>
/// An TravelerPricing object.
/// </summary>
public class TravelerPricing
{
    internal TravelerPricing() { }

    /// <summary>
    /// Gets or sets the type of the travelerId.
    /// </summary>
    /// <value>The type of the travelerId.</value>
    public string TravelerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the fareOption.
    /// </summary>
    /// <value>The type of the fareOption.</value>
    public string FareOption { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerType.
    /// </summary>
    /// <value>The type of the travelerType.</value>
    public string TravelerType { get; set; }

    /// <summary>
    /// Gets or sets the type of the associatedAdultId.
    /// </summary>
    /// <value>The type of the associatedAdultId.</value>
    public string AssociatedAdultId { get; set; }

    /// <summary>
    /// Gets or sets the type of the price.
    /// </summary>
    /// <value>The type of the price.</value>
    public Price Price { get; set; }

    /// <summary>
    /// Gets or sets the type of the fareDetailsBySegment.
    /// </summary>
    /// <value>The type of the fareDetailsBySegment.</value>
    public List<FareDetailsBySegment> FareDetailsBySegment { get; set; }
}