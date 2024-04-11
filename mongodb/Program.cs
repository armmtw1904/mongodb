using mongodb.Repository.Entities;
using mongodb.Repository.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string[] allowedOrigins = { "http://localhost:8080", "http://localhost:44468" };
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.Configure<MongoCnn>(builder.Configuration.GetSection("mongocnn"));


#region Repos
builder.Services.RegisterRepoDependencies();
#endregion Repos

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
