using GoogleBooksApp.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using GoogleBooksApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<GoogleBooksApiClient>();
builder.Services.AddDbContext<AppDbContext>(); // This is where we add the DbContext to our services
builder.Services.AddHsts(opts =>
{
    opts.MaxAge = TimeSpan.FromDays(1);
    opts.IncludeSubDomains = true;
});
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "BooksLibrary", Version = "v1" }); });

var app = builder.Build();
if (app.Environment.IsProduction())
{
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp"); });

app.Run();
