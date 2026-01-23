using HW6.Abstractions;
using HW6.Application;
using HW6.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var services = new ServiceCollection();

services.AddSingleton<IConfiguration>(configuration);

services.AddSingleton<ISettingsProvider, JsonSettingsProvider>();
services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
services.AddSingleton<IInputReader, ConsoleInputReader>();
services.AddSingleton<IOutputWriter, ConsoleOutputWriter>();
services.AddSingleton<IHintStrategy, DefaultHintStrategy>();
services.AddSingleton<IGuessParser, DefaultGuessParser>();

services.AddSingleton<GuessNumberGame>();

using var provider = services.BuildServiceProvider();

provider.GetRequiredService<GuessNumberGame>().Run();