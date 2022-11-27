using Checker.Server.Data;
using Checker.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR(x => { x.EnableDetailedErrors = true; });
builder.Services.AddSingleton<TableManager>();

var app = builder.Build();
//app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();


//app.MapBlazorHub();
app.MapHub<MultiPlayerHub>("/connect");
//app.MapFallbackToPage("/_Host");

app.MapFallbackToFile("index.html");

app.Run();
