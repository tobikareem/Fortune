﻿namespace Flight.Model;

/// <summary>
/// An Pickup object.
/// </summary>
public class PickupDropoff
{
    internal PickupDropoff() { }

    /// <summary>
    /// Gets or sets the type of the localDateTime.
    /// </summary>
    /// <value>The type of the localDateTime.</value>
    public string LocalDateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the location.
    /// </summary>
    /// <value>The type of the location.</value>
    public Location Location { get; set; }
}