using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestTest.Core.ApplicationService.Employees.Commands.Create;
using RestTest.Core.Contract.Employees.Commands;
using RestTest.Core.Contract.Employees.Commands.Create;
using RestTest.Infra.Data.Sql.Command.Employees.Repositories;

namespace RestTest.Endpoint.Api.Endpoints;

public class EmployeeEndpoint : IModuleDefinition
{
    public void AddModules(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateEmployeeCommandValidator>();
        builder.Services.AddTransient<IEmployeeCommandRepository, EmployeeCommandRepository>();
    }

    public void UseModules(WebApplication app)
    {
        app.MapPost("/Employee", async ([FromBody] CreateEmployeeCommand createRequest, [FromServices] IMediator mediator) =>
        {
            var serviceResult = await mediator.Send<Result<int, ValidationResult>>(createRequest);

            return serviceResult.IsSuccess
            ? Results.StatusCode(StatusCodes.Status201Created)
            : Results.ValidationProblem(serviceResult.Error.ToDictionary());
        })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);


        app.MapGet("/Employee/Id", async ([FromRoute] CreateEmployeeCommand createRequest, [FromServices] IMediator mediator) =>
        {
            var serviceResult = await mediator.Send<Result<int, ValidationResult>>(createRequest);

            return serviceResult.IsSuccess
            ? Results.CreatedAtRoute("GetEmployeeById", routeValues: new { id = serviceResult.Value }, value: serviceResult.Value)
            : Results.ValidationProblem(serviceResult.Error.ToDictionary());
        })
         .WithName("GetEmployeeById");
    }
}
