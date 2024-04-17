namespace Flight.Model;

/// <summary>
/// An TravelerElement object.
/// </summary>
public class TravelerElement
{
    internal TravelerElement() { }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateOfBirth.
    /// </summary>
    /// <value>The type of the dateOfBirth.</value>
    public string DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the type of the gender.
    /// </summary>
    /// <value>The type of the gender.</value>
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the type of the name.
    /// </summary>
    /// <value>The type of the name.</value>
    public Name Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the documents.
    /// </summary>
    /// <value>The type of the documents.</value>
    public List<TravelerDocument> Documents { get; set; }

    /// <summary>
    /// Gets or sets the type of the emergencyContact.
    /// </summary>
    /// <value>The type of the emergencyContact.</value>
    public EmergencyContact EmergencyContact { get; set; }

    /// <summary>
    /// Gets or sets the type of the loyaltyPrograms.
    /// </summary>
    /// <value>The type of the loyaltyPrograms.</value>
    public List<LoyaltyProgram> LoyaltyPrograms { get; set; }

    /// <summary>
    /// Gets or sets the type of the discountEligibility.
    /// </summary>
    /// <value>The type of the discountEligibility.</value>
    public List<Discount> DiscountEligibility { get; set; }

    /// <summary>
    /// Gets or sets the type of the contact.
    /// </summary>
    /// <value>The type of the contact.</value>
    public TravelerContact Contact { get; set; }
}