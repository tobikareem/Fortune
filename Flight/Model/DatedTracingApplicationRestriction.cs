namespace Flight.Model;

/// <summary>
/// An DatedTracingApplicationRestriction object.
/// </summary>
public class DatedTracingApplicationRestriction
{
    internal DatedTracingApplicationRestriction() { }

    /// <summary>
    /// Gets or sets the type of the date.
    /// </summary>
    /// <value>The type of the date.</value>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the type of the isRequired.
    /// </summary>
    /// <value>The type of the isRequired.</value>
    public string IsRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the iosUrl.
    /// </summary>
    /// <value>The type of the iosUrl.</value>
    public List<string> IosUrl { get; set; }

    /// <summary>
    /// Gets or sets the type of the androidUrl.
    /// </summary>
    /// <value>The type of the androidUrl.</value>
    public List<string> AndroidUrl { get; set; }

    /// <summary>
    /// Gets or sets the type of the website.
    /// </summary>
    /// <value>The type of the website.</value>
    public string Website { get; set; }
}