namespace Flight.Model;

/// <summary>
/// An Facility object.
/// </summary>
public class Facility
{
    internal Facility() { }

    /// <summary>
    /// Gets or sets the type of the code.
    /// </summary>
    /// <value>The type of the code.</value>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the type of the column.
    /// </summary>
    /// <value>The type of the column.</value>
    public string Column { get; set; }

    /// <summary>
    /// Gets or sets the type of the row.
    /// </summary>
    /// <value>The type of the row.</value>
    public string Row { get; set; }

    /// <summary>
    /// Gets or sets the type of the position.
    /// </summary>
    /// <value>The type of the position.</value>
    public string Position { get; set; }

    /// <summary>
    /// Gets or sets the type of the coordinates.
    /// </summary>
    /// <value>The type of the coordinates.</value>
    public Coordinates Coordinates { get; set; }
}