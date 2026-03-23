using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UI.Models;

namespace UI;

public class LinkQueueState
{
    private readonly Queue<UrlItem> _queue = new();
    private readonly ObservableCollection<UrlItem> _items = new();

    public ReadOnlyObservableCollection<UrlItem> Items { get; }

    public int Count => _queue.Count;

    public LinkQueueState()
    {
        Items = new ReadOnlyObservableCollection<UrlItem>(_items);
    }

    public bool TryEnqueue(string? rawUrl)
    {
        if (string.IsNullOrWhiteSpace(rawUrl))
            return false;

        var normalizedUrl = rawUrl.Trim();
        var item = new UrlItem(Guid.NewGuid(), normalizedUrl);

        _queue.Enqueue(item);
        _items.Add(item);
        return true;
    }

    public UrlItem? Dequeue()
    {
        if (_queue.Count == 0)
            return null;

        var item = _queue.Dequeue();
        _items.Remove(item);
        return item;
    }

    public bool Remove(Guid id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item is null)
            return false;

        _items.Remove(item);

        _queue.Clear();
        foreach (var existing in _items)
            _queue.Enqueue(existing);

        return true;
    }

    public void Clear()
    {
        _queue.Clear();
        _items.Clear();
    }
}