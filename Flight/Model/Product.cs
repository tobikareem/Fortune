namespace Flight.Model;

/// <summary>
/// An Product object.
/// </summary>
public class Product
{
    internal Product() { }

    /// <summary>
    /// Gets or sets the type of the air.
    /// </summary>
    /// <value>The type of the air.</value>
    public Air Air { get; set; }

    /// <summary>
    /// Gets or sets the type of the hotel.
    /// </summary>
    /// <value>The type of the hotel.</value>
    public Hotel Hotel { get; set; }

    /// <summary>
    /// Gets or sets the type of the car.
    /// </summary>
    /// <value>The type of the car.</value>
    public Car Car { get; set; }

    /// <summary>
    /// Gets or sets the type of the train.
    /// </summary>
    /// <value>The type of the train.</value>
    public Train Train { get; set; }
}