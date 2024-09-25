using FluentValidation;

public class DeleteShortUrlValidator : AbstractValidator<DeleteShortUrlCommand>
{
    public DeleteShortUrlValidator()
    {
        RuleFor(x => x.ShortUrl)
            .NotEmpty().WithMessage("Short URL cannot be empty.")
            .MaximumLength(2048).WithMessage("Short URL cannot exceed 2048 characters.")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Short URL can only contain alphanumeric characters.");
    }
}
