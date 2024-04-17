namespace Flight.Model;

/// <summary>
/// An Extended_Segment object.
/// </summary>
public class ExtendedSegment
{
    internal ExtendedSegment() { }

    /// <summary>
    /// Gets or sets the type of the closedStatus.
    /// </summary>
    /// <value>The type of the closedStatus.</value>
    public string ClosedStatus { get; set; }

    /// <summary>
    /// Gets or sets the type of the availabilityClasses.
    /// </summary>
    /// <value>The type of the availabilityClasses.</value>
    public List<AvailabilityClass> AvailabilityClasses { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public int Doors { get; set; }
}