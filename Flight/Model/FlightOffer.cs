namespace Flight.Model;

/// <summary>
/// An FlightOffer object as returned by the FlightOffers API.
/// <see cref="FlightOffers.get()"/>
/// </summary>
public class FlightOffer : Resource
{

    internal FlightOffer() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the source.
    /// </summary>
    /// <value>The source.</value>
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets the instantTicketingRequired.
    /// </summary>
    /// <value>The instantTicketingRequired.</value>
    public bool InstantTicketingRequired { get; set; }

    /// <summary>
    /// Gets or sets the disablePricing.
    /// </summary>
    /// <value>The disablePricing.</value>
    public bool DisablePricing { get; set; }

    /// <summary>
    /// Gets or sets the nonHomogeneous.
    /// </summary>
    /// <value>The nonHomogeneous.</value>
    public bool NonHomogeneous { get; set; }

    /// <summary>
    /// Gets or sets the oneWay.
    /// </summary>
    /// <value>The oneWay.</value>
    public bool OneWay { get; set; }

    /// <summary>
    /// Gets or sets the paymentCardRequired.
    /// </summary>
    /// <value>The paymentCardRequired.</value>
    public bool PaymentCardRequired { get; set; }

    /// <summary>
    /// Gets or sets the lastTicketingDate.
    /// </summary>
    /// <value>The lastTicketingDate.</value>
    public string LastTicketingDate { get; set; }

    /// <summary>
    /// Gets or sets the numberOfBookableSeats.
    /// </summary>
    /// <value>The numberOfBookableSeats.</value>
    public int NumberOfBookableSeats { get; set; }

    /// <summary>
    /// Gets or sets the itineraries.
    /// </summary>
    /// <value>The itineraries.</value>
    public List<Itineraries> Itineraries { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>The price.</value>
    public Price Price { get; set; }

    /// <summary>
    /// Gets or sets the pricingOptions.
    /// </summary>
    /// <value>The pricingOptions.</value>
    public PricingOptions PricingOptions { get; set; }

    /// <summary>
    /// Gets or sets the validatingAirlineCodes.
    /// </summary>
    /// <value>The validatingAirlineCodes.</value>
    public List<string> ValidatingAirlineCodes { get; set; }

    /// <summary>
    /// Gets or sets the travelerPricings.
    /// </summary>
    /// <value>The travelerPricings.</value>
    public List<TravelerPricing> TravelerPricings { get; set; }
}