using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Meetup.Options.GraphQl;

/// <summary>
/// Static class with various GraphQL related extension methods.
/// </summary>
public static class MeetupGraphQlExtensions {

    /// <summary>
    /// Sets the variable with the specified <paramref name="name"/>.
    /// </summary>
    /// <typeparam name="T">The type of the options.</typeparam>
    /// <param name="options">The options on which to set the variable.</param>
    /// <param name="name">The name of the variable.</param>
    /// <param name="value">The value of the variable.</param>
    /// <returns><typeparamref name="T"/> - useful for method chaining.</returns>
    [return: NotNullIfNotNull("options")]
    public static T? SetVariable<T>(this T? options, string name, string value) where T : MeetupGraphQlOptions {
        if (options?.Variables != null) options.Variables[name] = value;
        return options;
    }

}