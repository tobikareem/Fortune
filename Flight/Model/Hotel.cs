namespace Flight.Model;

/// <summary>
/// An Hotel object.
/// </summary>
public class Hotel
{
    internal Hotel() { }

    /// <summary>
    /// Gets or sets the confirmationNumber.
    /// </summary>
    /// <value>The confirmationNumber.</value>
    public string ConfirmationNumber { get; set; }

    /// <summary>
    /// Gets or sets the checkInDate.
    /// </summary>
    /// <value>The checkInDate.</value>
    public string CheckInDate { get; set; }

    /// <summary>
    /// Gets or sets the checkOutDate.
    /// </summary>
    /// <value>The checkOutDate.</value>
    public string CheckOutDate { get; set; }

    /// <summary>
    /// Gets or sets the roomQuantity.
    /// </summary>
    /// <value>The roomQuantity.</value>
    public int RoomQuantity { get; set; }

    /// <summary>
    /// Gets or sets the contact.
    /// </summary>
    /// <value>The contact.</value>
    public ContactHotel Contact { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the amenities.
    /// </summary>
    /// <value>The amenities.</value>
    public string[] Amenities { get; set; }


    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public Description Description { get; set; }

    /// <summary>
    /// Gets or sets the policies.
    /// </summary>
    /// <value>The policies.</value>
    public Policies Policies { get; set; }

    /// <summary>
    /// Gets or sets the guests.
    /// </summary>
    /// <value>The guests.</value>
    public Guests Guests { get; set; }

    /// <summary>
    /// Gets or sets the room.
    /// </summary>
    /// <value>The room.</value>
    public Room Room { get; set; }
}