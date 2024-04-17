namespace Flight.Model;

/// <summary>
/// An AreaAccessRestriction object.
/// </summary>
public class AreaAccessRestriction
{
    internal AreaAccessRestriction() { }

    /// <summary>
    /// Gets or sets the type of the transportation.
    /// </summary>
    /// <value>The type of the transportation.</value>
    public Transportation Transportation { get; set; }

    /// <summary>
    /// Gets or sets the type of the declarationDocuments.
    /// </summary>
    /// <value>The type of the declarationDocuments.</value>
    public DeclarationDocuments DeclarationDocuments { get; set; }

    /// <summary>
    /// Gets or sets the type of the entry.
    /// </summary>
    /// <value>The type of the entry.</value>
    public EntryRestriction Entry { get; set; }

    /// <summary>
    /// Gets or sets the type of the diseaseTesting.
    /// </summary>
    /// <value>The type of the diseaseTesting.</value>
    public DiseaseTestingRestriction DiseaseTesting { get; set; }

    /// <summary>
    /// Gets or sets the type of the tracingApplication.
    /// </summary>
    /// <value>The type of the tracingApplication.</value>
    public DatedTracingApplicationRestriction TracingApplication { get; set; }

    /// <summary>
    /// Gets or sets the type of the quarantineModality.
    /// </summary>
    /// <value>The type of the quarantineModality.</value>
    public DatedQuarantineRestriction QuarantineModality { get; set; }

    /// <summary>
    /// Gets or sets the type of the mask.
    /// </summary>
    /// <value>The type of the mask.</value>
    public MaskRestriction Mask { get; set; }

    /// <summary>
    /// Gets or sets the type of the exit.
    /// </summary>
    /// <value>The type of the exit.</value>
    public ExitRestriction Exit { get; set; }

    /// <summary>
    /// Gets or sets the type of the otherRestriction.
    /// </summary>
    /// <value>The type of the otherRestriction.</value>
    public DatedInformation OtherRestriction { get; set; }

    /// <summary>
    /// Gets or sets the type of the diseaseVaccination.
    /// </summary>
    /// <value>The type of the diseaseVaccination.</value>
    public DiseaseVaccination DiseaseVaccination { get; set; }
}