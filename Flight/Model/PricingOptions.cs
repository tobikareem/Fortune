namespace Flight.Model;

/// <summary>
/// An CarVePricingOptionshicle object.
/// </summary>
public class PricingOptions
{
    internal PricingOptions() { }

    /// <summary>
    /// Gets or sets the type of the includedCheckedBagsOnly.
    /// </summary>
    /// <value>The type of the includedCheckedBagsOnly.</value>
    public bool IncludedCheckedBagsOnly { get; set; }

    /// <summary>
    /// Gets or sets the type of the refundableFare.
    /// </summary>
    /// <value>The type of the refundableFare.</value>
    public bool RefundableFare { get; set; }

    /// <summary>
    /// Gets or sets the type of the noRestrictionFare.
    /// </summary>
    /// <value>The type of the noRestrictionFare.</value>
    public bool NoRestrictionFare { get; set; }

    /// <summary>
    /// Gets or sets the type of the noPenaltyFare.
    /// </summary>
    /// <value>The type of the noPenaltyFare.</value>
    public bool NoPenaltyFare { get; set; }
}