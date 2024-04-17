namespace Flight.Model;

/// <summary>
/// An GeneralRemark object.
/// </summary>
public class GeneralRemark
{
    internal GeneralRemark() { }

    /// <summary>
    /// Gets or sets the type of the subType.
    /// </summary>
    /// <value>The type of the subType.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the type of the category.
    /// </summary>
    /// <value>The type of the category.</value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the type of the travelerIds.
    /// </summary>
    /// <value>The type of the travelerIds.</value>
    public List<string> TravelerIds { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferIds.
    /// </summary>
    /// <value>The type of the flightOfferIds.</value>
    public List<string> FlightOfferIds { get; set; }
}