using Microsoft.EntityFrameworkCore;
using HeroesApi.Contexts;
using Models.DataRepository;
using Models.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HeroContext>(options =>
{
    builder.Configuration.AddEnvironmentVariables();
    var connectionString = builder.Configuration.GetConnectionString("HeroesConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IDataRepository, HeroRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HeroContext>();
    db.Database.Migrate();
}

app.Run();
