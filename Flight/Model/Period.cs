namespace Flight.Model;

/// <summary>
/// An Period object as returned by the BusiestPeriod API.
/// <see cref="BusiestPeriod.get()"/>
/// </summary>
public class Period : Resource
{

    internal Period() { }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the period.
    /// </summary>
    /// <value>The period.</value>
    public string Period { get; set; }

    /// <summary>
    /// Gets or sets the analytics.
    /// </summary>
    /// <value>The analytics.</value>
    public Analytics Analytics { get; set; }

    /// <summary>
    /// An Period-related object as returned by the BusiestPeriod API.
    /// <see cref="BusiestPeriod.get()"/>
    /// </summary>
    public class Analytics
    {

        internal Analytics() { }

        /// <summary>
        /// Gets or sets the travelers.
        /// </summary>
        /// <value>The travelers.</value>
        public Travelers Travelers { get; set; }

    }

    /// <summary>
    /// An Period-related object as returned by the BusiestPeriod API.
    /// <see cref="BusiestPeriod.get()"/>
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