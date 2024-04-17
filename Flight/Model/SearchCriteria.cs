namespace Flight.Model;

/// <summary>
/// An SearchCriteria object.
/// </summary>
public class SearchCriteria
{
    public SearchCriteria() { }

    /// <summary>
    /// Gets or sets the type of the excludeAllotments.
    /// </summary>
    /// <value>The type of the excludeAllotments.</value>
    public bool ExcludeAllotments { get; set; }

    /// <summary>
    /// Gets or sets the type of the addOneWayOffers.
    /// </summary>
    /// <value>The type of the addOneWayOffers.</value>
    public bool AddOneWayOffers { get; set; }

    /// <summary>
    /// Gets or sets the type of the maxFlightOffers.
    /// </summary>
    /// <value>The type of the maxFlightOffers.</value>
    public int MaxFlightOffers { get; set; }

    /// <summary>
    /// Gets or sets the type of the maxPrice.
    /// </summary>
    /// <value>The type of the maxPrice.</value>
    public int MaxPrice { get; set; }

    /// <summary>
    /// Gets or sets the type of the allowAlternativeFareOptions.
    /// </summary>
    /// <value>The type of the allowAlternativeFareOptions.</value>
    public bool AllowAlternativeFareOptions { get; set; }

    /// <summary>
    /// Gets or sets the type of the oneFlightOfferPerDay.
    /// </summary>
    /// <value>The type of the oneFlightOfferPerDay.</value>
    public bool OneFlightOfferPerDay { get; set; }

    /// <summary>
    /// Gets or sets the type of the additionalInformation.
    /// </summary>
    /// <value>The type of the additionalInformation.</value>
    public AdditionalInformation AdditionalInformation { get; set; }

    /// <summary>
    /// Gets or sets the type of the pricingOptions.
    /// </summary>
    /// <value>The type of the pricingOptions.</value>
    public PricingOptions PricingOptions { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightFilters.
    /// </summary>
    /// <value>The type of the flightFilters.</value>
    public FlightFilters FlightFilters { get; set; }


}