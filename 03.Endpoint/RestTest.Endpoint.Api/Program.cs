using MediatR;
using Microsoft.EntityFrameworkCore;
using RestTest.Core.ApplicationService.Employees.Commands.Create;
using RestTest.Infra.Data.Sql.Command;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestTestContext")
    ?? throw new InvalidOperationException("Connection string 'RestTestContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).Assembly);
builder.Services.AddCors();

builder.AddModules();

var app = builder.Build();

app.UseModules();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.Run();