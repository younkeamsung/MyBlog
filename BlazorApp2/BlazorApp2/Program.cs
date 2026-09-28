using BlazorApp2.Client.Interfaces;
using BlazorApp2.Client.Pages;
using BlazorApp2.Components;
using BlazorApp2.Database;
using BlazorApp2.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// app이 빌드되기전에 db를 연결
var connectionString = builder.Configuration.GetConnectionString("myBlogDb");
builder.Services.AddDbContextFactory<BlogDbContext>(
    options => options.UseSqlServer(connectionString));
// 인터페이스, 구현클래스
builder.Services.AddScoped<IBlogRepository, BlogRepositoryDataAccess>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryDataAccess>();


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
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp2.Client._Imports).Assembly);

app.Run();
