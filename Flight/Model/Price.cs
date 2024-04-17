namespace Flight.Model;

/// <summary>
/// An Price object.
/// </summary>
public class Price
{
    internal Price() { }

    /// <summary>
    /// Gets or sets the margin.
    /// </summary>
    /// <value>The margin.</value>
    public string Margin { get; set; }

    /// <summary>
    /// Gets or sets the grandTotal.
    /// </summary>
    /// <value>The grandTotal.</value>
    public string GrandTotal { get; set; }

    /// <summary>
    /// Gets or sets the billingCurrency.
    /// </summary>
    /// <value>The billingCurrency.</value>
    public string BillingCurrency { get; set; }

    /// <summary>
    /// Gets or sets the additionalServices.
    /// </summary>
    /// <value>The additionalServices.</value>
    public List<AdditionalService> AdditionalServices { get; set; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    /// <value>The currency.</value>
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>The total.</value>
    public string Total { get; set; }

    /// <summary>
    /// Gets or sets the base.
    /// </summary>
    /// <value>The base.</value>
    public string Base { get; set; }

    /// <summary>
    /// Gets or sets the fees.
    /// </summary>
    /// <value>The fees.</value>
    public List<Fee> Fees { get; set; }

    /// <summary>
    /// Gets or sets the taxes.
    /// </summary>
    /// <value>The taxes.</value>
    public List<Tax> Taxes { get; set; }

    /// <summary>
    /// Gets or sets the refundableTaxes.
    /// </summary>
    /// <value>The refundableTaxes.</value>
    public string RefundableTaxes { get; set; }
}