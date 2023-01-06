using Microsoft.OpenApi.Models;

public class SwaggerModule : IModuleDefinition
{
    public void AddModules(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "RestTest APIs",
                Version = "v1",
                Description = "List of Employee's Apis.",
                Contact = new OpenApiContact
                {
                    Name = "Nima Khandabi",
                    Email = "Nima.Khandabi@gmail.com"
                },
            });
        });
    }

    public void UseModules(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}
