namespace Flight.Model;

/// <summary>
/// An Driver object.
/// </summary>
public class Driver
{
    internal Driver() { }

    /// <summary>
    /// Gets or sets the type of the contacts.
    /// </summary>
    /// <value>The type of the contacts.</value>
    public Contact[] Contacts { get; set; }
}