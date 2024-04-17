namespace Flight.Model;

/// <summary>
/// An DiseaseTestingRestriction object.
/// </summary>
public class DiseaseTestingRestriction
{
    internal DiseaseTestingRestriction() { }

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

    /// <summary>
    /// Gets or sets the type of the isRequired.
    /// </summary>
    /// <value>The type of the isRequired.</value>
    public string IsRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the when.
    /// </summary>
    /// <value>The type of the when.</value>
    public string When { get; set; }

    /// <summary>
    /// Gets or sets the type of the requirement.
    /// </summary>
    /// <value>The type of the requirement.</value>
    public string Requirement { get; set; }

    /// <summary>
    /// Gets or sets the type of the rules.
    /// </summary>
    /// <value>The type of the rules.</value>
    public string Rules { get; set; }

    /// <summary>
    /// Gets or sets the type of the testType.
    /// </summary>
    /// <value>The type of the testType.</value>
    public string TestType { get; set; }

    /// <summary>
    /// Gets or sets the type of the minimumAge.
    /// </summary>
    /// <value>The type of the minimumAge.</value>
    public int MinimumAge { get; set; }

    /// <summary>
    /// Gets or sets the type of the validityPeriod.
    /// </summary>
    /// <value>The type of the validityPeriod.</value>
    public ValidityPeriod ValidityPeriod { get; set; }
}