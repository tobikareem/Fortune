namespace Flight.Model;

/// <summary>
/// An AvailabilityClass object.
/// </summary>
public class AvailabilityClass
{
    internal AvailabilityClass() { }

    /// <summary>
    /// Gets or sets the type of the numberOfBookableSeats.
    /// </summary>
    /// <value>The type of the numberOfBookableSeats.</value>
    public int NumberOfBookableSeats { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookingClass.
    /// </summary>
    /// <value>The type of the bookingClass.</value>
    public string BookingClass { get; set; }

    /// <summary>
    /// Gets or sets the type of the closedStatus.
    /// </summary>
    /// <value>The type of the closedStatus.</value>
    public string ClosedStatus { get; set; }

    /// <summary>
    /// Gets or sets the type of the tourAllotment.
    /// </summary>
    /// <value>The type of the tourAllotment.</value>
    public TourAllotment TourAllotment { get; set; }
}