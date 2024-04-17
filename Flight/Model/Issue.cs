namespace Flight.Model;

/// <summary>
/// An Issue object.
/// </summary>
public class Issue
{
    internal Issue() { }

    /// <summary>
    /// Gets or sets the type of the status.
    /// </summary>
    /// <value>The type of the status.</value>
    public int Status { get; set; }

    /// <summary>
    /// Gets or sets the type of the code.
    /// </summary>
    /// <value>The type of the code.</value>
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the type of the title.
    /// </summary>
    /// <value>The type of the title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public string Detail { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public IssueSource Source { get; set; }
}