namespace Flight.Model;

/// <summary>
/// An Link object.
/// </summary>
public class Link
{
    internal Link() { }

    /// <summary>
    /// Gets or sets the type of the href.
    /// </summary>
    /// <value>The type of the href.</value>
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the type of the methods.
    /// </summary>
    /// <value>The type of the methods.</value>
    public List<string> Methods { get; set; }

    /// <summary>
    /// Gets or sets the type of the rel.
    /// </summary>
    /// <value>The type of the rel.</value>
    public string Rel { get; set; }
}