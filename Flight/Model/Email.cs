namespace Flight.Model;

/// <summary>
/// An Email object.
/// </summary>
public class Email
{
    internal Email() { }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>The category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public string Address { get; set; }
}