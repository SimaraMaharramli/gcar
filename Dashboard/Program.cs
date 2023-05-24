using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;
using Service.Services.Mappings;
using Service.Services;
using Microsoft.Extensions.Configuration;
using Repository.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service;
using RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvcCore();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddRepositoryLayer();
builder.Services.AddServiceLayer();
builder.Services.AddSignalR();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Aws"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Location/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Location}/{action=Index}/{id?}");

app.Run();
