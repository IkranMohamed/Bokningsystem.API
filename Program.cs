using Bokningsystem.API.Data;
using Bokningsystem.API.Repositories;
using Bokningsystem.API.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// --- Alla dina services, DB, Repositories, Validators osv ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\mssqllocaldb;Database=BokningsDB;Trusted_Connection=True;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrera repositories, services, validators
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBokningRepository, BokningRepository>();
builder.Services.AddScoped<IBokningService, BokningService>();
builder.Services.AddScoped<IAnvandareRepository, AnvandareRepository>();
builder.Services.AddScoped<IAnvandareService, AnvandareService>();
builder.Services.AddScoped<ITjanstRepository, TjanstRepository>();
builder.Services.AddScoped<ITjanstService, TjanstService>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Bygg appen först ---
var app = builder.Build();

// Skapa databasen om den inte finns
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated(); // Skapar DB och tabeller om de inte finns
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
