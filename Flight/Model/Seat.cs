namespace Flight.Model;

/// <summary>
/// An Seat object.
/// </summary>
public class Seat
{
    internal Seat() { }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the cabin.
    /// </summary>
    /// <value>The type of the cabin.</value>
    public string Cabin { get; set; }

    /// <summary>
    /// Gets or sets the type of the associationRefs.
    /// </summary>
    /// <value>The type of the associationRefs.</value>
    public List<AssociationRef> AssociationRefs { get; set; }

    /// <summary>
    /// Gets or sets the type of the characteristicsCodes.
    /// </summary>
    /// <value>The type of the characteristicsCodes.</value>
    public List<string> CharacteristicsCodes { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerPricing.
    /// </summary>
    /// <value>The type of the travelerPricing.</value>
    public List<SeatmapTravelerPricing> TravelerPricing { get; set; }

    /// <summary>
    /// Gets or sets the type of the coordinates.
    /// </summary>
    /// <value>The type of the coordinates.</value>
    public Coordinates Coordinates { get; set; }
}