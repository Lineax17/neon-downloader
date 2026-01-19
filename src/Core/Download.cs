namespace Core;

using System.Net;

public class Download
{
    String filePath;

    public Download()
    {
        this.filePath = PathHelper.getDownloadDirectory();
    }
    
    public Download(String filePath)
    {
        this.filePath = filePath;
    }

    public void download(String downloadUrl, String fileName)
    {
        WebClient client = new WebClient();
        client.DownloadFile(downloadUrl, Path.Combine(filePath, fileName));
    }
}