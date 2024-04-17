namespace Flight.Model;

/// <summary>
/// An Vehicle object.
/// </summary>
public class Vehicle
{
    internal Vehicle() { }

    /// <summary>
    /// Gets or sets the type of the vehicleType.
    /// </summary>
    /// <value>The type of the vehicleType.</value>
    public string VehicleType { get; set; }

    /// <summary>
    /// Gets or sets the type of the code.
    /// </summary>
    /// <value>The type of the code.</value>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the displayName.
    /// </summary>
    /// <value>The type of the displayName.</value>
    public string DisplayName { get; set; }
}