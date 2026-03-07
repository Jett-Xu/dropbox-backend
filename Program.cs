using dropbox_backend.Application.Interfaces;
using dropbox_backend.Application.Services;
using dropbox_backend.Infrastructure.Data;
using dropbox_backend.Infrastructure.Repositories;
using dropbox_backend.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy for Vue frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection for DDD Layers
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<INavigationRepository, NavigationRepository>();
builder.Services.AddScoped<IRecentFileRepository, RecentFileRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

builder.Services.AddScoped<IFolderService, FolderService>();
builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddScoped<IRecentFileService, RecentFileService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowVueFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run Database Seeder
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    await DbSeeder.SeedAsync(context, env.ContentRootPath);
}

app.Run();
