using MediatR;

public class ShortUrlClickedEventHandler : INotificationHandler<ShortUrlClickedEvent>
{
    readonly private IUrlRepository _urlRepository;
    public ShortUrlClickedEventHandler(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public Task Handle(ShortUrlClickedEvent notification, CancellationToken cancellationToken)
    {
        var shortUrl = notification.ShortUrl;
        var url = _urlRepository.GetByShortUrl(shortUrl);
        if (url == null)
        {
            throw new NotFoundException($"{shortUrl}- Not Found ShortUrl");
        }

        url.ClickCount++;
        _urlRepository.Update(url);

        return Task.CompletedTask;
    }
}