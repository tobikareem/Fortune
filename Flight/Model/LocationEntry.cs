namespace Flight.Model;

/// <summary>
/// An LocationEntry object.
/// </summary>
public class LocationEntry
{
    internal LocationEntry() { }

    /// <summary>
    /// Gets or sets the type of the key.
    /// </summary>
    /// <value>The type of the key.</value>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public LocationValue LocationValue { get; set; }
}