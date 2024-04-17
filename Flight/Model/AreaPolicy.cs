namespace Flight.Model;

/// <summary>
/// An AreaPolicy object.
/// </summary>
public class AreaPolicy
{
    internal AreaPolicy() { }

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
    /// Gets or sets the type of the status.
    /// </summary>
    /// <value>The type of the status.</value>
    public string Status { get; set; }


    /// <summary>
    /// Gets or sets the type of the startDate.
    /// </summary>
    /// <value>The type of the startDate.</value>
    public string StartDate { get; set; }


    /// <summary>
    /// Gets or sets the type of the endDate.
    /// </summary>
    /// <value>The type of the endDate.</value>
    public string EndDate { get; set; }


    /// <summary>
    /// Gets or sets the type of the referenceLink.
    /// </summary>
    /// <value>The type of the referenceLink.</value>
    public string ReferenceLink { get; set; }

}