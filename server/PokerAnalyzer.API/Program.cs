using PokerAnalyzer.Services;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.

builder.Services.AddSingleton<IPokerAnalyzerService, PokerAnalyzerService> ();
builder.Services.AddControllers ();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen ();
builder.Services.AddCors ();

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ())
{

    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseCors (p => p.WithOrigins ("http://localhost:4200").AllowAnyHeader ().AllowAnyMethod ());

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

app.Run ();
