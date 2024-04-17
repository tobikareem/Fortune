namespace Flight.Model;

/// <summary>
/// An TicketingAgreement object.
/// </summary>
public class TicketingAgreement
{
    internal TicketingAgreement() { }

    /// <summary>
    /// Gets or sets the type of the option.
    /// </summary>
    /// <value>The type of the option.</value>
    public string Option { get; set; }

    /// <summary>
    /// Gets or sets the type of the delay.
    /// </summary>
    /// <value>The type of the delay.</value>
    public string Delay { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateTime.
    /// </summary>
    /// <value>The type of the dateTime.</value>
    public string DateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateTime.
    /// </summary>
    /// <value>The type of the dateTime.</value>
    public List<string> SegmentIds { get; set; }
}