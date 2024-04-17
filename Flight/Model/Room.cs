namespace Flight.Model;

/// <summary>
/// An Room object.
/// </summary>
public class Room
{
    internal Room() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the typeEstimated.
    /// </summary>
    /// <value>The typeEstimated.</value>
    public TypeEstimated TypeEstimated { get; set; }
}