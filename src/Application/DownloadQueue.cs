namespace Application;

public class DownloadQueue
{
    private readonly Queue<DownloadFileCommand> _queue;

    public DownloadQueue()
    {
        _queue = new Queue<DownloadFileCommand>();
    }

    public void Enqueue(DownloadFileCommand command)
    {
        _queue.Enqueue(command);
    }

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

    public int Count => _queue.Count;

    public void Clear()
    {
        _queue.Clear();
    }
    
    
}