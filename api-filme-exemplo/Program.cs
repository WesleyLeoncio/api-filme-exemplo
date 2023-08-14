using api_filme_exemplo.Infra.Data;
using api_filme_exemplo.Infra.Exceptions.Interface;
using api_filme_exemplo.Infra.Exceptions.TratarException;
using api_filme_exemplo.Infra.Middlewares;
using api_filme_exemplo.Repository;
using api_filme_exemplo.Repository.Interfaces;
using api_filme_exemplo.Service.Filme;
using api_filme_exemplo.Service.Interfaces;
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

builder.Services.AddTransient<IFilmeService, FilmeService>();


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