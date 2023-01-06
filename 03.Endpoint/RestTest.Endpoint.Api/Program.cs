using MediatR;
using Microsoft.EntityFrameworkCore;
using ModuleDefinitions;
using RestTest.Infra.Data.Sql.Command;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestTestContext")
    ?? throw new InvalidOperationException("Connection string 'RestTestContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.AddModules();

var app = builder.Build();

app.UseModules();

app.UseHttpsRedirection();

app.Run();