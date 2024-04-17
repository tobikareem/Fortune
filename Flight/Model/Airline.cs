namespace Flight.Model;

/// <summary>
/// An Airline object as returned by the Airline Code LookUp API.
/// <see cref="ReferenceData.airlines"/>
/// </summary>
public class Airline : Resource
{

    internal Airline() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the iata code.
    /// </summary>
    /// <value>The iata code.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the icao code.
    /// </summary>
    /// <value>The icao code.</value>
    public string IcaoCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the business.
    /// </summary>
    /// <value>The name of the business.</value>
    public string BusinessName { get; set; }

    /// <summary>
    /// Gets or sets the name of the common.
    /// </summary>
    /// <value>The name of the common.</value>
    public string CommonName { get; set; }

}