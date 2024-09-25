using MediatR;


public class DeleteShortUrlCommand : IRequest<bool>
{
    public string? ShortUrl { get; set; }
}
public class DeleteShortUrlCommandHandler : IRequestHandler<DeleteShortUrlCommand, bool>
{

    private readonly IUrlRepository _urlRepository;

    public DeleteShortUrlCommandHandler(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public Task<bool> Handle(DeleteShortUrlCommand request, CancellationToken cancellationToken)
    {
        string shortUrl = request.ShortUrl!;
        Url? url = _urlRepository.GetByShortUrl(shortUrl);
        if (url == null)
        {
            throw new NotFoundException($"{request.ShortUrl}-Not Found ShortUrl");
        }

        var result = _urlRepository.Remove(shortUrl);
        return Task.FromResult(result);
    }
}