namespace Flight.Model;

/// <summary>
/// An Media object.
/// </summary>
public class Media
{
    internal Media() { }

    /// <summary>
    /// Gets or sets the type of the title.
    /// </summary>
    /// <value>The type of the title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the type of the href.
    /// </summary>
    /// <value>The type of the href.</value>
    public string Href { get; set; }

    /// <summary>
    /// Gets or sets the type of the description.
    /// </summary>
    /// <value>The type of the description.</value>
    public QualifiedFreeText Description { get; set; }

    /// <summary>
    /// Gets or sets the type of the mediaType.
    /// </summary>
    /// <value>The type of the mediaType.</value>
    public string MediaType { get; set; }
}