namespace Flight.Model;

/// <summary>
/// An CreditCard object.
/// </summary>
public class CreditCard
{
    internal CreditCard() { }

    /// <summary>
    /// Gets or sets the type of the brand.
    /// </summary>
    /// <value>The type of the brand.</value>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the type of the holder.
    /// </summary>
    /// <value>The type of the holder.</value>
    public string Holder { get; set; }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the expiryDate.
    /// </summary>
    /// <value>The type of the expiryDate.</value>
    public string ExpiryDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the securityCode.
    /// </summary>
    /// <value>The type of the securityCode.</value>
    public string SecurityCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the method.
    /// </summary>
    /// <value>The type of the method.</value>
    public string Method { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferIds.
    /// </summary>
    /// <value>The type of the flightOfferIds.</value>
    public List<string> FlightOfferIds { get; set; }
}