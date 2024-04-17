namespace Flight.Model;

/// <summary>
/// An CarrierRestrictions object.
/// </summary>
public class CarrierRestrictions
{
    public CarrierRestrictions() { }

    /// <summary>
    /// Gets or sets the type of the blacklistedInEUAllowed.
    /// </summary>
    /// <value>The type of the blacklistedInEUAllowed.</value>
    public bool BlacklistedInEuAllowed { get; set; }

    /// <summary>
    /// Gets or sets the type of the excludedCarrierCodes.
    /// </summary>
    /// <value>The type of the excludedCarrierCodes.</value>
    public List<string> ExcludedCarrierCodes { get; set; }

    /// <summary>
    /// Gets or sets the type of the includedCarrierCodes.
    /// </summary>
    /// <value>The type of the includedCarrierCodes.</value>
    public List<string> IncludedCarrierCodes { get; set; }
}