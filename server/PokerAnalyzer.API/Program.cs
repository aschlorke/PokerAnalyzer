using PokerAnalyzer.Services;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.

builder.Services.AddSingleton<IPokerAnalyzerService, PokerAnalyzerService> ();
builder.Services.AddControllers ();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen ();
builder.Services.AddCors (o => o.AddPolicy("Cors", builder =>
{
    builder.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
}));

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ())
{

    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseCors ("Cors");

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

app.Run ();
