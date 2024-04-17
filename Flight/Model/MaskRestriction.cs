namespace Flight.Model;

/// <summary>
/// An MaskRestriction object.
/// </summary>
public class MaskRestriction
{
    internal MaskRestriction() { }

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
}