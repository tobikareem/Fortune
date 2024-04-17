namespace Flight.Model;

/// <summary>
/// An AirlineRemark object.
/// </summary>
public class AirlineRemark
{
    internal AirlineRemark() { }

    /// <summary>
    /// Gets or sets the type of the subType.
    /// </summary>
    /// <value>The type of the subType.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the type of the keyword.
    /// </summary>
    /// <value>The type of the keyword.</value>
    public string Keyword { get; set; }

    /// <summary>
    /// Gets or sets the type of the airlineCode.
    /// </summary>
    /// <value>The type of the airlineCode.</value>
    public string AirlineCode { get; set; }

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