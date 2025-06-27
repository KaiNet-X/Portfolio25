using Microsoft.AspNetCore.Server.Kestrel.Core;
using Portfolio25.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(8081, listenOptions =>
//     {
//         //listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
//         listenOptions.UseHttps();
//     });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
