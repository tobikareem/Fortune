﻿namespace Flight.Model;

/// <summary>
/// An Amenity object.
/// </summary>
public class Amenity
{
    internal Amenity() { }

    /// <summary>
    /// Gets or sets the type of the isChargeable.
    /// </summary>
    /// <value>The type of the isChargeable.</value>
    public bool IsChargeable { get; set; }

    /// <summary>
    /// Gets or sets the type of the powerType.
    /// </summary>
    /// <value>The type of the powerType.</value>
    public string PowerType { get; set; }

    /// <summary>
    /// Gets or sets the type of the wifiCoverage.
    /// </summary>
    /// <value>The type of the wifiCoverage.</value>
    public string WifiCoverage { get; set; }

    /// <summary>
    /// Gets or sets the type of the entertainmentType.
    /// </summary>
    /// <value>The type of the entertainmentType.</value>
    public string EntertainmentType { get; set; }

    /// <summary>
    /// Gets or sets the type of the foodType.
    /// </summary>
    /// <value>The type of the foodType.</value>
    public string FoodType { get; set; }

    /// <summary>
    /// Gets or sets the type of the beverageType.
    /// </summary>
    /// <value>The type of the beverageType.</value>
    public string BeverageType { get; set; }
}