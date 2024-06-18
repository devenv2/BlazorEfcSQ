using BlazorEfcSQ.Components;
using BlazorEfcSQ.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Register DbContext
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlite("Data Source = ProductsDB.db");
});
builder.Services.AddScoped<ProductServices>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
