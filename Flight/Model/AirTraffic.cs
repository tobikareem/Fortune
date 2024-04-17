namespace Flight.Model;

/// <summary>
/// An AirTraffic object as returned by the AirTraffic API.
/// <see cref="ReferenceData.locations"/>
/// </summary>
public class AirTraffic : Resource
{

    internal AirTraffic() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the sub.
    /// </summary>
    /// <value>The type of the sub.</value>
    public string SubType { get; set; }

    /// <summary>
    /// Gets or sets the destination.
    /// </summary>
    /// <value>The destination.</value>
    public string Destination { get; set; }

    /// <summary>
    /// Gets or sets the analytics.
    /// </summary>
    /// <value>The analytics.</value>
    public Analytics Analytics { get; set; }

    /// <summary>
    /// An AirTraffic-related object as returned by the AirTraffic API.
    /// <see cref="ReferenceData.locations"/>
    /// </summary>
    public class Analytics
    {

        /// <summary>
        /// Initializes a new instance of the Analytics class.
        /// </summary>
        public Analytics() { }

        /// <summary>
        /// Gets or sets the flights.
        /// </summary>
        /// <value>The flights.</value>
        public Flights Flights { get; set; }

        /// <summary>
        /// Gets or sets the travelers.
        /// </summary>
        /// <value>The travelers.</value>
        public Travelers Travelers { get; set; }

        /// <summary>
        /// An AirTraffic-related object as returned by the AirTraffic API.
        /// <see cref="ReferenceData.locations"/>
        /// </summary>
        public class Flights
        {
            internal Flights() { }

            /// <summary>
            /// Gets or sets the score.
            /// </summary>
            /// <value>The score.</value>
            public double Score { get; set; }

        }

        /// <summary>
        /// An AirTraffic-related object as returned by the AirTraffic API.
        /// <see cref="ReferenceData.locations"/>
        /// </summary>
        public class Travelers
        {
            internal Travelers() { }

            /// <summary>
            /// Gets or sets the score.
            /// </summary>
            /// <value>The score.</value>
            public double Score { get; set; }

        }

    }

}