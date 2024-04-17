namespace Flight.Model;

/// <summary>
/// An TripDetail object.
/// </summary>
public class TripDetail : Resource
{
    internal TripDetail() { }

    /// <summary>
    /// Gets or sets the trip.
    /// </summary>
    /// <value>The trip.</value>
    public Trip Trip { get; set; }
}