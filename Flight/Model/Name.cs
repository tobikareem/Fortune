﻿namespace Flight.Model;

/// <summary>
/// An Name object.
/// </summary>
public class Name
{
    internal Name() { }

    /// <summary>
    /// Gets or sets the firstName.
    /// </summary>
    /// <value>The firstName.</value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the lastName.
    /// </summary>
    /// <value>The lastName.</value>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the middleName.
    /// </summary>
    /// <value>The middleName.</value>
    public string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets the secondLastName.
    /// </summary>
    /// <value>The secondLastName.</value>
    public string SecondLastName { get; set; }

    /// <summary>
    /// Gets or sets the prefix.
    /// </summary>
    /// <value>The prefix.</value>
    public string Prefix { get; set; }

    /// <summary>
    /// Gets or sets the suffix.
    /// </summary>
    /// <value>The suffix.</value>
    public string Suffix { get; set; }
}