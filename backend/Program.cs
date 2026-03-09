using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controller support for API endpoints
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register the BowlingLeagueContext with SQLite as the database provider
// Connection string is defined in appsettings.json
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeagueConnection")));

// Configure CORS to allow requests from the React dev server (Vite on port 5173)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDev", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable OpenAPI/Swagger in development mode for testing
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Apply CORS policy, authorization, and map controller routes
app.UseCors("AllowReactDev");
app.UseAuthorization();
app.MapControllers();

app.Run();
