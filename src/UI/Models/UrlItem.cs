using System;

namespace UI.Models;

public class UrlItem
{
    public string Url { get; }
    public Guid Id { get; }

    public UrlItem(Guid id, string url)
    {
        Id = id;
        Url = url;
    }
}