using BlazorSnake.Client.Main;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddSingleton<Snakebody>();



await builder.Build().RunAsync();
