using PokerAnalyzer.API.Converters;
using PokerAnalyzer.Data.Context;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Services;
using PokerAnalyzer.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPokerGameService, PokerGameService>();
builder.Services.AddScoped<IPokerPlayerService, PokerPlayerService>();
builder.Services.AddScoped<IPokerHandRuleProvider, PokerHandRuleProvider>();
builder.Services.AddScoped<PokerAnalyzerContext>();

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new ITypedKeyConverter<PlayerId>());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: don't allow any and all requests to come through.
builder.Services.AddCors(o => o.AddPolicy("Cors", b =>
{
    b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
