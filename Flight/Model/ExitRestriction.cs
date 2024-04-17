namespace Flight.Model;

/// <summary>
/// An ExitRestriction object.
/// </summary>
public class ExitRestriction
{
    internal ExitRestriction() { }

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
    /// Gets or sets the type of the specialRequirements.
    /// </summary>
    /// <value>The type of the specialRequirements.</value>
    public string SpecialRequirements { get; set; }

    /// <summary>
    /// Gets or sets the type of the rulesLink.
    /// </summary>
    /// <value>The type of the rulesLink.</value>
    public string RulesLink { get; set; }

    /// <summary>
    /// Gets or sets the type of the isBanned.
    /// </summary>
    /// <value>The type of the isBanned.</value>
    public string IsBanned { get; set; }
}