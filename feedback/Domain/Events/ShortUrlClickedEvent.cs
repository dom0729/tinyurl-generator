using MediatR;

public class ShortUrlClickedEvent : INotification
{
    public ShortUrlClickedEvent(string shortUrl)
    {
        ShortUrl = shortUrl;
    }
    public string ShortUrl { get; }
}