namespace Flight.Model;

/// <summary>
/// An CreditCardCommon object.
/// </summary>
public class CreditCardCommon
{
    internal CreditCardCommon() { }

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