namespace Core;

public static class PathHelper
{
    public static String getHomeDirectory()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }

    public static String getDownloadDirectory()
    {
        return Path.Combine(getHomeDirectory(), "Downloads");
    }
    
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