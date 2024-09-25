using System.Collections.Generic;

public interface IUrlRepository
{
    void Add(Url url);
    Url? GetByShortUrl(string shortUrl);
    void Update(Url url);
    bool Remove(string shortUrl);
    bool ShortUrlExists(string shortUrl);
}
