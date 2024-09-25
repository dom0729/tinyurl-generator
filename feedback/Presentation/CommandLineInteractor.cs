using MediatR;

public class CommandLineInteractor
{
    private readonly IMediator _mediator;

    public CommandLineInteractor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Unit> Create()
    {
        Console.Write("Enter Long URL: ");
        var longUrl = Console.ReadLine();

        Console.Write("Enter Custom Short URL (or press Enter for random): ");
        var customShortUrl = Console.ReadLine();

        var createResponse = await _mediator.Send(new CreateShortUrlCommand { LongUrl = longUrl, CustomShortUrl = customShortUrl });

        Console.WriteLine($"Created Short URL: {createResponse.AddDefaultDomain()}");
        return Unit.Value;
    }

    public async Task<Unit> Delete()
    {
        Console.Write("Enter Short URL to delete: ");
        var shortUrlToDelete = Console.ReadLine().RemoveDefaultDomain();

        var deleteResponse = await _mediator.Send(new DeleteShortUrlCommand { ShortUrl = shortUrlToDelete });

        Console.WriteLine($"Success: {deleteResponse}");
        return Unit.Value;
    }

    public async Task<Unit> GetLongUrl()
    {
        Console.Write("Enter Short URL to get Long URL: ");
        var shortUrlToGet = Console.ReadLine().RemoveDefaultDomain();

        var longUrlResponse = await _mediator.Send(new GetLongUrlQuery { ShortUrl = shortUrlToGet });
        Console.WriteLine($"Long URL: {longUrlResponse}");
        return Unit.Value;
    }

    public async Task<Unit> GetClickCount()
    {

        Console.Write("Enter Short URL to get Click Count: ");
        var shortUrlForCount = Console.ReadLine().RemoveDefaultDomain();

        var clickCountResponse = await _mediator.Send(new GetClickCountQuery { ShortUrl = shortUrlForCount });

        Console.WriteLine($"Click Count: {clickCountResponse}");
        return Unit.Value;
    }

    public async void Run()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\nChoose an option: 1) Create 2) Delete 3) Get Long URL 4) Get Click Count 5) Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await Create();
                        break;

                    case "2":
                        await Delete();
                        break;

                    case "3":
                        await GetLongUrl();
                        break;

                    case "4":
                        await GetClickCount();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred ${e.Message}");
            }
        }
    }
}