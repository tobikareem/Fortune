namespace Flight.Model;

/// <summary>
/// An BookingRequirements object.
/// </summary>
public class BookingRequirements
{
    internal BookingRequirements() { }

    /// <summary>
    /// Gets or sets the type of the invoiceAddressRequired.
    /// </summary>
    /// <value>The type of the invoiceAddressRequired.</value>
    public bool InvoiceAddressRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the mailingAddressRequired.
    /// </summary>
    /// <value>The type of the mailingAddressRequired.</value>
    public bool MailingAddressRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the emailAddressRequired.
    /// </summary>
    /// <value>The type of the emailAddressRequired.</value>
    public bool EmailAddressRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the phoneCountryCodeRequired.
    /// </summary>
    /// <value>The type of the phoneCountryCodeRequired.</value>
    public bool PhoneCountryCodeRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the mobilePhoneNumberRequired.
    /// </summary>
    /// <value>The type of the mobilePhoneNumberRequired.</value>
    public bool MobilePhoneNumberRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the phoneNumberRequired.
    /// </summary>
    /// <value>The type of the phoneNumberRequired.</value>
    public bool PhoneNumberRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the postalCodeRequired.
    /// </summary>
    /// <value>The type of the postalCodeRequired.</value>
    public bool PostalCodeRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerRequirements.
    /// </summary>
    /// <value>The type of the travelerRequirements.</value>
    public List<PassengerConditions> TravelerRequirements { get; set; }
}