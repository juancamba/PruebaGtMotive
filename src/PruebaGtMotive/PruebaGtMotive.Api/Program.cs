using PruebaGtMotive.Infrastructure;
using PruebaGtMotive.Application;
using PruebaGtMotive.Api.Extensions;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();


//if (app.Environment.IsDevelopment())

    app.UseSwagger();
    app.UseSwaggerUI();


await app.ApplyMigration();
app.SeedData();
app.SeedDataUsers();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();


public partial class Program;