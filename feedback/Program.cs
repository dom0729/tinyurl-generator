using System.Reflection;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();

services.AddLogging();
services.AddSingleton<IUrlRepository, InMemoryUrlRepository>();
services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
});
services.AddSingleton<CommandLineInteractor>();

var serviceProvider = services.BuildServiceProvider();

var commandLineInteractor = serviceProvider.GetRequiredService<CommandLineInteractor>();

commandLineInteractor.Run();