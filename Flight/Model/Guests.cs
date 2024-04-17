namespace Flight.Model;

/// <summary>
/// An Guests object.
/// </summary>
public class Guests
{
    internal Guests() { }

    /// <summary>
    /// Gets or sets the adults.
    /// </summary>
    /// <value>The adults.</value>
    public int Adults { get; set; }

    /// <summary>
    /// Gets or sets the childAge.
    /// </summary>
    /// <value>The childAge.</value>
    public int[] ChildAge { get; set; }
}