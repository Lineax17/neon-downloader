namespace Core;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Core Main Running");
        Console.WriteLine(PathHelper.getDownloadDirectory());
        Console.WriteLine(PathHelper.getHomeDirectory());

        String downloadUrl =
            "https://dl.fedoraproject.org/pub/fedora/linux/releases/43/KDE/x86_64/iso/Fedora-KDE-Desktop-Live-43-1.6.x86_64.iso";
        
        Download downloader = new Download();
        downloader.download(downloadUrl, "fedora.iso");
        Console.WriteLine("Download completed.");
    }
}