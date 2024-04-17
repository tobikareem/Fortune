namespace Flight.Model;

/// <summary>
/// An AirTravelDocumentCommon object.
/// </summary>
public class AirTravelDocumentCommon
{
    internal AirTravelDocumentCommon() { }

    /// <summary>
    /// Gets or sets the type of the documentType.
    /// </summary>
    /// <value>The type of the documentType.</value>
    public string DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentNumber.
    /// </summary>
    /// <value>The type of the documentNumber.</value>
    public string DocumentNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentStatus.
    /// </summary>
    /// <value>The type of the documentStatus.</value>
    public string DocumentStatus { get; set; }
}