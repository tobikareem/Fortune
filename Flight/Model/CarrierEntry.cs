namespace Flight.Model;

/// <summary>
/// An CarrierEntry object.
/// </summary>
public class CarrierEntry
{
    internal CarrierEntry() { }

    /// <summary>
    /// Gets or sets the type of the key.
    /// </summary>
    /// <value>The type of the key.</value>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the type of the carrierName.
    /// </summary>
    /// <value>The type of the carrierName.</value>
    public string CarrierName { get; set; }
}