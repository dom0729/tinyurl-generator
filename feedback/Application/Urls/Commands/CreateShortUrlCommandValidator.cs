using System.Runtime.CompilerServices;
using FluentValidation;

public class CreateShortUrlCommandValidator : AbstractValidator<CreateShortUrlCommand>
{
    public CreateShortUrlCommandValidator()
    {
        RuleFor(x => x.LongUrl)
            .NotEmpty().WithMessage("Long URL cannot be empty.")
            .MaximumLength(2048).WithMessage("Long URL cannot exceed 2048 characters.")
            .Must(BeAValidUrl).WithMessage("Long URL must be a valid URL.");

        RuleFor(x => x.CustomShortUrl)
            .MaximumLength(2048).WithMessage("Short URL cannot exceed 2048 characters.")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Custom Short URL can only contain alphanumeric characters.");
    }

    private bool BeAValidUrl(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
