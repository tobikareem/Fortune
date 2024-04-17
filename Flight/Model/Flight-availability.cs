﻿namespace Flight.Model;

/// <summary>
/// An FlightAvailability object.
/// </summary>
public class FlightAvailability
{
    internal FlightAvailability() { }

    /// <summary>
    /// Gets or sets the type of the type.
    /// </summary>
    /// <value>The type of the type.</value>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the type of the id.
    /// </summary>
    /// <value>The type of the id.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the originDestinationId.
    /// </summary>
    /// <value>The type of the originDestinationId.</value>
    public string OriginDestinationId { get; set; }

    /// <summary>
    /// Gets or sets the type of the source.
    /// </summary>
    /// <value>The type of the source.</value>
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets the type of the instantTicketingRequired.
    /// </summary>
    /// <value>The type of the instantTicketingRequired.</value>
    public bool InstantTicketingRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the paymentCardRequired.
    /// </summary>
    /// <value>The type of the paymentCardRequired.</value>
    public bool PaymentCardRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the duration.
    /// </summary>
    /// <value>The type of the duration.</value>
    public string Duration { get; set; }

    /// <summary>
    /// Gets or sets the type of the segments.
    /// </summary>
    /// <value>The type of the segments.</value>
    public List<ExtendedSegment> Segments { get; set; }
}