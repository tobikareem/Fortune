namespace Flight.Model;

/// <summary>
/// An DatedQuarantineRestriction object.
/// </summary>
public class DatedQuarantineRestriction
{
    internal DatedQuarantineRestriction() { }

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
    /// Gets or sets the type of the eligiblePerson.
    /// </summary>
    /// <value>The type of the eligiblePerson.</value>
    public string EligiblePerson { get; set; }

    /// <summary>
    /// Gets or sets the type of the quarantineType.
    /// </summary>
    /// <value>The type of the quarantineType.</value>
    public string QuarantineType { get; set; }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public int Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the rules.
    /// </summary>
    /// <value>The type of the rules.</value>
    public string Rules { get; set; }

    /// <summary>
    /// Gets or sets the type of the mandateList.
    /// </summary>
    /// <value>The type of the mandateList.</value>
    public string MandateList { get; set; }

    /// <summary>
    /// Gets or sets the type of the quarantineOnArrivalAreas.
    /// </summary>
    /// <value>The type of the quarantineOnArrivalAreas.</value>
    public List<Area> QuarantineOnArrivalAreas { get; set; }
}