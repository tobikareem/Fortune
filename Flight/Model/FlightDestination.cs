namespace Flight.Model;

/// <summary>
/// An FlightDestinations object as returned by the FlightDestinations API.
/// <see cref="FlightDestinations.get()"/>
/// </summary>
public class FlightDestination : Resource
{

    internal FlightDestination() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the origin.
    /// </summary>
    /// <value>The origin.</value>
    public string Origin { get; set; }

    /// <summary>
    /// Gets or sets the destination.
    /// </summary>
    /// <value>The destination.</value>
    public string Destination { get; set; }

    /// <summary>
    /// Gets or sets the departure date.
    /// </summary>
    /// <value>The departure date.</value>
    public DateTime DepartureDate { get; set; }

    /// <summary>
    /// Gets or sets the return date.
    /// </summary>
    /// <value>The return date.</value>
    public DateTime ReturnDate { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>The price.</value>
    public Price Price { get; set; }


    /// <summary>
    /// An FlightDestination-related object as returned by the FlightDestinations API.
    /// <see cref="FlightDestinations.get()"/>
    /// </summary>
    public class Price
    {

        internal Price() { }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total { get; set; }

    }

}