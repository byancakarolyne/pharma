using PharmaApp.Components;
using PharmaApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();  

builder.Services.AddScoped<ApiService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5053/") });

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseRouting();
app.MapBlazorHub();

app.MapFallbackToPage("/_Host");  

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
