namespace Flight.Model;

/// <summary>
/// An DiseaseCase object.
/// </summary>
public class DiseaseCase
{
    internal DiseaseCase() { }

    /// <summary>
    /// Gets or sets the type of the date.
    /// </summary>
    /// <value>The type of the date.</value>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the active.
    /// </summary>
    /// <value>The type of the active.</value>
    public int Active { get; set; }

    /// <summary>
    /// Gets or sets the type of the recovered.
    /// </summary>
    /// <value>The type of the recovered.</value>
    public int Recovered { get; set; }

    /// <summary>
    /// Gets or sets the type of the deaths.
    /// </summary>
    /// <value>The type of the deaths.</value>
    public int Deaths { get; set; }

    /// <summary>
    /// Gets or sets the type of the confirmed.
    /// </summary>
    /// <value>The type of the confirmed.</value>
    public int Confirmed { get; set; }

}