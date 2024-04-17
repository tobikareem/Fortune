namespace Flight.Model;

/// <summary>
/// An TermAndCondition object.
/// </summary>
public class TermAndCondition
{
    internal TermAndCondition() { }

    /// <summary>
    /// Gets or sets the type of the category.
    /// </summary>
    /// <value>The type of the category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the type of the circumstances.
    /// </summary>
    /// <value>The type of the circumstances.</value>
    public string Circumstances { get; set; }

    /// <summary>
    /// Gets or sets the type of the notApplicable.
    /// </summary>
    /// <value>The type of the notApplicable.</value>
    public bool NotApplicable { get; set; }

    /// <summary>
    /// Gets or sets the type of the maxPenaltyAmount.
    /// </summary>
    /// <value>The type of the maxPenaltyAmount.</value>
    public string MaxPenaltyAmount { get; set; }

    /// <summary>
    /// Gets or sets the type of the descriptions.
    /// </summary>
    /// <value>The type of the descriptions.</value>
    public List<Description> Descriptions { get; set; }
}