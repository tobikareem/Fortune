namespace Flight.Model;

/// <summary>
/// An TravelerContact object.
/// </summary>
public class TravelerContact
{
    internal TravelerContact() { }

    /// <summary>
    /// Gets or sets the type of the addresseeName.
    /// </summary>
    /// <value>The type of the addresseeName.</value>
    public Name AddresseeName { get; set; }

    /// <summary>
    /// Gets or sets the type of the address.
    /// </summary>
    /// <value>The type of the address.</value>
    public ContactAddress Address { get; set; }

    /// <summary>
    /// Gets or sets the type of the language.
    /// </summary>
    /// <value>The type of the language.</value>
    public string Language { get; set; }

    /// <summary>
    /// Gets or sets the type of the purpose.
    /// </summary>
    /// <value>The type of the purpose.</value>
    public string Purpose { get; set; }

    /// <summary>
    /// Gets or sets the type of the phones.
    /// </summary>
    /// <value>The type of the phones.</value>
    public List<ContactPhone> Phones { get; set; }

    /// <summary>
    /// Gets or sets the type of the companyName.
    /// </summary>
    /// <value>The type of the companyName.</value>
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets the type of the emailAddress.
    /// </summary>
    /// <value>The type of the emailAddress.</value>
    public string EmailAddress { get; set; }
}