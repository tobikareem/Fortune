namespace Flight.Model;

/// <summary>
/// An AutomatedProcess object.
/// </summary>
public class AutomatedProcess
{
    internal AutomatedProcess() { }

    /// <summary>
    /// Gets or sets the type of the code.
    /// </summary>
    /// <value>The type of the code.</value>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the type of the queue.
    /// </summary>
    /// <value>The type of the queue.</value>
    public ProcessQueue Queue { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the type of the delay.
    /// </summary>
    /// <value>The type of the delay.</value>
    public string Delay { get; set; }

    /// <summary>
    /// Gets or sets the type of the officeId.
    /// </summary>
    /// <value>The type of the officeId.</value>
    public string OfficeId { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateTime.
    /// </summary>
    /// <value>The type of the dateTime.</value>
    public string DateTime { get; set; }
}