using BlazorSnake.Client.Main;
using BlazorSnake.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddSingleton<Snakebodyv1>();
builder.Services.AddSingleton<Snakebodyv1_5>();



builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ILeaderboardService, ClientLeaderboardService>();

await builder.Build().RunAsync();
