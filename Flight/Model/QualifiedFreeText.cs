namespace Flight.Model;

/// <summary>
/// An QualifiedFreeText object.
/// </summary>
public class QualifiedFreeText
{
    internal QualifiedFreeText() { }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the type of the lang.
    /// </summary>
    /// <value>The type of the lang.</value>
    public string Lang { get; set; }
}