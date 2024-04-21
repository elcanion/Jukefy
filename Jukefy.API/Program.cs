using Jukefy.API.Configuration;
using Jukefy.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Jukefy",
        Description = "An jukebox-like app integrated to Spotify"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddAuthorization();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IJukefyServices, JukefyServices>();
IConfigurationSection spotifyConfigurationSection = builder.Configuration.GetSection("Spotify");
builder.Services.Configure<SpotifyConfigurationOptions>(spotifyConfigurationSection);
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI"); c.InjectStylesheet("/swagger-ui/SwaggerDark.css"); });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
