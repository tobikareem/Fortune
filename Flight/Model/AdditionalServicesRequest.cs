namespace Flight.Model;

/// <summary>
/// An AdditionalServicesRequest object.
/// </summary>
public class AdditionalServicesRequest
{
    internal AdditionalServicesRequest() { }

    /// <summary>
    /// Gets or sets the type of the chargeableCheckedBags.
    /// </summary>
    /// <value>The type of the chargeableCheckedBags.</value>
    public BaggageAllowance ChargeableCheckedBags { get; set; }

    /// <summary>
    /// Gets or sets the type of the chargeableSeatNumber.
    /// </summary>
    /// <value>The type of the chargeableSeatNumber.</value>
    public string ChargeableSeatNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the otherServices.
    /// </summary>
    /// <value>The type of the otherServices.</value>
    public List<string> OtherServices { get; set; }
}