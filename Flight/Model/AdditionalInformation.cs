namespace Flight.Model;

/// <summary>
/// An AdditionalInformation object.
/// </summary>
public class AdditionalInformation
{
    internal AdditionalInformation() { }

    /// <summary>
    /// Gets or sets the type of the chargeableCheckedBags.
    /// </summary>
    /// <value>The type of the chargeableCheckedBags.</value>
    public bool ChargeableCheckedBags { get; set; }

    /// <summary>
    /// Gets or sets the type of the brandedFares.
    /// </summary>
    /// <value>The type of the brandedFares.</value>
    public bool BrandedFares { get; set; }

}