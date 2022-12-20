
using CrudTest.Api.Setup;
using CrudTest.Application.Behaviors;
using CrudTest.Application.Commands;
using CrudTest.Infra.Data.Ef;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; 
var configuration = builder.Configuration;
var env = builder.Environment;

// Add services to the container.
services.AddAppSetting(configuration);
services.AddAppDependencies(configuration);

services.AddMediatR(typeof(Program).Assembly, typeof(CustomerCreateCommandHandler).Assembly);
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SetMessagePipelineBehavior<,>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();
if (env.IsProduction())
    using (var scope = app.Services.CreateScope())
    {
        using (var dbContext = scope.ServiceProvider.GetService<CrudTestDbContext>())
        {
            dbContext?.Database.Migrate();
        }
    }

app.Run();

