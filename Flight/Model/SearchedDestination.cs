namespace Flight.Model;

/// <summary>
/// An SearchedDestination object as returned by the SearchedByDestination API.
/// <see cref="SearchedByDestination.get()"/>
/// </summary>
public class SearchedDestination : Resource
{

    internal SearchedDestination() { }

    /// <summary>
    /// Gets or sets the destination.
    /// </summary>
    /// <value>The destination.</value>
    public string Destination { get; set; }

    /// <summary>
    /// Gets or sets the type of the sub.
    /// </summary>
    /// <value>The type of the sub.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the analytics.
    /// </summary>
    /// <value>The analytics.</value>
    public Analytics Analytics { get; set; }

    /// <summary>
    /// An SearchedDestination-related object as returned by the SearchedByDestination API.
    /// <see cref="SearchedByDestination.get()"/>
    /// </summary>
    public class Analytics
    {

        internal Analytics() { }

        /// <summary>
        /// Gets or sets the searches.
        /// </summary>
        /// <value>The searches.</value>
        public Searches Searches { get; set; }

    }

    /// <summary>
    /// An SearchedDestination-related object as returned by the SearchedByDestination API.
    /// <see cref="SearchedByDestination.get()"/>
    /// </summary>
    public class Searches
    {

        internal Searches() { }

        /// <summary>
        /// Gets or sets the number of searches.
        /// </summary>
        /// <value>The number of searches.</value>
        public NumberOfSearches NumberOfSearches { get; set; }

    }

    /// <summary>
    /// An SearchedDestination-related object as returned by the SearchedByDestination API.
    /// <see cref="SearchedByDestination.get()"/>
    /// </summary>
    public class NumberOfSearches
    {

        internal NumberOfSearches() { }

        /// <summary>
        /// Gets or sets the duration of the per trip.
        /// </summary>
        /// <value>The duration of the per trip.</value>
        public Dictionary<string, int> PerTripDuration { get; set; }

        /// <summary>
        /// Gets or sets the per days in advance.
        /// </summary>
        /// <value>The per days in advance.</value>
        public Dictionary<string, int> PerDaysInAdvance { get; set; }

    }

}