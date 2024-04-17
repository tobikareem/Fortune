namespace Flight.Model;

/// <summary>
/// An SafetyScore object.
/// </summary>
public class SafetyScore
{
    internal SafetyScore() { }

    /// <summary>
    /// Gets or sets the type of the women.
    /// </summary>
    /// <value>The type of the women.</value>
    public int Women { get; set; }

    /// <summary>
    /// Gets or sets the type of the physicalHarm.
    /// </summary>
    /// <value>The type of the physicalHarm.</value>
    public int PhysicalHarm { get; set; }

    /// <summary>
    /// Gets or sets the type of the theft.
    /// </summary>
    /// <value>The type of the theft.</value>
    public int Theft { get; set; }

    /// <summary>
    /// Gets or sets the type of the politicalFreedom.
    /// </summary>
    /// <value>The type of the politicalFreedom.</value>
    public int PoliticalFreedom { get; set; }

    /// <summary>
    /// Gets or sets the type of the lgbtq.
    /// </summary>
    /// <value>The type of the lgbtq.</value>
    public int Lgbtq { get; set; }

    /// <summary>
    /// Gets or sets the type of the medical.
    /// </summary>
    /// <value>The type of the medical.</value>
    public int Medical { get; set; }

    /// <summary>
    /// Gets or sets the type of the overall.
    /// </summary>
    /// <value>The type of the overall.</value>
    public int Overall { get; set; }
}