namespace Flight.Model;

/// <summary>
/// An PassengerConditions object.
/// </summary>
public class PassengerConditions
{
    internal PassengerConditions() { }

    /// <summary>
    /// Gets or sets the type of the travelerId.
    /// </summary>
    /// <value>The type of the travelerId.</value>
    public string TravelerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the genderRequired.
    /// </summary>
    /// <value>The type of the genderRequired.</value>
    public bool GenderRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentRequired.
    /// </summary>
    /// <value>The type of the documentRequired.</value>
    public bool DocumentRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the documentIssuanceCityRequired.
    /// </summary>
    /// <value>The type of the documentIssuanceCityRequired.</value>
    public bool DocumentIssuanceCityRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the dateOfBirthRequired.
    /// </summary>
    /// <value>The type of the dateOfBirthRequired.</value>
    public bool DateOfBirthRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the redressRequiredIfAny.
    /// </summary>
    /// <value>The type of the redressRequiredIfAny.</value>
    public bool RedressRequiredIfAny { get; set; }

    /// <summary>
    /// Gets or sets the type of the airFranceDiscountRequired.
    /// </summary>
    /// <value>The type of the airFranceDiscountRequired.</value>
    public bool AirFranceDiscountRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the spanishResidentDiscountRequired.
    /// </summary>
    /// <value>The type of the spanishResidentDiscountRequired.</value>
    public bool SpanishResidentDiscountRequired { get; set; }

    /// <summary>
    /// Gets or sets the type of the residenceRequired.
    /// </summary>
    /// <value>The type of the residenceRequired.</value>
    public bool ResidenceRequired { get; set; }
}