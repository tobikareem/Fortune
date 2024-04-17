namespace Flight.Model;

/// <summary>
/// An CarVehicle object.
/// </summary>
public class CarVehicle
{
    internal CarVehicle() { }

    /// <summary>
    /// Gets or sets the type of the acrissCode.
    /// </summary>
    /// <value>The type of the acrissCode.</value>
    public string AcrissCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the carModel.
    /// </summary>
    /// <value>The type of the carModel.</value>
    public string CarModel { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public int Doors { get; set; }
}