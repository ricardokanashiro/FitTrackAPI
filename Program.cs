using FitTrackAPI.Database;
using FitTrackAPI.Repositories;
using FitTrackAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando DB
builder.Services.AddScoped<FitTrackDbContext>();

// Adicionando camadas de ALUNO
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<AlunoService>();

// Adicionando camadas de AVALIACAO
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<AvaliacaoService>();

// Adicionando camadas de TREINO
builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();
builder.Services.AddScoped<TreinoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
