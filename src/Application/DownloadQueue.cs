namespace Application;

/// <summary>
/// Manages a queue of download commands for batch processing.
/// Provides FIFO (First-In-First-Out) queue functionality for download operations.
/// </summary>
public class DownloadQueue
{
    private readonly Queue<DownloadFileCommand> _queue;

    /// <summary>
    /// Initializes a new instance of the <see cref="DownloadQueue"/> class.
    /// </summary>
    public DownloadQueue()
    {
        _queue = new Queue<DownloadFileCommand>();
    }

    /// <summary>
    /// Adds a download command to the end of the queue.
    /// </summary>
    /// <param name="command">The download command to add to the queue.</param>
    public void Enqueue(DownloadFileCommand command)
    {
        _queue.Enqueue(command);
    }

    /// <summary>
    /// Removes and returns the download command at the beginning of the queue.
    /// </summary>
    /// <returns>The download command that was removed from the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public DownloadFileCommand Dequeue()
    {
        if (_queue.Count > 0)
        {
            return _queue.Dequeue();
        }
        else
        {
            throw new InvalidOperationException("The download queue is empty.");
        }
    }

    /// <summary>
    /// Gets the number of download commands currently in the queue.
    /// </summary>
    public int Count => _queue.Count;

    /// <summary>
    /// Removes all download commands from the queue.
    /// </summary>
    public void Clear()
    {
        _queue.Clear();
    }
}