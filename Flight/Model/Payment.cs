namespace Flight.Model;

/// <summary>
/// An Payment object.
/// </summary>
public class Payment
{
    internal Payment() { }

    /// <summary>
    /// Gets or sets the type of the brand.
    /// </summary>
    /// <value>The type of the brand.</value>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the type of the binNumber.
    /// </summary>
    /// <value>The type of the binNumber.</value>
    public int BinNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferIds.
    /// </summary>
    /// <value>The type of the flightOfferIds.</value>
    public List<string> FlightOfferIds { get; set; }
}