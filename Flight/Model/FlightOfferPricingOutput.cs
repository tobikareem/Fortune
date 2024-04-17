namespace Flight.Model;

/// <summary>
/// An FlightOfferPricingOutput object.
/// </summary>
public class FlightOfferPricingOutput : Resource
{
    internal FlightOfferPricingOutput() { } 

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOffers.
    /// </summary>
    /// <value>The type of the flightOffers.</value>
    public List<FlightOffer> FlightOffers { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookingRequirements.
    /// </summary>
    /// <value>The type of the bookingRequirements.</value>
    public BookingRequirements BookingRequirements { get; set; }
}