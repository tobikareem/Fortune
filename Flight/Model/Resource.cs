namespace Flight.Model;

/// <summary>
/// Internal Resource class
/// </summary>
public class Resource
{
    internal Resource()
    {
    }

    /// <summary>
    /// The original response that this object is populated from.
    /// </summary>
    /// <value>The response.</value>
    public Response Response { get; set; }

    /// <summary>
    /// The class used for deserialization.
    /// </summary>
    /// <value>The de serialization class.</value>
    internal Type DeSerializationClass { get; set; }

    /// <summary>
    /// Turns a response into a Gson deserialized array of resources,
    /// attaching the response to each resource.
    /// </summary>
    /// <returns>The array.</returns>
    /// <param name="response">Response.</param>
    /// <param name="type">Type.</param>
    internal static Resource[] FromArray(Response response, Type type)
    {
        Console.WriteLine(response.dataString);
        Resource[] resources = JsonConvert.DeserializeObject(response.dataString, type);
        foreach (Resource resource in resources)
        {
            resource.Response = response;
            resource.DeSerializationClass = type;
        }
        return resources;
    }

    /*
     * Turns a response into a Gson deserialized resource,
     * attaching the response to the resource.
     * @hide as only used internally
     */
    internal static Resource FromObject(Response response, Type type)
    {
        Resource resource = JsonConvert.DeserializeObject(response.dataString, type);
        resource.Response = response;
        resource.DeSerializationClass = type;
        return resource;
    }

    /*
     * Turns a response into a JSON serialized string,
     * attaching the response to each resource.
     * @hide as only used internally
     */
    internal static string ToStringResult(Response response)
    {
        return response.dataString;
    }

    /// <summary>
    /// Returns a String that represents the current Resource.
    /// </summary>
    /// <returns>A String that represents the current Resource.</returns>
    public override string ToString()
    {
        var result = GetType().ToString() + "[";
        var propertyStrings = from prop in GetType().GetProperties()
            select $"{prop.Name}={prop.GetValue(this)}";
        result += string.Join(", ", propertyStrings);
        result += "]";
        return result;
    }
}