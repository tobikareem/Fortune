namespace Flight.Model;

/// <summary>
/// An AssociationRef object.
/// </summary>
public class AssociationRef
{
    internal AssociationRef() { }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }
}