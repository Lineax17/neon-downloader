using Core;

namespace Application;

public class HostValidator
{
    private readonly Download _downloader;
    
    public HostValidator(String url)
    {
        
    }
    
    public bool HostIsYoutube(String url)
    {
        return PathHelper.getHostNameFromUrl(url) == "www.youtube.com";
    }

}