namespace Flight.Model;

/// <summary>
/// An B2bWallet object.
/// </summary>
public class B2BWallet
{
    internal B2BWallet() { }

    /// <summary>
    /// Gets or sets the type of the cardId.
    /// </summary>
    /// <value>The type of the cardId.</value>
    public string CardId { get; set; }

    /// <summary>
    /// Gets or sets the type of the cardUsageName.
    /// </summary>
    /// <value>The type of the cardUsageName.</value>
    public string CardUsageName { get; set; }

    /// <summary>
    /// Gets or sets the type of the cardFriendlyName.
    /// </summary>
    /// <value>The type of the cardFriendlyName.</value>
    public string CardFriendlyName { get; set; }

    /// <summary>
    /// Gets or sets the type of the reportingData.
    /// </summary>
    /// <value>The type of the reportingData.</value>
    public List<ReportingData> ReportingData { get; set; }

    /// <summary>
    /// Gets or sets the type of the virtualCreditCardDetails.
    /// </summary>
    /// <value>The type of the virtualCreditCardDetails.</value>
    public CreditCardCommon VirtualCreditCardDetails { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferIds.
    /// </summary>
    /// <value>The type of the flightOfferIds.</value>
    public List<string> FlightOfferIds { get; set; }
}