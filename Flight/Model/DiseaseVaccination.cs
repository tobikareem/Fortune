namespace Flight.Model;

/// <summary>
/// An DiseaseVaccination object.
/// </summary>
public class DiseaseVaccination
{
    internal DiseaseVaccination() { }

    /// <summary>
    /// Gets or sets the type of the isRequired.
    /// </summary>
    /// <value>The type of the isRequired.</value>
    public string IsRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the referenceLink.
    /// </summary>
    /// <value>The type of the referenceLink.</value>
    public string ReferenceLink { get; set; }

    /// <summary>
    /// Gets or sets the type of the acceptedCertificates.
    /// </summary>
    /// <value>The type of the acceptedCertificates.</value>
    public List<string> AcceptedCertificates { get; set; }

    /// <summary>
    /// Gets or sets the type of the qualifiedVaccines.
    /// </summary>
    /// <value>The type of the qualifiedVaccines.</value>
    public List<string> QualifiedVaccines { get; set; }

    /// <summary>
    /// Gets or sets the type of the policy.
    /// </summary>
    /// <value>The type of the policy.</value>
    public string Policy { get; set; }

    /// <summary>
    /// Gets or sets the type of the exemptions.
    /// </summary>
    /// <value>The type of the exemptions.</value>
    public string Exemptions { get; set; }

    /// <summary>
    /// Gets or sets the type of the details.
    /// </summary>
    /// <value>The type of the details.</value>
    public string Details { get; set; }

    /// <summary>
    /// Gets or sets the type of the date.
    /// </summary>
    /// <value>The type of the date.</value>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }
}