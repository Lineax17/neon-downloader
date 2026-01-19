namespace Core;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Core Main Running");
        Console.WriteLine(PathHelper.getDownloadDirectory());
        Console.WriteLine(PathHelper.getHomeDirectory());

        String downloadUrl =
            "https://dl.fedoraproject.org/pub/fedora/linux/releases/43/KDE/x86_64/iso/Fedora-KDE-Desktop-Live-43-1.6.x86_64.iso";
        
        Download downloader = new Download();

        try
        {
            await downloader.DownloadAsync(downloadUrl);
            Console.WriteLine("Download successful completed.");

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Networkissue: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Fileissue: {e.Message}");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Access denied: {e.Message}");
        }
        catch (UriFormatException e)
        {
            Console.WriteLine($"Invalid URL format: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}