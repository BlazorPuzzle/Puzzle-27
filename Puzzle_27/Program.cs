global using Puzzle_27;
using Microsoft.AspNetCore.Components;
using Puzzle_27.Client.Pages;
using Puzzle_27.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient("", (services, options) => {
	var scope = services.CreateScope().ServiceProvider;
	var navmgr = scope.GetRequiredService<NavigationManager>();
	options.BaseAddress = new Uri(navmgr.BaseUri);
});

var app = builder.Build();

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

app.MapEpisodeApi();

app.MapRazorComponents<App>()
		.AddInteractiveWebAssemblyRenderMode()
		.AddAdditionalAssemblies(typeof(Puzzle_27.Client._Imports).Assembly);

app.Run();
