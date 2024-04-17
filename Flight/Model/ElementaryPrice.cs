namespace Flight.Model;

/// <summary>
/// An ElementaryPrice object.
/// </summary>
public class ElementaryPrice
{
    internal ElementaryPrice() { }

    /// <summary>
    /// Gets or sets the type of the amount.
    /// </summary>
    /// <value>The type of the amount.</value>
    public string Amount { get; set; }

    /// <summary>
    /// Gets or sets the type of the currencyCode.
    /// </summary>
    /// <value>The type of the currencyCode.</value>
    public string CurrencyCode { get; set; }

}