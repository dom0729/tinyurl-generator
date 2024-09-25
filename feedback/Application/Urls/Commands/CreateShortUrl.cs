using MediatR;

public class CreateShortUrlCommand : IRequest<string>
{
    public string? LongUrl { get; set; }
    public string? CustomShortUrl { get; set; }
}

public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, string>
{
    private readonly IUrlRepository _urlRepository;

    public CreateShortUrlCommandHandler(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public Task<string> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
    {
        string shortUrl;

        if (!string.IsNullOrEmpty(request.CustomShortUrl))
        {
            if (_urlRepository.ShortUrlExists(request.CustomShortUrl))
                throw new BadRequestException($"{request.CustomShortUrl}-Short URL already exists.");
            shortUrl = request.CustomShortUrl;
        }
        else
        {
            do
            {
                shortUrl = GenerateRandomShortUrl();
            } while (_urlRepository.ShortUrlExists(shortUrl));
        }

        var url = new Url { ShortUrl = shortUrl, LongUrl = request.LongUrl! };
        _urlRepository.Add(url);
        return Task.FromResult(shortUrl);
    }

    private string GenerateRandomShortUrl()
    {
        return Guid.NewGuid().ToString().Substring(0, 6); // A simple random code generation
    }
}
