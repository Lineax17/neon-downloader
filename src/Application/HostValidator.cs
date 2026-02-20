using Core;

namespace Application;

/// <summary>
/// Validates download hosts and provides host-specific filtering.
/// </summary>
public class HostValidator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HostValidator"/> class.
    /// </summary>
    public HostValidator()
    {
        // No initialization needed for now, but this constructor can be used for future enhancements.
    }

    /// <summary>
    /// Determines whether the specified URL is from YouTube.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <returns><c>true</c> if the URL is from YouTube; otherwise, <c>false</c>.</returns>
    public bool HostIsYoutube(String url)
    {
        return PathHelper.getHostNameFromUrl(url) == "www.youtube.com";
    }
}