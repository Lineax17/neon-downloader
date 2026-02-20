using Core;

namespace Application;

public class HostValidator
{
    public HostValidator()
    {
        // No initialization needed for now, but this constructor can be used for future enhancements.
    }

    public bool HostIsYoutube(String url)
    {
        return PathHelper.getHostNameFromUrl(url) == "www.youtube.com";
    }
}