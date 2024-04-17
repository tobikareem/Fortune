namespace Flight.Model;

/// <summary>
/// An CarVehicle object.
/// </summary>
public class FlightOfferPricingInput
{
    public FlightOfferPricingInput() { }

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
    /// Gets or sets the type of the payments.
    /// </summary>
    /// <value>The type of the payments.</value>
    public List<Payment> Payments { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelers.
    /// </summary>
    /// <value>The type of the travelers.</value>
    public List<TravelerElement> Travelers { get; set; }
}