namespace Flight.Model;

/// <summary>
/// An TypeEstimated object.
/// </summary>
public class TypeEstimated
{
    internal TypeEstimated() { }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>The category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the beds.
    /// </summary>
    /// <value>The beds.</value>
    public string Beds { get; set; }

    /// <summary>
    /// Gets or sets the bedType.
    /// </summary>
    /// <value>The bedType.</value>
    public string BedType { get; set; }
}