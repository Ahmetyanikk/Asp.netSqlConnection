using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<test2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("test2Context") ?? throw new InvalidOperationException("Connection string 'test2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MvcMovie.Data.MvcMovieContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));
var app = builder.Build();

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

app.Run();
