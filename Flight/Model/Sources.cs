namespace Flight.Model;

/// <summary>
/// An Sources object.
/// </summary>
public class Sources
{
    internal Sources() { }

    /// <summary>
    /// Gets or sets the type of the covidDashboardLink.
    /// </summary>
    /// <value>The type of the covidDashboardLink.</value>
    public string CovidDashboardLink { get; set; }

    /// <summary>
    /// Gets or sets the type of the healthDepartementSiteLink.
    /// </summary>
    /// <value>The type of the healthDepartementSiteLink.</value>
    public string HealthDepartementSiteLink { get; set; }

    /// <summary>
    /// Gets or sets the type of the governmentSiteLink.
    /// </summary>
    /// <value>The type of the governmentSiteLink.</value>
    public string GovernmentSiteLink { get; set; }
}