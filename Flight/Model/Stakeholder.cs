namespace Flight.Model;

/// <summary>
/// An Stakeholder object.
/// </summary>
public class Stakeholder
{
    internal Stakeholder() { }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the nationality.
    /// </summary>
    /// <value>The nationality.</value>
    public string Nationality { get; set; }

    /// <summary>
    /// Gets or sets the passangerTypeCode.
    /// </summary>
    /// <value>The passangerTypeCode.</value>
    public string PassangerTypeCode { get; set; }

    /// <summary>
    /// Gets or sets the dateOfBirth.
    /// </summary>
    /// <value>The dateOfBirth.</value>
    public string DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    /// <value>The gender.</value>
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    /// <value>The age.</value>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public Name Name { get; set; }

    /// <summary>
    /// Gets or sets the documents.
    /// </summary>
    /// <value>The documents.</value>
    public List<TravelerDocument> Documents { get; set; }
}