namespace Flight.Model;

/// <summary>
/// An CheckinLink object as returned by the CheckinLink API.
/// <see cref="CheckinLinks"/>
/// </summary>
public class CheckinLink : Resource
{

    internal CheckinLink() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the href.
    /// </summary>
    /// <value>The href.</value>
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the channel.
    /// </summary>
    /// <value>The channel.</value>
    public string Channel { get; set; }

}