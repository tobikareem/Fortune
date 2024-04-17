namespace Flight.Model;

/// <summary>
/// An Car object.
/// </summary>
public class Car
{
    internal Car() { }

    /// <summary>
    /// Gets or sets the type of the confirmationNumber.
    /// </summary>
    /// <value>The type of the confirmationNumber.</value>
    public string ConfirmationNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the serviceProviderName.
    /// </summary>
    /// <value>The type of the serviceProviderName.</value>
    public string ServiceProviderName { get; set; }

    /// <summary>
    /// Gets or sets the type of the associatedEquipments.
    /// </summary>
    /// <value>The type of the associatedEquipments.</value>
    public AssociatedEquipment[] AssociatedEquipments { get; set; }

    /// <summary>
    /// Gets or sets the type of the pickup.
    /// </summary>
    /// <value>The type of the pickup.</value>
    public PickupDropoff Pickup { get; set; }

    /// <summary>
    /// Gets or sets the type of the dropoff.
    /// </summary>
    /// <value>The type of the dropoff.</value>
    public PickupDropoff Dropoff { get; set; }

    /// <summary>
    /// Gets or sets the type of the driver.
    /// </summary>
    /// <value>The type of the driver.</value>
    public Driver Driver { get; set; }

    /// <summary>
    /// Gets or sets the type of the vehicle.
    /// </summary>
    /// <value>The type of the vehicle.</value>
    public CarVehicle Vehicle { get; set; }
}