using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestTest.Core.ApplicationService.Employees.Commands.Create;
using RestTest.Core.ApplicationService.Employees.Queries.GetById;
using RestTest.Core.Contract.Employees.Commands;
using RestTest.Core.Contract.Employees.Commands.Create;
using RestTest.Core.Contract.Employees.Queries;
using RestTest.Core.Contract.Employees.Queries.GetById;
using RestTest.Infra.Data.Sql.Command.Employees.Repositories;
using RestTest.Infra.Data.Sql.Query.Employees.Repositories;

namespace RestTest.Endpoint.Api.Endpoints;

public class EmployeeEndpoint : IModuleDefinition
{
    public void AddModules(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateEmployeeCommandValidator>();
        builder.Services.AddTransient<IEmployeeCommandRepository, EmployeeCommandRepository>();

        builder.Services.AddScoped<GetEmployeeByIdQueryValidator>();
        builder.Services.AddTransient<IEmployeeQueryRepository, EmployeeQueryRepository>();
    }

    public void UseModules(WebApplication app)
    {
        app.MapPost("/Employee", async ([FromBody] CreateEmployeeCommand createRequest, [FromServices] IMediator mediator) =>
        {
            var serviceResult = await mediator.Send<Result<int, ValidationResult>>(createRequest);

            return serviceResult.CreateResult();
        })
          .Produces(StatusCodes.Status201Created)
          .Produces(StatusCodes.Status400BadRequest);


        app.MapGet("/Employee/{employeeId}", async ([FromRoute] int employeeId, [FromServices] IMediator mediator) =>
        {
            var serviceResult = await mediator.Send<Result<GetEmployeeByIdQueryResult, ValidationResult>>(new GetEmployeeByIdQuery(employeeId));

            return serviceResult.QueryReult();
        })
         .Produces(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound)
         .Produces(StatusCodes.Status400BadRequest);
    }



}
