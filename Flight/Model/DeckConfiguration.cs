namespace Flight.Model;

/// <summary>
/// An DeckConfiguration object.
/// </summary>
public class DeckConfiguration
{
    internal DeckConfiguration() { }

    /// <summary>
    /// Gets or sets the type of the width.
    /// </summary>
    /// <value>The type of the width.</value>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the type of the length.
    /// </summary>
    /// <value>The type of the length.</value>
    public int Length { get; set; }

    /// <summary>
    /// Gets or sets the type of the startSeatRow.
    /// </summary>
    /// <value>The type of the startSeatRow.</value>
    public int StartSeatRow { get; set; }

    /// <summary>
    /// Gets or sets the type of the endSeatRow.
    /// </summary>
    /// <value>The type of the endSeatRow.</value>
    public int EndSeatRow { get; set; }

    /// <summary>
    /// Gets or sets the type of the startWingsX.
    /// </summary>
    /// <value>The type of the startWingsX.</value>
    public int StartWingsX { get; set; }

    /// <summary>
    /// Gets or sets the type of the endWingsX.
    /// </summary>
    /// <value>The type of the endWingsX.</value>
    public int EndWingsX { get; set; }

    /// <summary>
    /// Gets or sets the type of the startWingsRow.
    /// </summary>
    /// <value>The type of the startWingsRow.</value>
    public int StartWingsRow { get; set; }

    /// <summary>
    /// Gets or sets the type of the endWingsRow.
    /// </summary>
    /// <value>The type of the endWingsRow.</value>
    public int EndWingsRow { get; set; }

    /// <summary>
    /// Gets or sets the type of the exitRowsX.
    /// </summary>
    /// <value>The type of the exitRowsX.</value>
    public List<int> ExitRowsX { get; set; }
}