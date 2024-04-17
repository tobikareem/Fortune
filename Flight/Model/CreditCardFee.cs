﻿namespace Flight.Model;

/// <summary>
/// An CreditCardFee object.
/// </summary>
public class CreditCardFee
{
    internal CreditCardFee() { }

    /// <summary>
    /// Gets or sets the type of the brand.
    /// </summary>
    /// <value>The type of the brand.</value>
    public string Brand { get; set; }

    /// <summary>
    /// Gets or sets the type of the amount.
    /// </summary>
    /// <value>The type of the amount.</value>
    public string Amount { get; set; }

    /// <summary>
    /// Gets or sets the type of the currency.
    /// </summary>
    /// <value>The type of the currency.</value>
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the type of the flightOfferId.
    /// </summary>
    /// <value>The type of the flightOfferId.</value>
    public string FlightOfferId { get; set; }
}