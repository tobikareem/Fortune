namespace Flight.Model;

/// <summary>
/// An DiseaseAreaReport object.
/// </summary>
public class DiseaseAreaReport : Resource
{
    internal DiseaseAreaReport() { }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the area.
    /// </summary>
    /// <value>The type of the area.</value>
    public Area Area { get; set; }

    /// <summary>
    /// Gets or sets the type of the subAreas.
    /// </summary>
    /// <value>The type of the subAreas.</value>
    public List<string> SubAreas { get; set; }

    /// <summary>
    /// Gets or sets the type of the summary.
    /// </summary>
    /// <value>The type of the summary.</value>
    public string Summary { get; set; }

    /// <summary>
    /// Gets or sets the type of the diseaseRiskLevel.
    /// </summary>
    /// <value>The type of the diseaseRiskLevel.</value>
    public string DiseaseRiskLevel { get; set; }

    /// <summary>
    /// Gets or sets the type of the diseaseInfection.
    /// </summary>
    /// <value>The type of the diseaseInfection.</value>
    public DiseaseInfection DiseaseInfection { get; set; }

    /// <summary>
    /// Gets or sets the type of the doors.
    /// </summary>
    /// <value>The type of the doors.</value>
    public int Doors { get; set; }

    /// <summary>
    /// Gets or sets the type of the diseaseCases.
    /// </summary>
    /// <value>The type of the diseaseCases.</value>
    public DiseaseCase DiseaseCases { get; set; }

    /// <summary>
    /// Gets or sets the type of the hotspots.
    /// </summary>
    /// <value>The type of the hotspots.</value>
    public string Hotspots { get; set; }

    /// <summary>
    /// Gets or sets the type of the dataSources.
    /// </summary>
    /// <value>The type of the dataSources.</value>
    public Sources DataSources { get; set; }

    /// <summary>
    /// Gets or sets the type of the areaRestrictions.
    /// </summary>
    /// <value>The type of the areaRestrictions.</value>
    public List<AreaRestriction> AreaRestrictions { get; set; }

    /// <summary>
    /// Gets or sets the type of the areaAccessRestriction.
    /// </summary>
    /// <value>The type of the areaAccessRestriction.</value>
    public AreaAccessRestriction AreaAccessRestriction { get; set; }

    /// <summary>
    /// Gets or sets the type of the areaPolicy.
    /// </summary>
    /// <value>The type of the areaPolicy.</value>
    public AreaPolicy AreaPolicy { get; set; }

    /// <summary>
    /// Gets or sets the type of the relatedArea.
    /// </summary>
    /// <value>The type of the relatedArea.</value>
    public List<Link> RelatedArea { get; set; }

    /// <summary>
    /// Gets or sets the type of the areaVaccinated.
    /// </summary>
    /// <value>The type of the areaVaccinated.</value>
    public List<AreaVaccinated> AreaVaccinated { get; set; }
}