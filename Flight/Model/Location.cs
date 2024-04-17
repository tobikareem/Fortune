namespace Flight.Model;

/// <summary>
/// An Location object as returned by the Locaion API.
/// <see cref="Locations.get()"/>
/// </summary>
public class Location : Resource
{

    internal Location() { }

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
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the name of the detailed.
    /// </summary>
    /// <value>The name of the detailed.</value>
    public string DetailedName { get; set; }

    /// <summary>
    /// Gets or sets the time zone offset.
    /// </summary>
    /// <value>The time zone offset.</value>
    public string TimeZoneOffset { get; set; }

    /// <summary>
    /// Gets or sets the iata code.
    /// </summary>
    /// <value>The iata code.</value>
    public string IataCode { get; set; }

    /// <summary>
    /// Gets or sets the geo code.
    /// </summary>
    /// <value>The geo code.</value>
    public GeoCode GeoCode { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the distance.
    /// </summary>
    /// <value>The distance.</value>
    public Distance Distance { get; set; }

    /// <summary>
    /// Gets or sets the analytics.
    /// </summary>
    /// <value>The analytics.</value>
    public Analytics Analytics { get; set; }

    /// <summary>
    /// Gets or sets the relevance.
    /// </summary>
    /// <value>The relevance.</value>
    public double Relevance { get; set; }

    /// <summary>
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
    /// </summary>
    public class GeoCode
    {

        internal GeoCode() { }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }

    }

    /// <summary>
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
    /// </summary>
    public class Address
    {

        internal Address() { }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the city code.
        /// </summary>
        /// <value>The city code.</value>
        public string CityCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>The name of the country.</value>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        /// <value>The region code.</value>
        public string RegionCode { get; set; }

    }

    /// <summary>
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
    /// </summary>
    public class Distance
    {

        internal Distance() { }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }

    }

    /// <summary>
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
    /// </summary>
    public class Analytics
    {

        internal Analytics() { }

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

    }

    /// <summary>
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
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
    /// An Location-related object as returned by the Locaion API.
    /// <see cref="Locations.get()"/>
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