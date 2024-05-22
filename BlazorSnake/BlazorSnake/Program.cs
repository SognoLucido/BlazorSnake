
using BlazorSnake;
using BlazorSnake.Client.Main;
using BlazorSnake.Client.Services;
using BlazorSnake.Components;

using Dbleaderboardsave;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<Snakebodyv1>();
builder.Services.AddScoped<Snakebodyv1_5>();

builder.Services.AddScoped<IDatabasecore,Databasecore>();
//builder.Services.AddSingleton<ILeaderboardService, ServerLeaderboardService>();


builder.Services.AddControllers();

var app = builder.Build();

app.UseDbstartconfig(app.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorSnake.Client._Imports).Assembly);

app.Run();
