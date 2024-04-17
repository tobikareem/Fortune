namespace Flight.Model;

/// <summary>
/// An StartEnd object.
/// </summary>
public class StartEnd
{
    internal StartEnd() { }

    /// <summary>
    /// Gets or sets the localDateTime.
    /// </summary>
    /// <value>The localDateTime.</value>
    public string LocalDateTime { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the iataCode.
    /// </summary>
    /// <value>The iataCode.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public Address Address { get; set; }
}