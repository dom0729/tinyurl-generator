using MediatR;

public class GetLongUrlQuery : IRequest<string>
{
    public string? ShortUrl { get; set; }
}

public class GetLongUrlQueryHandler : IRequestHandler<GetLongUrlQuery, string>
{
    private readonly IUrlRepository _urlRepository;
    private readonly IMediator _mediator;

    public GetLongUrlQueryHandler(IUrlRepository urlRepository, IMediator mediator)
    {
        _urlRepository = urlRepository;
        _mediator = mediator;
    }

    public Task<string> Handle(GetLongUrlQuery request, CancellationToken cancellationToken)
    {

        var url = _urlRepository.GetByShortUrl(request.ShortUrl!);
        if (url == null)
        {
            throw new NotFoundException($"{request.ShortUrl}- Not Found ShortUrl");
        }

        var notification = new ShortUrlClickedEvent(request.ShortUrl!);
        _mediator.Publish(notification, cancellationToken);

        var longUrl = url.LongUrl;
        return Task.FromResult(longUrl);
    }

}
