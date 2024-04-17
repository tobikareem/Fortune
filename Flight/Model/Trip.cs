namespace Flight.Model;

/// <summary>
/// An Trip object.
/// </summary>
public class Trip
{
    internal Trip() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the reference.
    /// </summary>
    /// <value>The type of the reference.</value>
    public string Reference { get; set; }

    /// <summary>
    /// Gets or sets the type of the creationDateTime.
    /// </summary>
    /// <value>The type of the creationDateTime.</value>
    public string CreationDateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookingDate.
    /// </summary>
    /// <value>The type of the bookingDate.</value>
    public string BookingDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the bookingNumber.
    /// </summary>
    /// <value>The type of the bookingNumber.</value>
    public string BookingNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the provider.
    /// </summary>
    /// <value>The type of the provider.</value>
    public string Provider { get; set; }

    /// <summary>
    /// Gets or sets the type of the title.
    /// </summary>
    /// <value>The type of the title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the type of the description.
    /// </summary>
    /// <value>The type of the description.</value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the type of the start.
    /// </summary>
    /// <value>The type of the start.</value>
    public StartEnd Start { get; set; }

    /// <summary>
    /// Gets or sets the type of the end.
    /// </summary>
    /// <value>The type of the end.</value>
    public StartEnd End { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelAgency.
    /// </summary>
    /// <value>The type of the travelAgency.</value>
    public TravelAgency TravelAgency { get; set; }

    /// <summary>
    /// Gets or sets the type of the stakeholders.
    /// </summary>
    /// <value>The type of the stakeholders.</value>
    public Stakeholder[] Stakeholders { get; set; }

    /// <summary>
    /// Gets or sets the type of the price.
    /// </summary>
    /// <value>The type of the price.</value>
    public Price Price { get; set; }

    /// <summary>
    /// Gets or sets the type of the products.
    /// </summary>
    /// <value>The type of the products.</value>
    public Product[] Products { get; set; }
}