namespace Flight.Model;

/// <summary>
/// An AutomatedProcessCommon object.
/// </summary>
public class AutomatedProcessCommon
{
    internal AutomatedProcessCommon() { }

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
    public int Text { get; set; }
}