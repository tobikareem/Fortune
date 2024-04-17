namespace Flight.Model;

/// <summary>
/// An AreaVaccinated object.
/// </summary>
public class AreaVaccinated
{
    internal AreaVaccinated() { }

    /// <summary>
    /// Gets or sets the type of the vaccinationDoseStatus.
    /// </summary>
    /// <value>The type of the vaccinationDoseStatus.</value>
    public string VaccinationDoseStatus { get; set; }

    /// <summary>
    /// Gets or sets the type of the percentage.
    /// </summary>
    /// <value>The type of the percentage.</value>
    public double Percentage { get; set; }

    /// <summary>
    /// Gets or sets the type of the date.
    /// </summary>
    /// <value>The type of the date.</value>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }
}