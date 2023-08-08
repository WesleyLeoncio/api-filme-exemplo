
using api_filme_exemplo.Data;
using api_filme_exemplo.Exceptions;
using api_filme_exemplo.Exceptions.TratarException;
using api_filme_exemplo.Middlewares;
using api_filme_exemplo.Repository;
using api_filme_exemplo.Repository.interfaces;
using api_filme_exemplo.Service.Filme;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConectionContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IFilmeRepository, FilmeRepository>();

builder.Services.AddTransient<IErrorResultTask, TratarNotFoundException>();

builder.Services.AddScoped<FilmeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();