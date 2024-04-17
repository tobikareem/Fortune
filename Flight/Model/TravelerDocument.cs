namespace Flight.Model;

/// <summary>
/// An TravelerDocument object.
/// </summary>
public class TravelerDocument
{
    internal TravelerDocument() { }

    /// <summary>
    /// Gets or sets the type of the number.
    /// </summary>
    /// <value>The type of the number.</value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the type of the issuanceDate.
    /// </summary>
    /// <value>The type of the issuanceDate.</value>
    public string IssuanceDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the expiryDate.
    /// </summary>
    /// <value>The type of the expiryDate.</value>
    public string ExpiryDate { get; set; }

    /// <summary>
    /// Gets or sets the type of the issuanceCountry.
    /// </summary>
    /// <value>The type of the issuanceCountry.</value>
    public string IssuanceCountry { get; set; }

    /// <summary>
    /// Gets or sets the type of the issuanceLocation.
    /// </summary>
    /// <value>The type of the issuanceLocation.</value>
    public string IssuanceLocation { get; set; }

    /// <summary>
    /// Gets or sets the type of the nationality.
    /// </summary>
    /// <value>The type of the nationality.</value>
    public string Nationality { get; set; }

    /// <summary>
    /// Gets or sets the type of the birthPlace.
    /// </summary>
    /// <value>The type of the birthPlace.</value>
    public string BirthPlace { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentType.
    /// </summary>
    /// <value>The type of the documentType.</value>
    public string DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the type of the validityCountry.
    /// </summary>
    /// <value>The type of the validityCountry.</value>
    public string ValidityCountry { get; set; }

    /// <summary>
    /// Gets or sets the type of the birthCountry.
    /// </summary>
    /// <value>The type of the birthCountry.</value>
    public string BirthCountry { get; set; }

    /// <summary>
    /// Gets or sets the type of the holder.
    /// </summary>
    /// <value>The type of the holder.</value>
    public bool Holder { get; set; }
}