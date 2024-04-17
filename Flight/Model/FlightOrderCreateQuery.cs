namespace Flight.Model;

/// <summary>
/// An FlightOrderCreateQuery object.
/// </summary>
public class FlightOrderCreateQuery : Resource
{
    internal FlightOrderCreateQuery() { }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the queuingOfficeId.
    /// </summary>
    /// <value>The type of the queuingOfficeId.</value>
    public string QueuingOfficeId { get; set; }

    /// <summary>
    /// Gets or sets the type of the ownerOfficeId.
    /// </summary>
    /// <value>The type of the ownerOfficeId.</value>
    public string OwnerOfficeId { get; set; }

    /// <summary>
    /// Gets or sets the type of the associatedRecords.
    /// </summary>
    /// <value>The type of the associatedRecords.</value>
    public List<AssociatedRecord> AssociatedRecords { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOffers.
    /// </summary>
    /// <value>The type of the flightOffers.</value>
    public List<FlightOffer> FlightOffers { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelers.
    /// </summary>
    /// <value>The type of the travelers.</value>
    public List<TravelerElement> Travelers { get; set; }

    /// <summary>
    /// Gets or sets the type of the remarks.
    /// </summary>
    /// <value>The type of the remarks.</value>
    public Remarks Remarks { get; set; }

    /// <summary>
    /// Gets or sets the type of the formOfPayments.
    /// </summary>
    /// <value>The type of the formOfPayments.</value>
    public List<FormOfPayment> FormOfPayments { get; set; }

    /// <summary>
    /// Gets or sets the type of the ticketingAgreement.
    /// </summary>
    /// <value>The type of the ticketingAgreement.</value>
    public TicketingAgreement TicketingAgreement { get; set; }

    /// <summary>
    /// Gets or sets the type of the automatedProcess.
    /// </summary>
    /// <value>The type of the automatedProcess.</value>
    public List<AutomatedProcess> AutomatedProcess { get; set; }

    /// <summary>
    /// Gets or sets the type of the contacts.
    /// </summary>
    /// <value>The type of the contacts.</value>
    public List<Contact> Contacts { get; set; }

    /// <summary>
    /// Gets or sets the type of the tickets.
    /// </summary>
    /// <value>The type of the tickets.</value>
    public List<AirTravelDocument> Tickets { get; set; }
}