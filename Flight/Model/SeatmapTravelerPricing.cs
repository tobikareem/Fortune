namespace Flight.Model;

/// <summary>
/// An SeatmapTravelerPricing object.
/// </summary>
public class SeatmapTravelerPricing
{
    internal SeatmapTravelerPricing() { }

    /// <summary>
    /// Gets or sets the type of the travelerId.
    /// </summary>
    /// <value>The type of the travelerId.</value>
    public string TravelerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the seatAvailabilityStatus.
    /// </summary>
    /// <value>The type of the seatAvailabilityStatus.</value>
    public string SeatAvailabilityStatus { get; set; }

    /// <summary>
    /// Gets or sets the type of the price.
    /// </summary>
    /// <value>The type of the price.</value>
    public Price Price { get; set; }
}