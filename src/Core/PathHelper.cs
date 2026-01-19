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
}