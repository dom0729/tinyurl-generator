using System.Collections.Concurrent;
using System.Collections.Generic;

public class InMemoryUrlRepository : IUrlRepository
{
    private readonly ConcurrentDictionary<string, Url> _urlStore;

    public InMemoryUrlRepository()
    {
        _urlStore = new ConcurrentDictionary<string, Url>();
    }

    public void Add(Url url)
    {
        _urlStore.TryAdd(url.ShortUrl, url);
    }

    public Url? GetByShortUrl(string shortUrl)
    {
        _urlStore.TryGetValue(shortUrl, out var url);
        return url;
    }

    public void Update(Url url)
    {
        _urlStore.AddOrUpdate(url.ShortUrl, url, (key, oldValue) => url);
    }

    public bool Remove(string shortUrl)
    {
        return _urlStore.TryRemove(shortUrl, out _);
    }

    public bool ShortUrlExists(string shortUrl)
    {
        return _urlStore.TryGetValue(shortUrl, out _);
    }
}
