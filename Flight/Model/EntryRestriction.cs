namespace Flight.Model;

/// <summary>
/// An EntryRestriction object.
/// </summary>
public class EntryRestriction
{
    internal EntryRestriction() { }

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
    /// Gets or sets the type of the ban.
    /// </summary>
    /// <value>The type of the ban.</value>
    public string Ban { get; set; }

    /// <summary>
    /// Gets or sets the type of the throughDate.
    /// </summary>
    /// <value>The type of the throughDate.</value>
    public string ThroughDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the rules.
    /// </summary>
    /// <value>The type of the rules.</value>
    public string Rules { get; set; }

    /// <summary>
    /// Gets or sets the type of the exemptions.
    /// </summary>
    /// <value>The type of the exemptions.</value>
    public string Exemptions { get; set; }

    /// <summary>
    /// Gets or sets the type of the bannedArea.
    /// </summary>
    /// <value>The type of the bannedArea.</value>
    public List<Area> BannedArea { get; set; }

    /// <summary>
    /// Gets or sets the type of the borderBan.
    /// </summary>
    /// <value>The type of the borderBan.</value>
    public List<Border> BorderBan { get; set; }
}