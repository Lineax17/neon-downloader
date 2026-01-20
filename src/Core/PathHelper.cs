namespace Core;

/// <summary>
/// Provides helper methods for working with file system paths.
/// </summary>
public static class PathHelper
{
    /// <summary>
    /// Gets the current user's home directory path.
    /// </summary>
    /// <returns>The full path to the user's home directory.</returns>
    public static String getHomeDirectory()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }

    /// <summary>
    /// Gets the current user's Downloads directory path.
    /// </summary>
    /// <returns>The full path to the user's Downloads directory.</returns>
    public static String getDownloadDirectory()
    {
        return Path.Combine(getHomeDirectory(), "Downloads");
    }
    
    /// <summary>
    /// Extracts the filename from a given URL.
    /// </summary>
    /// <param name="url">The URL from which to extract the filename.</param>
    /// <returns>The filename portion of the URL.</returns>
    public static String getFilenameFromUrl(String url)
    {
        var uri = new Uri(url);
        var filename =  Path.GetFileName(uri.AbsolutePath);
        
        //if (string.IsNullOrWhiteSpace(filename))
        //{
        //    throw new InvalidOperationException("URL contains no filename.");
        //}
        
        return filename;
    }
}