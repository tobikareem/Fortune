namespace Flight.Model;

/// <summary>
/// An DateTimeRange object.
/// </summary>
public class DateTimeRange
{
    public DateTimeRange() { }

    /// <summary>
    /// Gets or sets the type of the date.
    /// </summary>
    /// <value>The type of the date.</value>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateWindow.
    /// </summary>
    /// <value>The type of the dateWindow.</value>
    public string DateWindow { get; set; }

    /// <summary>
    /// Gets or sets the type of the time.
    /// </summary>
    /// <value>The type of the time.</value>
    public string Time { get; set; }

    /// <summary>
    /// Gets or sets the type of the timeWindow.
    /// </summary>
    /// <value>The type of the timeWindow.</value>
    public string TimeWindow { get; set; }
}