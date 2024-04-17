namespace Flight.Model;

/// <summary>
/// An AircraftCabinAmenities object.
/// </summary>
public class AircraftCabinAmenities
{
    internal AircraftCabinAmenities() { }

    /// <summary>
    /// Gets or sets the type of the power.
    /// </summary>
    /// <value>The type of the power.</value>
    public Amenity Power { get; set; }

    /// <summary>
    /// Gets or sets the type of the seat.
    /// </summary>
    /// <value>The type of the seat.</value>
    public AmenitySeat Seat { get; set; }

    /// <summary>
    /// Gets or sets the type of the wifi.
    /// </summary>
    /// <value>The type of the wifi.</value>
    public Amenity Wifi { get; set; }

    /// <summary>
    /// Gets or sets the type of the entertainment.
    /// </summary>
    /// <value>The type of the entertainment.</value>
    public List<Amenity> Entertainment { get; set; }

    /// <summary>
    /// Gets or sets the type of the food.
    /// </summary>
    /// <value>The type of the food.</value>
    public Amenity Food { get; set; }

    /// <summary>
    /// Gets or sets the type of the beverage.
    /// </summary>
    /// <value>The type of the beverage.</value>
    public Amenity Beverage { get; set; }
}