using MediatR;
using Microsoft.EntityFrameworkCore;
using RestTest.Core.ApplicationService.Employees.Commands.Create;
using RestTest.Infra.Data.Sql.Command;
using RestTest.Infra.Data.Sql.Query.Employees;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestTestCommandContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestTestContext")));

builder.Services.AddDbContext<RestTestQueryContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestTestContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).Assembly);

builder.AddModules();

var app = builder.Build();

app.UseModules();
app.UseHttpsRedirection();

app.Run();