namespace Flight.Model;

/// <summary>
/// An AssociatedRecord object.
/// </summary>
public class AssociatedRecord
{
    internal AssociatedRecord() { }

    /// <summary>
    /// Gets or sets the type of the reference.
    /// </summary>
    /// <value>The type of the reference.</value>
    public string Reference { get; set; }

    /// <summary>
    /// Gets or sets the type of the creationDate.
    /// </summary>
    /// <value>The type of the creationDate.</value>
    public string CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the originSystemCode.
    /// </summary>
    /// <value>The type of the originSystemCode.</value>
    public string OriginSystemCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferId.
    /// </summary>
    /// <value>The type of the flightOfferId.</value>
    public string FlightOfferId { get; set; }
}