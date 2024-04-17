namespace Flight.Model;

/// <summary>
/// An Deck object.
/// </summary>
public class Deck
{
    internal Deck() { }

    /// <summary>
    /// Gets or sets the type of the deckType.
    /// </summary>
    /// <value>The type of the deckType.</value>
    public string DeckType { get; set; }

    /// <summary>
    /// Gets or sets the type of the deckConfiguration.
    /// </summary>
    /// <value>The type of the deckConfiguration.</value>
    public DeckConfiguration DeckConfiguration { get; set; }

    /// <summary>
    /// Gets or sets the type of the facilities.
    /// </summary>
    /// <value>The type of the facilities.</value>
    public List<Facility> Facilities { get; set; }

    /// <summary>
    /// Gets or sets the type of the seats.
    /// </summary>
    /// <value>The type of the seats.</value>
    public List<Seat> Seats { get; set; }
}