namespace Flight.Model;

/// <summary>
/// An Meta object.
/// </summary>
public class Meta
{
    internal Meta() { }

    /// <summary>
    /// Gets or sets the type of the links.
    /// </summary>
    /// <value>The type of the links.</value>
    public Link Links { get; set; }

    /// <summary>
    /// Gets or sets the type of the lang.
    /// </summary>
    /// <value>The type of the lang.</value>
    public string Lang { get; set; }
}