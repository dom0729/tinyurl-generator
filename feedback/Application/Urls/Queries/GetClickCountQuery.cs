using MediatR;

public class GetClickCountQuery : IRequest<int>
{
    public string? ShortUrl { get; set; }
}

public class GetClickCountQueryHandler : IRequestHandler<GetClickCountQuery, int>
{
    private readonly IUrlRepository _urlRepository;

    public GetClickCountQueryHandler(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public Task<int> Handle(GetClickCountQuery request, CancellationToken cancellationToken)
    {
        Url? url = _urlRepository.GetByShortUrl(request.ShortUrl!);
        if (url == null)
        {
            throw new NotFoundException($"{request.ShortUrl}-Not Found ShortUrl");
        }
        return Task.FromResult(url.ClickCount);
    }
}

