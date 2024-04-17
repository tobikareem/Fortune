namespace Flight.Model;

/// <summary>
/// An AreaRestriction object.
/// </summary>
public class AreaRestriction
{
    internal AreaRestriction() { }

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
    /// Gets or sets the type of the restrictionType.
    /// </summary>
    /// <value>The type of the restrictionType.</value>
    public string RestrictionType { get; set; }

    /// <summary>
    /// Gets or sets the type of the title.
    /// </summary>
    /// <value>The type of the title.</value>
    public string Title { get; set; }
}