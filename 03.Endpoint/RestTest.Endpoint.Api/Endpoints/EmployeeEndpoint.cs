using ModuleDefinitions;
using RestTest.Core.ApplicationService.Employees.Commands.Create;

namespace RestTest.Endpoint.Api.Endpoints
{
    public class EmployeeEndpoint: IModuleDefinition
    {
        public void AddModules(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<CreateEmployeeCommandValidator>();
        }

        public void UseModules(WebApplication app)
        {
            throw new NotImplementedException();
        }
    }
}
