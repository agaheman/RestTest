using Microsoft.EntityFrameworkCore;
using RestTest.Infra.Data.Sql.Command;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestTestContext1>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestTestContext")
    ?? throw new InvalidOperationException("Connection string 'RestTestContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();