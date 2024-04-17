namespace Flight.Model;

/// <summary>
/// An TourAllotment object.
/// </summary>
public class TourAllotment
{
    internal TourAllotment() { }

    /// <summary>
    /// Gets or sets the type of the tourName.
    /// </summary>
    /// <value>The type of the tourName.</value>
    public string TourName { get; set; }

    /// <summary>
    /// Gets or sets the type of the tourReference.
    /// </summary>
    /// <value>The type of the tourReference.</value>
    public string TourReference { get; set; }

    /// <summary>
    /// Gets or sets the type of the mode.
    /// </summary>
    /// <value>The type of the mode.</value>
    public string Mode { get; set; }

    /// <summary>
    /// Gets or sets the type of the remainingSeats.
    /// </summary>
    /// <value>The type of the remainingSeats.</value>
    public string RemainingSeats { get; set; }
}